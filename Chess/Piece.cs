namespace Chess
{
    public class Piece
    {
        public Color color;
        public bool alive;
        public Pair position;
        public PieceType type;
        public bool wasMoved; // To know if castling is posible
    }
}