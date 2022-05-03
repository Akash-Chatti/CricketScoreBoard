using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.teamComponents
{
    class Player : IPlayer
    {
        private int score;
        private int ballsPlayed;
        private int sixes;
        private int fours;
        private int dot;
        private string name ;

        public int Score { get => score;}
        public int BallsPlayed { get => ballsPlayed; }
        public int Sixes { get => sixes;  }
        public int Fours { get => fours; }
        public int Dot { get => dot; }
        public string Name { get => name; set => name = value; }

      
        public void playerOut()
        {
            ballsPlayed++;
        }

        public void updateScore(int s, int ballCount)
        {
            if (s == 6)
                sixes++;
            else if (s == 4)
                fours++;
            else if (s == 0)
                dot++;
            ballsPlayed += ballCount;
            score += s;
        }
    }
}
