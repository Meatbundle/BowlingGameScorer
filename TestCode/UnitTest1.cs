using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections.Generic;
using System;
using Xunit;
using BowlingGameScorer.src;

namespace BowlingGameScorer
{
    public class UnitTest1
    {
        [Fact]
        public void test0Frame()
        {
            frame zeroFrame = new frame(0,0);

            Assert.Equal(0, zeroFrame.roll1);
            Assert.Equal(0, zeroFrame.roll2);
        }

        [Fact]
        public void testFrame()
        {
            frame testFrame = new frame(1,2);
            Assert.Equal(1, testFrame.roll1);
            Assert.Equal(2, testFrame.roll2);
        }

        [Theory]
        [InlineData(0,0,0)]
        [InlineData(2,2,4)]
        public void testBasicFrameScores(int roll1, int roll2, int expected)
        {
            List<frame> frameList = new List<frame>()
            {
                new frame(roll1, roll2)
            };
            GameScorer scorer = new GameScorer(frameList);
            Assert.Equal(expected, scorer.scoreFrame(0));
        }

        [Fact]
        public void testSplit()
        {
            List<frame> frameList = new List<frame>()
            {
                new frame(0,10),
                new frame(2,2),
                new frame(3,7),
                new frame(6,4)
            };
            GameScorer scorer = new GameScorer(frameList);
            Assert.Equal(12, scorer.scoreFrame(0));
            Assert.Equal(16, scorer.scoreFrame(2));
        }

        [Fact]
        public void testStrike()
        {
           List<frame> frameList = new List<frame>()
            {
                new frame(10,0),
                new frame(10,0),
                new frame(10,0),
                new frame(1,1)
            };
            GameScorer scorer = new GameScorer(frameList);
            Assert.Equal(30, scorer.scoreFrame(0));
            Assert.Equal(12, scorer.scoreFrame(2));
        }
        
        [Fact]
        public void testStrikeSpare()
        {
           List<frame> frameList = new List<frame>()
            {
                new frame(10,0),
                new frame(0,10),
                new frame(10,0),
                new frame(10,0)
            };
            GameScorer scorer = new GameScorer(frameList);
            Assert.Equal(20, scorer.scoreFrame(0));
            Assert.Equal(20, scorer.scoreFrame(1));
        }
        [Fact]
        public void testPerfectGame()
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
                new frame(10,10),
                new frame(10,0),
            };
            GameScorer scorer = new GameScorer(frameList);
            Assert.Equal(300, scorer.scoreGame());
        }

/*
        [Fact]
        public void testAlmostPerfectGame()
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
            Assert.Equal(289, scorer.scoreGame());
        }

        */
        public int randBetween0and10()
        {
            Random rand = new Random();
            return rand.Next(0,10);
        }
    }
}
