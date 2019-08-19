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
                return frameList[10].roll1;                                             
            }
            else if (frameIndex == 9)
            {
                if (frameList[frameIndex].isStrike())
                {
                    return frameList[frameIndex].addFrame() + frameList[frameIndex+1].roll1;
                }
                else
                {
                    return frameList[frameIndex].addFrame();
                }
            }
            else if (frameIndex == 8)
            {
                if (frameList[frameIndex].isStrike())
                {
                    if (frameList[frameIndex+1].isStrike())
                    {
                        return frameList[frameIndex].addFrame() + frameList[frameIndex+1].roll1+frameList[frameIndex+2].roll1;
                    }
                    else
                    {
                        return frameList[frameIndex].addFrame() + frameList[frameIndex + 1].addFrame();
                    }

                }
                                    else
                    {
                        return frameList[frameIndex].addFrame();
                    }
            }
            else if (frameList[frameIndex].isStrike())                                
            {
                if (frameList[frameIndex + 1].isStrike())
                {
                    return frameList[frameIndex].addFrame() + frameList[frameIndex+1].addFrame() + frameList[frameIndex + 2].roll1;
                }
                else 
                {
                    return frameList[frameIndex].addFrame() + (frameList[frameIndex+1].addFrame());
                }
            }
            else if (frameList[frameIndex].isSpare())
            {
                return frameList[frameIndex].addFrame()+frameList[frameIndex+1].roll1;
            }
            else
            {
                return frameList[frameIndex].addFrame();
            }
        }

        public int scoreGame()
        {
            int results = 0;
            for (int i = 0; i < 11; i++)
            {
                results += scoreFrame(i);
            }
            return results;
        }

    }
}