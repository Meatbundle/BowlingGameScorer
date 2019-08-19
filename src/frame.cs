namespace BowlingGameScorer.src
{
    public class frame
    {
        public int roll1 {get; set;}
        public int roll2 {get; set;}
        public frame(int r1, int r2)
        {
            roll1 = r1;
            roll2 = r2;
        }
        public bool isStrike()
        {
            if (roll1 == 10) return true;
            return false;
        }
        
        public bool isSpare()
        {
            if (roll1 != 10 && roll1 + roll2 == 10)
            {
                return true;
            }
            return false;
        }
        public int addFrame()
        {
            return roll1 + roll2;
        }
    }
}