using CricketScoreManagement.teamComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.conductMatch
{
   public class Match : IMatch
    {
        private int oversPerInnings;
        private int playersPerTeam;
        private int target;
        private ITeam TA;
        private ITeam TB;

        public Match(ITeam A,ITeam B)
        {
            TA = A;
            TB = B;
        }
        public void configure()
        {
            Console.Out.WriteLine("Number of players in each team :");
            playersPerTeam = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Number of overs per innings :");
            oversPerInnings = Convert.ToInt32(Console.ReadLine());
            target = int.MaxValue;

        }

        public void playFirstInnings()
        {
            TA.TeamSize = playersPerTeam;
            TA.TeamID = 1;
            TA.configurePlayers();
            start(TA);
            target = TA.TotScore + 1;
        }

        public void playSecondInnings()
        {
            TB.TeamSize = playersPerTeam;
            TB.TeamID=2;
            TB.configurePlayers();
            start(TB);
        }
        private void start(ITeam T)
        {

            for (int over = 0; over < oversPerInnings; over++)
            {
                Console.Out.WriteLine("Over " + ((int)(T.OversPlayed + 1)) + " :");

                playOver(T);
                T.printScoreBoard();
                T.rotateStrike();
                if (T.WicketsDown >= playersPerTeam - 1)
                    return;
            }
        }
        private void playOver(ITeam T)
        {
            int ballsFaced = 0;
            while (ballsFaced < 6 && T.WicketsDown < playersPerTeam - 1)
            {
                String b = Console.ReadLine();


                T.updateScoreBoard(b);

                if (!b.Equals("Wd") && !b.Equals("NB"))
                {
                    ballsFaced++;
                    T.addBallsPlayed();
                }
                if (target <= T.TotScore)
                    return;
            }
        }

        public void result()
        {
            if (target <= TB.TotScore)
                Console.Out.WriteLine("Result: Team " + 2 + " won by " + (TB.TotScore - target + 1) + " runs");

            else
                Console.Out.WriteLine("Result: Team " + 1 + " won by " + (TA.TotScore - TB.TotScore) + " runs");

        }
    }
}
