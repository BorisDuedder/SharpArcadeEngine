using System.Collections.Generic;
using GameConcepts.Entities;

namespace GameConcepts
{
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

    public abstract class Game : IGameState, IGameDescription
    {
        private int _lifes;
        private int _score;
        private IEnumerable<Entity> _entities;
        private IEnumerable<IGameScript> _scripts;

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

        public void Update()
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
    }
}
