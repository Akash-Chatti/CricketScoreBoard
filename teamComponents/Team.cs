using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.teamComponents
{
	class Team : ITeam
	{

		private int wicketsDown;
		private IPlayer onStriker;
		private IPlayer nonStriker;
		private int nextPlayerInd;
		private int totScore;
		private double oversPlayed;
		private int teamID;
		private int teamSize;
		private Player[] batsmen;
		public Team(IPlayer a,IPlayer b)
		{
			
			
			oversPlayed = 0.00d;
			totScore = 0;
			nextPlayerInd = 0;
			wicketsDown = 0;
			onStriker = a;
			nonStriker = b;
		}

		public int TotScore { get => totScore; }
		public double OversPlayed { get => oversPlayed; }
		public int WicketsDown { get => wicketsDown; }
        public int TeamSize { get => teamSize; set => teamSize = value; }
        public int TeamID { get => teamID; set => teamID = value; }

        public void configurePlayers()
		{
			Console.Out.WriteLine("Batting order for team " + TeamID + ":");
			batsmen = new Player[teamSize];
			for (int p = 0; p < TeamSize; p++)
			{
				string name = Console.ReadLine();
				Player ply = new Player();
				ply.Name = name;
				batsmen[p] =ply;
			}
			onStriker = batsmen[0];
			nonStriker = batsmen[1];
			nextPlayerInd = 2;
		}
		public void addBallsPlayed()
		{
			double t = (oversPlayed + 0.1) - (int)(oversPlayed + 0.1);
			if (t >= 0.6)
				oversPlayed = Math.Ceiling(oversPlayed);
			else
				oversPlayed += 0.1;

		}
		public void printScoreBoard()
		{
			Console.Out.WriteLine("Scorecard for Team " + TeamID + ":");
			Console.Out.WriteLine("---------------------------");
			Console.Out.WriteLine("Player Name\tScore  4's  6's  Balls");
			for (int ind = 0; ind < TeamSize; ind++)
			{
				Player p = batsmen[ind];
				String name = p.Name;
				if (p == onStriker || p == nonStriker)
					name += "*";
				Console.Out.WriteLine(name + "\t\t" + p.Score + "\t" + p.Fours + "   " + p.Sixes + "    " + p.BallsPlayed);
			}
			Console.Out.WriteLine("Total : " + totScore + "/" + wicketsDown);

			Console.Out.WriteLine("Overs : " + Math.Round(oversPlayed,1) + "\n");
		}

		public void updateScoreBoard(string b)
		{

			if (b.Equals("W"))
			{
				wicketDown();

			}
			else
			{
				int score = 0;
				if (b.Equals("Wd") || b.Equals("NB"))
				{
					score = 1;
				}
				else
				{
					score = Convert.ToInt32(b);
					onStriker.updateScore(score, 1);
					if (score == 1 || score == 3)
						rotateStrike();
				}
				totScore += score;

			}
		}

		void wicketDown()
		{
			wicketsDown++;
			onStriker.playerOut();
			if (nextPlayerInd < batsmen.Length)
			{
				onStriker = batsmen[nextPlayerInd];
				nextPlayerInd++;
			}
			else
				onStriker = null;

		}

		public void rotateStrike()
		{
			IPlayer t = nonStriker;
			nonStriker = onStriker;
			onStriker = t;

		}
	}
}
