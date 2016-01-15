using System;

namespace Pitman.Application.DataCollection
{
    internal class Progress
    {
        public Progress(int maxNum, int minNum = 0, int step = 1)
        {
            this.MaxNum = maxNum;
            this.MinNum = minNum;
            this.Step = step;
            this.Current = minNum;
        }

        public int MaxNum { get; private set; }

        public int MinNum { get; private set; }

        public int Step { get; private set; }

        public int Current { get; private set; }

        public double Value
        {
            get
            {
                if(MaxNum <= 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round((double)Current / MaxNum, 4) * 100;
                }
            }
        }

        public void Increase()
        {
            this.Current += Step;
        }
    }
}
