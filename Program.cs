using CricketScoreManagement.conductMatch;
using CricketScoreManagement.teamComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CricketScoreManagement
{
    public class Program
    {
       // public static IMatch m;
        //public Program(IMatch _m) => m = _m;
        static void Main(string[] args)
        {
            var container = StartUp.ConfigureService();
            var m = container.GetRequiredService<IMatch>();
            m.configure();
            m.playFirstInnings();
            m.playSecondInnings();
            m.result();
        }

       
    }
}
