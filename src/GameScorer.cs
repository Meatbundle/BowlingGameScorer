using System;
using System.Collections.Generic;

namespace BowlingGameScorer.src
{
    public class GameScorer
    {
        List<frame> frameList = new List<frame>();

        public GameScorer(List<frame> frames)
        {
            if (frames.Count > 11)
            {
                Console.WriteLine("Cannot have more than 11 frames.");
            }
            frameList = frames;
        }
        public int scoreFrame(int frameIndex)
        {
            if (frameIndex == 10)                                                       
            {
                return 0;//frameList[10].roll1;                                             
            }
            else if (frameIndex == 9)
            {
                if (frameList[frameIndex].isStrike())
                {
                    return scoreSpare(frameIndex);
                }
            }
            else if (frameIndex == 8)
            {
                if (frameList[frameIndex].isStrike())
                {
                    if (frameList[frameIndex+1].isStrike())
                    {
                        return scoreSingleStrike(frameIndex);
                    }
                }
            }
            else if (frameList[frameIndex].isStrike())                                
            {
                if (frameList[frameIndex + 1].isStrike())
                {
                    return scoreTurkey(frameIndex);
                }
                else 
                {
                    return scoreSingleStrike(frameIndex);
                }
            }
            else if (frameList[frameIndex].isSpare())
            {
                return scoreSpare(frameIndex);
            }

            return frameList[frameIndex].addFrame();        //fallthrough
        }

        public int scoreSpare(int frameIndex)
        {
            return frameList[frameIndex].addFrame() + frameList[frameIndex+1].roll1;
        }

        public int scoreSingleStrike(int frameIndex)
        {
            return frameList[frameIndex].addFrame() + frameList[frameIndex+1].addFrame();
        }

        public int scoreTurkey(int frameIndex)
        {
            return frameList[frameIndex].addFrame() + frameList[frameIndex+1].addFrame() + frameList[frameIndex + 2].roll1; 
        }

        public int scoreGame()
        {
            int results = 0;
            for (int i = 0; i < 10; i++)
            {
                results += scoreFrame(i);
                Console.WriteLine($"After {i+1} frames, the score is {results}.\n");
            }
            return results;
        }

    }
}