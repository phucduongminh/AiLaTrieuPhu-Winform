using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    internal class Counters
    {
        public int QuestionIndex { get; set; } = 0;
        public List<int> Indices { get; set; } = new List<int>() { 0 };
        public int QuestionCount { get; set; } = 1;
        public int PrizeCounter { get; set; } = -1;
        public int Time { get; set; } = 0;
        public int MaxTime { get; set; } = 40;
        public bool ButtonStatus { get; set; } = true;
        public List<Label> Labels { get; set; } = new List<Label>();
    }
}
