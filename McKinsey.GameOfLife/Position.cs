using System;

namespace McKinsey.GameOfLife
{
    [Serializable]
    public struct Position
    {
        public int I;
        public int J;
        public Position(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}