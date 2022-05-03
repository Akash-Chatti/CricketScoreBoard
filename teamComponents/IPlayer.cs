using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.teamComponents
{
    public interface IPlayer
    {
        public int Score { get ; }
        public int BallsPlayed { get ; }
        public int Sixes { get ; }
        public int Fours { get ; }
        public int Dot { get ; }
        public string Name { get; set; }

        public void updateScore(int s, int ballCount);
        public void playerOut();

    }
}
