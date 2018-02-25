using System;

namespace SnakeGame
{
    [Serializable]
    internal class Player
    {
        public string name;
        public int score;

        public Player(string _name = "",int _score = 0)
        {
            name = _name;
            score = _score;
        }
    }
}