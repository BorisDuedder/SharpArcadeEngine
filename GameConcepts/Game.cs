using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using GameConcepts.Entities;

namespace GameConcepts
{
    public delegate void DrawSceneHandler(Graphics graphics);

    public delegate void KeyPressedHandler(KeyEventArgs args);

    public interface IGameState
    {
        int Lifes { get; set; }
        int Score { get; set; }
        void DecreaseLifes();
        void AddExtraLifes();
        void AddToScore(int points);
    }

    public interface IGameDescription
    {
        string Name { get; }
        string ShortDescription { get; }
    }

    public interface IGameEvents
    {
        void ScoreChanged(int Score);
        void LifesChanges(int Lifes);
        void BeforeUpdate();
        void AfterUpdate();
        void UpdateSceneGraph();
    }

    public interface IGameRendering
    {
        void UpdateScripts();
        void RenderScene(Graphics graphics);
        void RenderEntities(Graphics graphics);
    }

    public interface IGameEventHandler
    {
        void OnKeyPressed(KeyEventArgs args);
        void OnDrawScene(Graphics graphics);
    }

    // Active Object
    public abstract class Game : IGameState, IGameDescription, IGameRendering, IGameEventHandler
    {
        private int _lifes;
        private int _score;
        private IEnumerable<Entity> _entities;
        private IEnumerable<IGameScript> _scripts;
        private Entity _player;

        public Entity Player { get { return _player; } set { _player = value; } }

        public abstract void OnKeyPressed(KeyEventArgs args);

        public abstract void OnDrawScene(Graphics graphics);

        public string Name { get; set; }
        public string ShortDescription { get; }

        public int Lifes
        {
            get { return _lifes; }
            set { _lifes = value>=0 ? value : 0; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value>=0 ? value : 0; }
        }

        public void DecreaseLifes()
        {
            
        }
    
        public void AddExtraLifes()
        {
            
        }

        public void AddToScore(int points)
        {
            
        }

        public void CallInitializeScripts()
        {
            if (_scripts != null)
                foreach (IGameScript script in _scripts)
                    script.Initialize(this);
            if (_entities != null)
                foreach (var entity in _entities)
                    if (entity.Scripts != null)
                        foreach (var script in entity.Scripts)
                            script.Initialize(this, entity);
        }

        public void UpdateScripts()
        {
            if (_scripts != null)
                foreach(IGameScript script in _scripts)
                    script.Execute(this);
            if (_entities != null)
                foreach (var entity in _entities)
                    if (entity.Scripts != null)
                        foreach (var script in entity.Scripts)
                            script.Execute(this, entity);
        }

        public void CallDestroyScripts()
        {
            if (_entities != null)
                foreach (var entity in _entities)
                    if (entity.Scripts != null)
                        foreach (var script in entity.Scripts)
                            script.Destroy(this, entity);
            if (_scripts != null)
                foreach (IGameScript script in _scripts)
                    script.Destroy(this);
        }

        public void RenderScene(Graphics graphics)
        {
            UpdateScripts();
            RenderEntities(graphics);
        }

        public void RenderEntities(Graphics graphics)
        {
            if(_player!=null)
                _player.RenderEntity(graphics);
            if (_entities != null)
                foreach (var entity in _entities)
                    entity.RenderEntity(graphics);
        }

        public abstract Image LoadImage(string fileName);        
    }
}
