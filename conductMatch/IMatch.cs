using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketScoreManagement.conductMatch
{
    public interface IMatch
    {
        public void configure();
        public void playFirstInnings();
        public void playSecondInnings();
        public void result();
    }
}
