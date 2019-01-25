using System;

namespace Chess
{ 
        public enum PieceType { Horse, Bishop, Tower, King, Queen, Pawn }
        public enum Color { White, Black }

        public class Pair
        {
            public int row;
            public int column;

            public Pair(int row, int column)
            {
                this.row = row;
                this.column = column;
            }

        public static bool operator ==(Pair pair1, Pair pair2)
        {
            return pair1.row == pair2.row && pair1.column == pair2.column;
        }

        public static bool operator !=(Pair pair1, Pair pair2)
        {
            return pair1.row != pair2.row || pair1.column != pair2.column;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Pair pair2 = (Pair)obj;
            return row == pair2.row && column == pair2.column;
        }

        // Not implemented
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}    

