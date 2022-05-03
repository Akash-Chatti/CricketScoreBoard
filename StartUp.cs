using CricketScoreManagement.conductMatch;
using CricketScoreManagement.teamComponents;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement
{
    public class StartUp
    {
        public static IServiceProvider ConfigureService()
        {
            var services=new ServiceCollection()
                
                .AddTransient<IPlayer, Player>()
                .AddTransient<ITeam, Team>()
                .AddSingleton<IMatch, Match>()
                .BuildServiceProvider();
            return services;
        }
    }
}
