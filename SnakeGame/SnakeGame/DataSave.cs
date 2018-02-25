using System;

namespace SnakeGame
{ 
    [Serializable]
    internal class DataSave
    {
        public Snake snake;
        public Wall wall;
        public Food food;
        public int score;
        public int level;
        public bool GameOver;

        public DataSave()
        {
            level = Game.level;
            wall = Game.wall;
            food = Game.food;
            score = Game.score;
            snake = Game.snake;
            GameOver = Game.Gameover;
        }
    }
}