using System.Collections.Generic;

namespace Chess
{
    interface IBoard
    {
        void InitializeBoardAndPieces(Player white, Player black);
        bool CheckMated(Player player);
        bool UnderCheck(Player player);
        void Move(Piece piece, Pair moveTo, Player player);
        void Crown(Piece pawn, Player player, PieceType selectedPiece);
        bool MoveMakesYouChecked(Piece piece, Pair moveTo, Player player);
        bool IsValidMove(Piece piece, Pair moveTo);
        Piece PieceAtLocation(int row, int col);
        List<Pair> PosibleMoves(Piece piece);
        Pair KingPosition(Player player);
    }
}
