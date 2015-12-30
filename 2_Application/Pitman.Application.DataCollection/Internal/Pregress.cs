namespace Pitman.Application.DataCollection
{
    internal class Pregress
    {
        public Pregress(int maxNum, int minNum = 0, int step = 1)
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

        public void Increase()
        {
            this.Current += Step;
        }
    }
}
