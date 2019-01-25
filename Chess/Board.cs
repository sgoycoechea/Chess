using System;
using System.Collections.Generic;

namespace Chess
{
    class Board : IBoard
    {
        private static Piece[,] cells;

        public void InitializeBoardAndPieces(Player white, Player black)
        {
            // Create board3
            cells = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cells[i, j] = null;

            // White pieces
            for (int i = 0; i < 8; i++)
                CreatePiece(PieceType.Pawn, Color.White, 6, i);
            CreatePiece(PieceType.Tower, Color.White, 7, 7);
            CreatePiece(PieceType.Tower, Color.White, 7, 0);
            CreatePiece(PieceType.Bishop, Color.White, 7, 2);
            CreatePiece(PieceType.Bishop, Color.White, 7, 5);
            CreatePiece(PieceType.Horse, Color.White, 7, 1);
            CreatePiece(PieceType.Horse, Color.White, 7, 6);
            CreatePiece(PieceType.Queen, Color.White, 7, 3);
            CreatePiece(PieceType.King, Color.White, 7, 4);

            // Black pieces
            for (int i = 0; i < 8; i++)
                CreatePiece(PieceType.Pawn, Color.Black, 1, i);
            CreatePiece(PieceType.Tower, Color.Black, 0, 7);
            CreatePiece(PieceType.Tower, Color.Black, 0, 0);
            CreatePiece(PieceType.Bishop, Color.Black, 0, 2);
            CreatePiece(PieceType.Bishop, Color.Black, 0, 5);
            CreatePiece(PieceType.Horse, Color.Black, 0, 1);
            CreatePiece(PieceType.Horse, Color.Black, 0, 6);
            CreatePiece(PieceType.Queen, Color.Black, 0, 3);
            CreatePiece(PieceType.King, Color.Black, 0, 4);

            // Assign pieces to players
            white.pieces = new Piece[16];
            for (int i = 0; i < 8; i++)
            {
                white.pieces[i] = cells[6, i];
                white.pieces[i + 8] = cells[7, i];
            }

            black.pieces = new Piece[16];
            for (int i = 0; i < 8; i++)
            {
                black.pieces[i] = cells[0, i];
                black.pieces[i + 8] = cells[1, i];
            }
        }

        /// <summary>
        /// Creates a piece with the inputted properties
        /// </summary>
        public void CreatePiece(PieceType type, Color color, int row, int col)
        {
            Piece newPiece = new Piece();
            newPiece.color = color;
            newPiece.alive = true;
            newPiece.position = new Pair(row, col);
            newPiece.type = type;
            cells[row, col] = newPiece;
        }

        /// <summary>
        /// If the player with the indicated color owns the piece at the indicated position, returns true. 
        /// Otherwise returns false.
        /// </summary>
        public bool PlayerOwnsPiece(Color playerColor, Pair position)
        {
            return (cells[position.row, position.column] != null) && cells[position.row, position.column].color == playerColor;
        }

        /// <summary>
        /// Returns a list containing all the posible moves for the piece inputted
        /// </summary>
        public List<Pair> PosibleMoves(Piece piece)
        {
            List<Pair> result = new List<Pair>();

            switch (piece.type)
            {
                // Pawn
                case PieceType.Pawn:
                    if (piece.color == Color.Black)
                    {
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                // Check for move forward
                                if ((i == piece.position.row + 1) && (j == piece.position.column))
                                    if (cells[i, j] == null)
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);
                                    }

                                // Check for move and kill
                                if ((i == piece.position.row + 1) && ((j == piece.position.column - 1) || (j == piece.position.column + 1)))
                                    if (PlayerOwnsPiece(Color.White, new Pair(i, j)))
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);
                                    }

                                // Check for 2 squares forward
                                if ((i == piece.position.row + 2) && (j == piece.position.column) && piece.position.row == 1)
                                    if (cells[i, j] == null && cells[i - 1, j] == null)
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);
                                    }
                            }
                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                // Check for move forward
                                if ((i == piece.position.row - 1) && (j == piece.position.column))
                                    if (cells[i, j] == null)
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);

                                    }
                                // Check for move and kill
                                if ((i == piece.position.row - 1) && ((j == piece.position.column - 1) || (j == piece.position.column + 1)))
                                    if (PlayerOwnsPiece(Color.Black, new Pair(i, j)))
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);
                                    }
                                // Check for 2 squares forward
                                if ((i == piece.position.row - 2) && (j == piece.position.column) && piece.position.row == 6)
                                    if (cells[i, j] == null && cells[i + 1, j] == null)
                                    {
                                        Pair posibleMove = new Pair(i, j);
                                        result.Add(posibleMove);
                                    }
                            }
                    }
                    break;

                // Horse
                case PieceType.Horse:
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            if ((Math.Abs(piece.position.row - i) == 2 && Math.Abs(piece.position.column - j) == 1) ||
                                   (Math.Abs(piece.position.row - i) == 1 && Math.Abs(piece.position.column - j) == 2))
                                if (cells[i, j] == null || piece.color != cells[i, j].color)
                                {
                                    Pair posibleMove = new Pair(i, j);
                                    result.Add(posibleMove);
                                }
                    break;

                // Bishop
                case PieceType.Bishop:
                    int i1 = piece.position.row;
                    int j1 = piece.position.column;

                    // Down-right path
                    i1 = piece.position.row + 1;
                    j1 = piece.position.column + 1;
                    while (i1 < 8 && j1 < 8 && cells[i1, j1] == null)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                        i1++;
                        j1++;
                    }
                    if (i1 < 8 && j1 < 8 && piece.color != cells[i1, j1].color)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                    };

                    // Down-left path
                    i1 = piece.position.row + 1;
                    j1 = piece.position.column - 1;
                    while (i1 < 8 && j1 >= 0 && cells[i1, j1] == null)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                        i1++;
                        j1--;
                    }
                    if (i1 < 8 && j1 >= 0 && piece.color != cells[i1, j1].color)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                    };

                    // Up-right path
                    i1 = piece.position.row - 1;
                    j1 = piece.position.column + 1;
                    while (i1 >= 0 && j1 < 8 && cells[i1, j1] == null)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                        i1--;
                        j1++;
                    }
                    if (i1 >= 0 && j1 < 8 && piece.color != cells[i1, j1].color)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                    };

                    // Up-left path
                    i1 = piece.position.row - 1;
                    j1 = piece.position.column - 1;
                    while (i1 >= 0 && j1 >= 0 && cells[i1, j1] == null)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                        i1--;
                        j1--;
                    }
                    if (i1 >= 0 && j1 >= 0 && piece.color != cells[i1, j1].color)
                    {
                        Pair posibleMove = new Pair(i1, j1);
                        result.Add(posibleMove);
                    };

                    break;

                // Tower
                case PieceType.Tower:
                    int i2 = piece.position.row;
                    int j2 = piece.position.column;

                    // Check path down
                    i2 = piece.position.row + 1;
                    j2 = piece.position.column;
                    while (i2 < 8 && cells[i2, j2] == null)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                        i2++;
                    }
                    if (i2 < 8 && piece.color != cells[i2, j2].color)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                    };

                    // Check path up
                    i2 = piece.position.row - 1;
                    j2 = piece.position.column;
                    while (i2 >= 0 && cells[i2, j2] == null)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                        i2--;
                    }
                    if (i2 >= 0 && piece.color != cells[i2, j2].color)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                    };

                    // Check path left
                    i2 = piece.position.row;
                    j2 = piece.position.column - 1;

                    while (j2 >= 0 && cells[i2, j2] == null)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                        j2--;
                    }
                    if (j2 >= 0 && piece.color != cells[i2, j2].color)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                    };

                    // Check path right
                    i2 = piece.position.row;
                    j2 = piece.position.column + 1;
                    while (j2 < 8 && cells[i2, j2] == null)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                        j2++;
                    }
                    if (j2 < 8 && piece.color != cells[i2, j2].color)
                    {
                        Pair posibleMove = new Pair(i2, j2);
                        result.Add(posibleMove);
                    };

                    break;

                // King
                case PieceType.King:
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            // Posible positions
                            if ((Math.Abs(i - piece.position.row) == 1 && Math.Abs(j - piece.position.column) <= 1) ||
                                   (Math.Abs(i - piece.position.row) <= 1 && Math.Abs(j - piece.position.column) == 1))
                                // If empty or opposite color piece there
                                if (cells[i, j] == null || piece.color != cells[i, j].color)
                                {
                                    Pair posibleMove = new Pair(i, j);
                                    result.Add(posibleMove);
                                }

                            // Castling
                            if (Math.Abs(j - piece.position.column) == 2 && i == piece.position.row)
                            {
                                if (j > piece.position.column) // King moving right
                                {
                                    if (cells[piece.position.row, 6] == null && cells[piece.position.row, 5] == null && cells[piece.position.row, 4] == null)
                                        if (cells[piece.position.row, 7] != null && cells[piece.position.row, 7].type == PieceType.Tower && cells[piece.position.row, 7].color == piece.color)
                                            if (piece.wasMoved == false && cells[piece.position.row, 7].wasMoved == false)
                                            {
                                                Pair posibleMove = new Pair(i, j);
                                                result.Add(posibleMove);
                                            }
                                }
                                else // King moving left
                                {
                                    if (cells[piece.position.row, 1] == null && cells[piece.position.row, 2] == null)
                                        if (cells[piece.position.row, 0] != null && cells[piece.position.row, 0].type == PieceType.Tower && cells[piece.position.row, 0].color == piece.color)
                                            if (piece.wasMoved == false && cells[piece.position.row, 0].wasMoved == false)
                                            { 
                                                Pair posibleMove = new Pair(i, j);
                                                result.Add(posibleMove);
                                            }
                                }               
                            }
                         }
                    break;

                // Queen
                case PieceType.Queen:
                    // Create a fake tower at the queen's position and get its posible moves
                    Piece fakeTower = new Piece();
                    fakeTower.color = piece.color;
                    fakeTower.type = PieceType.Tower;
                    fakeTower.position = piece.position;
                    // Create a fake bishop at the queen's position and get its posible moves
                    Piece fakeBishop = new Piece();
                    fakeBishop.color = piece.color;
                    fakeBishop.type = PieceType.Bishop;
                    fakeBishop.position = piece.position;
                    // Include both lists of posible moves
                    result = PosibleMoves(fakeTower);
                    result.AddRange(PosibleMoves(fakeBishop));
                    break;
            }
            return result;
        }

        /// <summary>
        /// Returns true if the move is valid and false otherwise
        /// </summary>
        public bool IsValidMove(Piece piece, Pair moveTo)
        {
            List<Pair> posibleMoves = PosibleMoves(piece);
            foreach (Pair posibleMove in posibleMoves)
                if (moveTo == posibleMove)
                    return true;
            return false;
        }

        /// <summary>
        /// Moves the inputted piece, owned by the inputted player, to the inputted position.
        /// Precondition: IsValidMove(piece, moveTo, player)
        /// </summary>
        public void Move(Piece piece, Pair moveTo, Player player)
        {
            // For castling checking
            if (cells[piece.position.row, piece.position.column].type == PieceType.Tower ||
                    cells[piece.position.row, piece.position.column].type == PieceType.King)
                cells[piece.position.row, piece.position.column].wasMoved = true;

            // If there is an enemy piece at the position 'moveTo', kill it
            if (cells[moveTo.row, moveTo.column] != null) cells[moveTo.row, moveTo.column].alive = false;

            // Check for castling
            if (piece.type == PieceType.King && Math.Abs(piece.position.column - moveTo.column)==2)
            {
                if (moveTo.column > piece.position.column) // King moving right
                {
                    // Move king
                    cells[moveTo.row, moveTo.column] = cells[piece.position.row, piece.position.column];
                    cells[moveTo.row, moveTo.column].position = new Pair(moveTo.row, moveTo.column);
                    // Move tower
                    cells[moveTo.row, moveTo.column - 1] = cells[piece.position.row, 7];
                    cells[moveTo.row, moveTo.column - 1].position = new Pair(piece.position.row, moveTo.column - 1);

                    cells[moveTo.row, 7] = null;
                    cells[moveTo.row, 3] = null;
                }
                else // King moving left
                {
                    // Move king
                    cells[moveTo.row, moveTo.column] = cells[piece.position.row, piece.position.column];
                    cells[moveTo.row, moveTo.column].position = new Pair(moveTo.row, moveTo.column);
                    // Move tower
                    cells[moveTo.row, moveTo.column + 1] = cells[piece.position.row, 0];
                    cells[moveTo.row, moveTo.column + 1].position = new Pair(piece.position.row, moveTo.column + 1);

                    cells[moveTo.row, 0] = null;
                    cells[moveTo.row, 3] = null;
                }

                cells[piece.position.row, 3] = null;
            }
            else // No castling
            {
                cells[moveTo.row, moveTo.column] = cells[piece.position.row, piece.position.column];
                cells[piece.position.row, piece.position.column] = null;
                cells[moveTo.row, moveTo.column].position = moveTo;
            }
        }

        /// <summary>
        /// Crown the pawn (change its piece type to the selected one)
        /// </summary>
        public void Crown(Piece pawn, Player player, PieceType selectedPiece)
        {
            cells[pawn.position.row, pawn.position.column].type = selectedPiece;
        }

        /// <summary>
        /// Returns true if the enemy player to the inputted one can move a piece to the inputted position, and returns false otherwise
        /// </summary>
        public bool PositionIsAttackedByEnemyPlayer(Player player, Pair position)
        {
            bool isAttacked = false;
            List<Pair> playerPieceMoves;

            // If there is an enemy piece at the position remove it momentarily
            Piece aux = cells[position.row, position.column];
            if (cells[position.row, position.column] != null && cells[position.row, position.column].color != player.color)
                cells[position.row, position.column] = null;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i, j] != null && cells[i, j].color != player.color)
                    {
                        playerPieceMoves = PosibleMoves(cells[i, j]);
                        foreach (Pair move in playerPieceMoves)
                            if (move == position)
                                isAttacked = true;
                    }
                }

            cells[position.row, position.column] = aux;
            return isAttacked;
        }

        /// <summary>
        /// Returns true if player is under check and false otherwise
        /// </summary>
        public bool UnderCheck(Player player)
        {
            Pair kingPosition = new Pair(-1, -1);
            foreach (Piece piece in player.pieces)
                if (piece.type == PieceType.King)
                    kingPosition = piece.position;

            return PositionIsAttackedByEnemyPlayer(player, kingPosition);
        }

        public Pair KingPosition(Player player)
        {
            Pair kingPosition = new Pair(0, 0);
            foreach (Piece piece in player.pieces)
                if (piece.type == PieceType.King) kingPosition = piece.position;

            return kingPosition;
        }

        /// <summary>
        /// Returns true if moving the inputted piece to the inputted position makes the player checked, and false otherwise
        /// </summary>
        public bool MoveMakesYouChecked(Piece piece, Pair moveTo, Player player)
        {
            bool check = false;
            Pair startingPosition = piece.position;
            Piece aux = cells[moveTo.row, moveTo.column];
            // Protect piece that is where the move is being made
            cells[moveTo.row, moveTo.column] = null;
            // Make move
            cells[piece.position.row, piece.position.column] = null;
            cells[moveTo.row, moveTo.column] = piece;
            piece.position = moveTo;
            // Verify if checked
            check = UnderCheck(player);
            // Undo move
            piece.position = startingPosition;
            cells[startingPosition.row, startingPosition.column] = piece;
            cells[moveTo.row, moveTo.column] = aux;

            return check;
        }

        /// <summary>
        /// Returns true if player is checkmated and false otherwise
        /// </summary>
        public bool CheckMated(Player player)
        {
            bool checkmated = true;
            if (UnderCheck(player))
            {
                foreach (Piece piece in player.pieces)
                    if (piece.alive == true)
                        foreach (Pair move in PosibleMoves(piece))
                            if (!MoveMakesYouChecked(piece, move, player)) checkmated = false;
            }
            else
                checkmated = false;

            return checkmated;
        }

        /// <summary>
        /// Returns the piece at the location (row, col)
        /// </summary>
        public Piece PieceAtLocation(int row, int col)
        {
            return cells[row, col];
        }
    }
}
