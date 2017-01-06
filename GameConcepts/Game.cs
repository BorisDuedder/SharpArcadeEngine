using System.Collections.Generic;
using System.Drawing;
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

    public abstract class Game : IGameState, IGameDescription, IGameRendering, IGameEventHandler
    {
        private int _lifes;
        private int _score;
        private IEnumerable<Entity> _entities;
        private IEnumerable<IGameScript> _scripts;

        public abstract void OnKeyPressed(KeyEventArgs args);

        public abstract void OnDrawScene(Graphics graphics);

        public string Name { get; }
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

        public void UpdateScripts()
        {
            if (_scripts != null)
                foreach(IGameScript script in _scripts)
                    script.Action(this);
            if (_entities != null)
                foreach (var entity in _entities)
                    if (entity.Scripts != null)
                        foreach (var script in entity.Scripts)
                            script.Action(this, entity);
        }

        public void RenderScene(Graphics graphics)
        {
            UpdateScripts();
            RenderEntities(graphics);
        }

        public void RenderEntities(Graphics graphics)
        {
            if (_entities != null)
                foreach (var entity in _entities)
                    entity.RenderEntity(graphics);
        }
    }
}
