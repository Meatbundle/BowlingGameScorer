using System;
using System.Collections.Generic;

namespace BowlingGameScorer.src
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<frame> frameList = new List<frame>()
            {
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(10,9),
                new frame(1,0)
            };

            GameScorer scorer = new GameScorer(frameList);
            int result =  scorer.scoreGame();
            Console.WriteLine(result);
        }
    }
}
