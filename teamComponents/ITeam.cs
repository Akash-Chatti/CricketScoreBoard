using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.teamComponents
{
   public interface ITeam
    {
        public int TotScore { get; }
        public double OversPlayed { get; }
        public int WicketsDown { get ; }
        public int TeamSize { get ; set ; }
        public int TeamID { get ; set; }

        public void configurePlayers();
        public void updateScoreBoard(String b);
        public void addBallsPlayed();
        public void rotateStrike();
        public void printScoreBoard();
    }
}
