using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Chess
{
    public partial class frmChess : Form
    {
        private const int squareSize = 70;
        private const int piecePictureSize = 60;
        private PictureBox activePiece = null;
        private PictureBox killedPiece = null;
        private Player white;
        private Player black;
        private Player turn;
        private bool check;
        private bool checkmate;
        private bool moveMakesYouChecked;
        private IBoard boardInterface;

        public frmChess()
        {
            white = new Player();
            white.color = Color.White;
            black = new Player();
            black.color = Color.Black;
            turn = white; // First player = White
            check = false;
            checkmate = false;
            moveMakesYouChecked = false;
            boardInterface = Factory.GetInstance().GetIBoard();
            boardInterface.InitializeBoardAndPieces(white, black);

            InitializeComponent();
            Size = new Size(BoardEndX() + 40, BoardEndY() + 130);
        }

        private int BoardStartX()
        {
            return 20;
        }

        private int BoardStartY()
        {
            return 20;
        }

        private int BoardEndX()
        {
            return BoardStartX() + squareSize * 8;
        }

        private int BoardEndY()
        {
            return BoardStartY() + squareSize * 8;
        }


        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Pen blackPen = new Pen(System.Drawing.Color.Black);
            Font drawFont = new Font("Arial", 18);
            Brush whiteBrush = new SolidBrush(System.Drawing.Color.Bisque);
            Brush blackBrush = new SolidBrush(System.Drawing.Color.Peru);
            Brush greenBrush = new SolidBrush(System.Drawing.Color.DarkKhaki);
            Brush redBrush = new SolidBrush(System.Drawing.Color.Salmon);
            Brush textBrush = new SolidBrush(System.Drawing.Color.Black);
            Brush currentBrush = whiteBrush;

            Pair activeCell = new Pair(-1, -1);
            if (activePiece != null)  
                activeCell = GetCellAtPoint(activePiece.Location);
            
            Pair kingPosition = new Pair(-1, -1);
            if (check)
            {
                if (turn == white)
                    kingPosition = boardInterface.KingPosition(white);
                else
                    kingPosition = boardInterface.KingPosition(black);
            }

            // Paint grid
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (kingPosition.row == i && kingPosition.column == j)
                        currentBrush = redBrush;
                    
                    else if (i == activeCell.row && j == activeCell.column)
                        currentBrush = greenBrush;
                    
                    else
                    {
                        if ((i + j) % 2 == 0)
                            currentBrush = whiteBrush;
                        else
                            currentBrush = blackBrush;
                    }
                    graphics.FillRectangle(currentBrush, new RectangleF(BoardStartX() + squareSize * j, BoardStartY() + squareSize * i, squareSize, squareSize));
                }


            // Paint posible moves
            if (activePiece != null)
            {
                activeCell = GetCellAtPoint(activePiece.Location);
                Pair piecePosition = GetCellAtPoint(activePiece.Location);
                Piece piece = boardInterface.PieceAtLocation(piecePosition.row, piecePosition.column);
                List<Pair> posibleMoves = boardInterface.PosibleMoves(piece);
                foreach (Pair pair in posibleMoves)
                {
                    if (boardInterface.PieceAtLocation(pair.row, pair.column) == null)
                        graphics.FillEllipse(greenBrush, new RectangleF(BoardStartX() + squareSize * pair.column + squareSize /3, BoardStartY() + squareSize * pair.row + squareSize / 3, squareSize / 3, squareSize / 3));
                    else
                    {
                        PointF[] triangle = new PointF[3];

                        // Up-left triangle
                        triangle[0] = new PointF(BoardStartX() + squareSize * pair.column, BoardStartY() + squareSize * pair.row);
                        triangle[1] = new PointF(BoardStartX() + squareSize * pair.column, BoardStartY() + squareSize * pair.row + squareSize / 4);
                        triangle[2] = new PointF(BoardStartX() + squareSize * pair.column + squareSize / 4, BoardStartY() + squareSize * pair.row);
                        graphics.FillPolygon(greenBrush, triangle);

                        // Up-right triangle
                        triangle[0] = new PointF(BoardStartX() + squareSize * (pair.column + 1), BoardStartY() + squareSize * pair.row);
                        triangle[1] = new PointF(BoardStartX() + squareSize * (pair.column + 1), BoardStartY() + squareSize * pair.row + squareSize / 4);
                        triangle[2] = new PointF(BoardStartX() + squareSize * (pair.column + 1) - squareSize / 4, BoardStartY() + squareSize * pair.row);
                        graphics.FillPolygon(greenBrush, triangle);

                        // Down-left triangle
                        triangle[0] = new PointF(BoardStartX() + squareSize * pair.column, BoardStartY() + squareSize * (pair.row + 1));
                        triangle[1] = new PointF(BoardStartX() + squareSize * pair.column, BoardStartY() + squareSize * (pair.row + 1) - squareSize / 4);
                        triangle[2] = new PointF(BoardStartX() + squareSize * pair.column + squareSize / 4, BoardStartY() + squareSize * (pair.row + 1));
                        graphics.FillPolygon(greenBrush, triangle);

                        // Down-right triangle
                        triangle[0] = new PointF(BoardStartX() + squareSize * (pair.column + 1), BoardStartY() + squareSize * (pair.row + 1));
                        triangle[1] = new PointF(BoardStartX() + squareSize * (pair.column + 1), BoardStartY() + squareSize * (pair.row + 1) - squareSize / 4);
                        triangle[2] = new PointF(BoardStartX() + squareSize * (pair.column + 1) - squareSize / 4, BoardStartY() + squareSize * (pair.row + 1));
                        graphics.FillPolygon(greenBrush, triangle);
                    }
                }
            }

            // Draw text
            if (checkmate)
            {
                RectangleF drawRect = new RectangleF(BoardStartX() + squareSize * 2, BoardEndY() + 30, squareSize * 4, squareSize / 2);
                if (boardInterface.CheckMated(black))
                    graphics.DrawString("Checkmate! White wins!", drawFont, textBrush, drawRect);
                else
                    graphics.DrawString("Checkmate! Black wins!", drawFont, textBrush, drawRect);
            }
            else 
            {
                if (moveMakesYouChecked)
                {
                    RectangleF drawRect = new RectangleF(BoardStartX() + (int)(squareSize *2.5), BoardEndY() + 30, squareSize * 6, squareSize / 2);
                    graphics.DrawString("That move makes you checked!", drawFont, textBrush, drawRect);
                }
                else if (check)
                {
                    RectangleF drawRect = new RectangleF(BoardStartX() + squareSize * 3, BoardEndY() + 30, squareSize * 4, squareSize / 2);
                    graphics.DrawString("Check!", drawFont, textBrush, drawRect);
                }
                if (turn == white)
                {
                    RectangleF drawRect = new RectangleF(BoardStartX(), BoardEndY() + 30, squareSize * 2, squareSize / 2);
                    graphics.DrawString("White's turn", drawFont, textBrush, drawRect);
                }
                else
                {
                    RectangleF drawRect = new RectangleF(BoardStartX(), BoardEndY() + 30, squareSize * 2, squareSize / 2);
                    graphics.DrawString("Black's turn", drawFont, textBrush, drawRect);
                }
            }
        }

        private void Piece_Click(object sender, MouseEventArgs e)
        {
            PictureBox clickedPiece = (PictureBox)sender;
            Pair cell = GetCellAtPoint(clickedPiece.Location);

            if (boardInterface.PieceAtLocation(cell.row, cell.column).color == turn.color)
                activePiece = clickedPiece;

            else if (activePiece != null)
            {
                killedPiece = clickedPiece;
                MovePieceAndChangeTurn(clickedPiece.Location, true);
                activePiece = null;
            }
            Invalidate();
        }

        private void Screen_Click(object sender, MouseEventArgs e)
        {
            if (activePiece != null)
            {
                MovePieceAndChangeTurn(e.Location, false);
                activePiece = null;
            }
        }

        /// <summary>
        /// Given a cell of the grid, returns the coordinates of its upper-left corner
        /// </summary>
        private Point GetCellLocation(Pair cell)
        {
            int X = cell.column * squareSize + BoardStartX();
            int Y = cell.row * squareSize + BoardStartY();
            return new Point(X, Y);
        }

        /// <summary>
        /// Given a cell, returns the coordinates where the picturebox of a piece should be located for it to be centered in that cell
        /// </summary>
        private Point GetPictureLocation(Pair cell)
        {
            Point ret = GetCellLocation(cell);
            ret.X += (squareSize - piecePictureSize) / 2;
            ret.Y += (squareSize - piecePictureSize) / 2;
            return ret;
        }

        /// <summary>
        /// Given a point in the grid, returns the cell that contains it
        /// </summary>
        private Pair GetCellAtPoint(Point location)
        {
            int row = (location.Y - BoardStartY()) / squareSize;
            int col = (location.X - BoardStartX()) / squareSize;
            return new Pair(row, col);
        }

        /// <summary>
        /// Moves the activePiece to the location inputted, detects if a player is under check or checkmate, and changes the turn to the other player.
        /// </summary>
        private void MovePieceAndChangeTurn(Point location, bool kill)
        {
            Pair endPosition = GetCellAtPoint(location);
            Pair piecePosition = GetCellAtPoint(activePiece.Location);

            if (activePiece != null)
            {
                Piece piece = boardInterface.PieceAtLocation(piecePosition.row, piecePosition.column);

                if (boardInterface.IsValidMove(piece, endPosition) && piece.color == turn.color)
                {
                    if (!boardInterface.MoveMakesYouChecked(piece, endPosition, turn))
                    {
                        moveMakesYouChecked = false;

                        // Move piece in display
                        location.X = GetPictureLocation(new Pair(endPosition.row, endPosition.column)).X;
                        location.Y = GetPictureLocation(new Pair(endPosition.row, endPosition.column)).Y;
                        activePiece.Location = location;

                        // Check for castling
                        if (activePiece == whiteKing && Math.Abs(endPosition.column - piecePosition.column) == 2)
                        {                        
                            if (endPosition.column > piecePosition.column)
                                whiteTower2.Location = GetCellLocation(new Pair(7, 4));
                            else
                                whiteTower.Location = GetCellLocation(new Pair(7, 2));
                        }

                        if (activePiece == blackKing && Math.Abs(endPosition.column - piecePosition.column) == 2)
                        {
                            if (endPosition.column > piecePosition.column)
                                blackTower2.Location = GetCellLocation(new Pair(0, 4));
                            else
                                blackTower.Location = GetCellLocation(new Pair(0, 2));
                        }

                        // Kill if needed
                        if (kill)
                        {
                            killedPiece.Visible = false;
                            killedPiece.Enabled = false;
                        }

                        // Move piece in logic
                        boardInterface.Move(piece, endPosition, turn);

                        // Crown if needed
                        if (piece.type == PieceType.Pawn && (endPosition.row == 0 || endPosition.row == 7))
                        {
                            PieceType pieceSelected = GetPieceForCrowning();
                            boardInterface.Crown(piece, turn, pieceSelected);
                            ChangeActivePieceImage(pieceSelected);
                        }

                        // Change turn
                        if (turn.color == Color.White)
                            turn = black;
                        else
                            turn = white;

                        // Check detection
                        if (boardInterface.UnderCheck(turn))
                            Check();
                        else
                            check = false;

                        // Checkmate detection
                        if (boardInterface.CheckMated(white) || boardInterface.CheckMated(black))
                            CheckMate();
                    }
                    else
                        moveMakesYouChecked = true;
                }
                else
                    activePiece = null;

                Invalidate();
            }
        }

        /// <summary>
        /// Opens a dialog for the player to chose a piece type, and returns it
        /// </summary>
        private PieceType GetPieceForCrowning()
        {
            frmCrowning dialog = new frmCrowning();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
                return dialog.pieceSelected;
            else
                return PieceType.Queen;
        }

        /// <summary>
        /// Changes the image of the active piece to the one inputted
        /// </summary>
        private void ChangeActivePieceImage(PieceType pieceSelected)
        {
            ResourceManager rm = Resources.ResourceManager;
            if (turn.color == Color.White)
            {
                switch (pieceSelected)
                {
                    case PieceType.Bishop:
                        activePiece.BackgroundImage = (Image)rm.GetObject("WhiteBishop");
                        break;
                    case PieceType.Tower:
                        activePiece.BackgroundImage = (Image)rm.GetObject("WhiteTower");
                        break;
                    case PieceType.Queen:
                        activePiece.BackgroundImage = (Image)rm.GetObject("WhiteQueen");
                        break;
                    case PieceType.Horse:
                        activePiece.BackgroundImage = (Image)rm.GetObject("WhiteHorse");
                        break;
                    default:
                        activePiece.BackgroundImage = (Image)rm.GetObject("WhiteQueen");
                        break;
                }
            }
            else
            {
                switch (pieceSelected)
                {
                    case PieceType.Bishop:
                        activePiece.BackgroundImage = (Image)rm.GetObject("BlackBishop");
                        break;
                    case PieceType.Tower:
                        activePiece.BackgroundImage = (Image)rm.GetObject("BlackTower");
                        break;
                    case PieceType.Queen:
                        activePiece.BackgroundImage = (Image)rm.GetObject("BlackQueen");
                        break;
                    case PieceType.Horse:
                        activePiece.BackgroundImage = (Image)rm.GetObject("BlackHorse");
                        break;
                    default:
                        activePiece.BackgroundImage = (Image)rm.GetObject("BlackQueen");
                        break;
                }
            }
        }

        private void CheckMate()
        {
            checkmate = true;
            Invalidate();
            Form dialog = new frmGameFinished();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.Yes)
                RestartGame();
            else
                Application.Exit();
        }

        private void Check()
        {
            check = true;
            Invalidate();
        }

        private void RestartGame()
        {
            ResourceManager rm = Resources.ResourceManager;

            // blackHorse            
            blackHorse.Location = GetPictureLocation(new Pair(0, 1));
            blackHorse.Enabled = true;
            blackHorse.Visible = true;            
            // blackHorse2            
            blackHorse2.Location = GetPictureLocation(new Pair(0, 6));
            blackHorse2.Enabled = true;
            blackHorse2.Visible = true;            
            // blackBishop           
            blackBishop.Location = GetPictureLocation(new Pair(0, 2));
            blackBishop.Enabled = true;
            blackBishop.Visible = true;            
            // blackBishop            
            blackBishop2.Location = GetPictureLocation(new Pair(0, 5));
            blackBishop2.Enabled = true;
            blackBishop2.Visible = true;            
            // blackTower           
            blackTower.Location = GetPictureLocation(new Pair(0, 0));
            blackTower.Enabled = true;
            blackTower.Visible = true;
            // blackTower2
            blackTower2.Location = GetPictureLocation(new Pair(0, 7));
            blackTower2.Enabled = true;
            blackTower2.Visible = true;
            // blackKing
            blackKing.Location = GetPictureLocation(new Pair(0, 4));
            blackKing.Enabled = true;
            blackKing.Visible = true;
            // blackQueen
            blackQueen.Location = GetPictureLocation(new Pair(0, 3));
            blackQueen.Enabled = true;
            blackQueen.Visible = true;
            // blackPawn1            
            blackPawn1.Location = GetPictureLocation(new Pair(1, 0));
            blackPawn1.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn1.Enabled = true;
            blackPawn1.Visible = true;
            // blackPawn2            
            blackPawn2.Location = GetPictureLocation(new Pair(1, 1));
            blackPawn2.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn2.Enabled = true;
            blackPawn2.Visible = true;
            // blackPawn3
            blackPawn3.Location = GetPictureLocation(new Pair(1, 2));
            blackPawn3.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn3.Enabled = true;
            blackPawn3.Visible = true;
            // blackPawn4
            blackPawn4.Location = GetPictureLocation(new Pair(1, 3));
            blackPawn4.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn4.Enabled = true;
            blackPawn4.Visible = true;
            // blackPawn5
            blackPawn5.Location = GetPictureLocation(new Pair(1, 4));
            blackPawn5.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn5.Enabled = true;
            blackPawn5.Visible = true;
            // blackPawn6
            blackPawn6.Location = GetPictureLocation(new Pair(1, 5));
            blackPawn6.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn6.Enabled = true;
            blackPawn6.Visible = true;
            // blackPawn7
            blackPawn7.Location = GetPictureLocation(new Pair(1, 6));
            blackPawn7.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn7.Enabled = true;
            blackPawn7.Visible = true;
            // blackPawn8
            blackPawn8.Location = GetPictureLocation(new Pair(1, 7));
            blackPawn8.BackgroundImage = (Image)rm.GetObject("BlackPawn");
            blackPawn8.Enabled = true;
            blackPawn8.Visible = true;
            // whiteHorse
            whiteHorse.Location = GetPictureLocation(new Pair(7, 1));
            whiteHorse.Enabled = true;
            whiteHorse.Visible = true;
            // whiteHorse2
            whiteHorse2.Location = GetPictureLocation(new Pair(7, 6));
            whiteHorse2.Enabled = true;
            whiteHorse2.Visible = true;
            // whiteBishop
            whiteBishop.Location = GetPictureLocation(new Pair(7, 2));
            whiteBishop.Enabled = true;
            whiteBishop.Visible = true;
            // whiteBishop
            whiteBishop2.Location = GetPictureLocation(new Pair(7, 5));
            whiteBishop2.Enabled = true;
            whiteBishop2.Visible = true;
            // whiteTower
            whiteTower.Location = GetPictureLocation(new Pair(7, 0));
            whiteTower.Enabled = true;
            whiteTower.Visible = true;
            // whiteTower2
            whiteTower2.Location = GetPictureLocation(new Pair(7, 7));
            whiteTower2.Enabled = true;
            whiteTower2.Visible = true;
            // whiteKing
            whiteKing.Location = GetPictureLocation(new Pair(7, 4));
            whiteKing.Enabled = true;
            whiteKing.Visible = true;
            // whiteQueen
            whiteQueen.Location = GetPictureLocation(new Pair(7, 3));
            whiteQueen.Enabled = true;
            whiteQueen.Visible = true;
            // whitePawn1
            whitePawn1.Location = GetPictureLocation(new Pair(6, 0));
            whitePawn1.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn1.Enabled = true;
            whitePawn1.Visible = true;
            // whitePawn2
            whitePawn2.Location = GetPictureLocation(new Pair(6, 1));
            whitePawn2.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn2.Enabled = true;
            whitePawn2.Visible = true;
            // whitePawn3
            whitePawn3.Location = GetPictureLocation(new Pair(6, 2));
            whitePawn3.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn3.Enabled = true;
            whitePawn3.Visible = true;
            // whitePawn4
            whitePawn4.Location = GetPictureLocation(new Pair(6, 3));
            whitePawn4.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn4.Enabled = true;
            whitePawn4.Visible = true;
            // whitePawn5
            whitePawn5.Location = GetPictureLocation(new Pair(6, 4));
            whitePawn5.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn5.Enabled = true;
            whitePawn5.Visible = true;
            // whitePawn6          
            whitePawn6.Location = GetPictureLocation(new Pair(6, 5));
            whitePawn6.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn6.Enabled = true;
            whitePawn6.Visible = true;
            // whitePawn7
            whitePawn7.Location = GetPictureLocation(new Pair(6, 6));
            whitePawn7.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn7.Enabled = true;
            whitePawn7.Visible = true;
            // whitePawn8
            whitePawn8.Location = GetPictureLocation(new Pair(6, 7));
            whitePawn8.BackgroundImage = (Image)rm.GetObject("WhitePawn");
            whitePawn8.Enabled = true;
            whitePawn8.Visible = true;

            white = new Player();
            white.color = Color.White;
            black = new Player();
            black.color = Color.Black;
            turn = white; // First player = White
            check = false;
            checkmate = false;
            moveMakesYouChecked = false;
            boardInterface.InitializeBoardAndPieces(white, black);
            Invalidate();
        }
    }
}