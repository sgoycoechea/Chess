using System.Windows.Forms;
using System.Resources;
using Chess.Properties;

namespace Chess
{
    partial class frmChess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.whiteHorse = new System.Windows.Forms.PictureBox();
            this.whiteHorse2 = new System.Windows.Forms.PictureBox();
            this.whiteBishop = new System.Windows.Forms.PictureBox();
            this.whiteBishop2 = new System.Windows.Forms.PictureBox();
            this.whiteTower = new System.Windows.Forms.PictureBox();
            this.whiteTower2 = new System.Windows.Forms.PictureBox();
            this.whiteKing = new System.Windows.Forms.PictureBox();
            this.whiteQueen = new System.Windows.Forms.PictureBox();
            this.whitePawn1 = new System.Windows.Forms.PictureBox();
            this.whitePawn2 = new System.Windows.Forms.PictureBox();
            this.whitePawn3 = new System.Windows.Forms.PictureBox();
            this.whitePawn4 = new System.Windows.Forms.PictureBox();
            this.whitePawn5 = new System.Windows.Forms.PictureBox();
            this.whitePawn6 = new System.Windows.Forms.PictureBox();
            this.whitePawn7 = new System.Windows.Forms.PictureBox();
            this.whitePawn8 = new System.Windows.Forms.PictureBox();

            this.blackHorse = new System.Windows.Forms.PictureBox();
            this.blackHorse2 = new System.Windows.Forms.PictureBox();
            this.blackBishop = new System.Windows.Forms.PictureBox();
            this.blackBishop2 = new System.Windows.Forms.PictureBox();
            this.blackTower = new System.Windows.Forms.PictureBox();
            this.blackTower2 = new System.Windows.Forms.PictureBox();
            this.blackKing = new System.Windows.Forms.PictureBox();
            this.blackQueen = new System.Windows.Forms.PictureBox();
            this.blackPawn1 = new System.Windows.Forms.PictureBox();
            this.blackPawn2 = new System.Windows.Forms.PictureBox();
            this.blackPawn3 = new System.Windows.Forms.PictureBox();
            this.blackPawn4 = new System.Windows.Forms.PictureBox();
            this.blackPawn5 = new System.Windows.Forms.PictureBox();
            this.blackPawn6 = new System.Windows.Forms.PictureBox();
            this.blackPawn7 = new System.Windows.Forms.PictureBox();
            this.blackPawn8 = new System.Windows.Forms.PictureBox();

            ResourceManager rm = Resources.ResourceManager;

            this.SuspendLayout();

            #region Pieces

            // 
            // blackHorse
            // 
            this.blackHorse.BackColor = System.Drawing.Color.Transparent;
            this.blackHorse.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackHorse");
            this.blackHorse.Location = this.GetPictureLocation(new Pair(0, 1));
            this.blackHorse.Size = new System.Drawing.Size(60, 60);
            this.blackHorse.TabStop = false;
            this.blackHorse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackHorse2
            // 
            this.blackHorse2.BackColor = System.Drawing.Color.Transparent;
            this.blackHorse2.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackHorse");
            this.blackHorse2.Location = this.GetPictureLocation(new Pair(0, 6));
            this.blackHorse2.Size = new System.Drawing.Size(60, 60);
            this.blackHorse2.TabStop = false;
            this.blackHorse2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackBishop
            // 
            this.blackBishop.BackColor = System.Drawing.Color.Transparent;
            this.blackBishop.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackBishop");
            this.blackBishop.Location = this.GetPictureLocation(new Pair(0, 2));
            this.blackBishop.Size = new System.Drawing.Size(60, 60);
            this.blackBishop.TabStop = false;
            this.blackBishop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackBishop
            // 
            this.blackBishop2.BackColor = System.Drawing.Color.Transparent;
            this.blackBishop2.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackBishop");
            this.blackBishop2.Location = this.GetPictureLocation(new Pair(0, 5));
            this.blackBishop2.Size = new System.Drawing.Size(60, 60);
            this.blackBishop2.TabStop = false;
            this.blackBishop2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackTower
            // 
            this.blackTower.BackColor = System.Drawing.Color.Transparent;
            this.blackTower.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackTower");
            this.blackTower.Location = this.GetPictureLocation(new Pair(0, 0));
            this.blackTower.Size = new System.Drawing.Size(60, 60);
            this.blackTower.TabStop = false;
            this.blackTower.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackTower2
            // 
            this.blackTower2.BackColor = System.Drawing.Color.Transparent;
            this.blackTower2.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackTower");
            this.blackTower2.Location = this.GetPictureLocation(new Pair(0, 7));
            this.blackTower2.Size = new System.Drawing.Size(60, 60);
            this.blackTower2.TabStop = false;
            this.blackTower2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackKing
            // 
            this.blackKing.BackColor = System.Drawing.Color.Transparent;
            this.blackKing.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackKing");
            this.blackKing.Location = this.GetPictureLocation(new Pair(0, 4));
            this.blackKing.Size = new System.Drawing.Size(60, 60);
            this.blackKing.TabStop = false;
            this.blackKing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackQueen
            // 
            this.blackQueen.BackColor = System.Drawing.Color.Transparent;
            this.blackQueen.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackQueen");
            this.blackQueen.Location = this.GetPictureLocation(new Pair(0, 3));
            this.blackQueen.Size = new System.Drawing.Size(60, 60);
            this.blackQueen.TabStop = false;
            this.blackQueen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn1
            // 
            this.blackPawn1.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn1.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn1.Location = this.GetPictureLocation(new Pair(1, 0));
            this.blackPawn1.Size = new System.Drawing.Size(60, 60);
            this.blackPawn1.TabStop = false;
            this.blackPawn1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn2
            // 
            this.blackPawn2.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn2.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn2.Location = this.GetPictureLocation(new Pair(1, 1));
            this.blackPawn2.Size = new System.Drawing.Size(60, 60);
            this.blackPawn2.TabStop = false;
            this.blackPawn2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn3
            // 
            this.blackPawn3.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn3.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn3.Location = this.GetPictureLocation(new Pair(1, 2));
            this.blackPawn3.Size = new System.Drawing.Size(60, 60);
            this.blackPawn3.TabStop = false;
            this.blackPawn3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn4
            // 
            this.blackPawn4.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn4.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn4.Location = this.GetPictureLocation(new Pair(1, 3));
            this.blackPawn4.Size = new System.Drawing.Size(60, 60);
            this.blackPawn4.TabStop = false;
            this.blackPawn4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn5
            // 
            this.blackPawn5.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn5.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn5.Location = this.GetPictureLocation(new Pair(1, 4));
            this.blackPawn5.Size = new System.Drawing.Size(60, 60);
            this.blackPawn5.TabStop = false;
            this.blackPawn5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn6
            // 
            this.blackPawn6.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn6.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn6.Location = this.GetPictureLocation(new Pair(1, 5));
            this.blackPawn6.Size = new System.Drawing.Size(60, 60);
            this.blackPawn6.TabStop = false;
            this.blackPawn6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn7
            // 
            this.blackPawn7.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn7.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn7.Location = this.GetPictureLocation(new Pair(1, 6));
            this.blackPawn7.Size = new System.Drawing.Size(60, 60);
            this.blackPawn7.TabStop = false;
            this.blackPawn7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // blackPawn8
            // 
            this.blackPawn8.BackColor = System.Drawing.Color.Transparent;
            this.blackPawn8.BackgroundImage = (System.Drawing.Image)rm.GetObject("BlackPawn");
            this.blackPawn8.Location = this.GetPictureLocation(new Pair(1, 7));
            this.blackPawn8.Size = new System.Drawing.Size(60, 60);
            this.blackPawn8.TabStop = false;
            this.blackPawn8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);

            // 
            // whiteHorse
            // 
            this.whiteHorse.BackColor = System.Drawing.Color.Transparent;
            this.whiteHorse.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteHorse");
            this.whiteHorse.Location = this.GetPictureLocation(new Pair(7, 1));
            this.whiteHorse.Size = new System.Drawing.Size(60, 60);
            this.whiteHorse.TabStop = false;
            this.whiteHorse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteHorse2
            // 
            this.whiteHorse2.BackColor = System.Drawing.Color.Transparent;
            this.whiteHorse2.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteHorse");
            this.whiteHorse2.Location = this.GetPictureLocation(new Pair(7, 6));
            this.whiteHorse2.Size = new System.Drawing.Size(60, 60);
            this.whiteHorse2.TabStop = false;
            this.whiteHorse2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteBishop
            // 
            this.whiteBishop.BackColor = System.Drawing.Color.Transparent;
            this.whiteBishop.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteBishop");
            this.whiteBishop.Location = this.GetPictureLocation(new Pair(7, 2));
            this.whiteBishop.Size = new System.Drawing.Size(60, 60);
            this.whiteBishop.TabStop = false;
            this.whiteBishop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteBishop
            // 
            this.whiteBishop2.BackColor = System.Drawing.Color.Transparent;
            this.whiteBishop2.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteBishop");
            this.whiteBishop2.Location = this.GetPictureLocation(new Pair(7, 5));
            this.whiteBishop2.Size = new System.Drawing.Size(60, 60);
            this.whiteBishop2.TabStop = false;
            this.whiteBishop2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteTower
            // 
            this.whiteTower.BackColor = System.Drawing.Color.Transparent;
            this.whiteTower.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteTower");
            this.whiteTower.Location = this.GetPictureLocation(new Pair(7, 0));
            this.whiteTower.Size = new System.Drawing.Size(60, 60);
            this.whiteTower.TabStop = false;
            this.whiteTower.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteTower2
            // 
            this.whiteTower2.BackColor = System.Drawing.Color.Transparent;
            this.whiteTower2.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteTower");
            this.whiteTower2.Location = this.GetPictureLocation(new Pair(7, 7));
            this.whiteTower2.Size = new System.Drawing.Size(60, 60);
            this.whiteTower2.TabStop = false;
            this.whiteTower2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteKing
            // 
            this.whiteKing.BackColor = System.Drawing.Color.Transparent;
            this.whiteKing.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteKing");
            this.whiteKing.Location = this.GetPictureLocation(new Pair(7, 4));
            this.whiteKing.Size = new System.Drawing.Size(60, 60);
            this.whiteKing.TabStop = false;
            this.whiteKing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whiteQueen
            // 
            this.whiteQueen.BackColor = System.Drawing.Color.Transparent;
            this.whiteQueen.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhiteQueen");
            this.whiteQueen.Location = this.GetPictureLocation(new Pair(7, 3));
            this.whiteQueen.Size = new System.Drawing.Size(60, 60);
            this.whiteQueen.TabStop = false;
            this.whiteQueen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn1
            // 
            this.whitePawn1.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn1.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn1.Location = this.GetPictureLocation(new Pair(6, 0));
            this.whitePawn1.Size = new System.Drawing.Size(60, 60);
            this.whitePawn1.TabStop = false;
            this.whitePawn1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn2
            // 
            this.whitePawn2.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn2.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn2.Location = this.GetPictureLocation(new Pair(6, 1));
            this.whitePawn2.Size = new System.Drawing.Size(60, 60);
            this.whitePawn2.TabStop = false;
            this.whitePawn2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn3
            // 
            this.whitePawn3.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn3.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn3.Location = this.GetPictureLocation(new Pair(6, 2));
            this.whitePawn3.Size = new System.Drawing.Size(60, 60);
            this.whitePawn3.TabStop = false;
            this.whitePawn3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn4
            // 
            this.whitePawn4.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn4.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn4.Location = this.GetPictureLocation(new Pair(6, 3));
            this.whitePawn4.Size = new System.Drawing.Size(60, 60);
            this.whitePawn4.TabStop = false;
            this.whitePawn4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn5
            // 
            this.whitePawn5.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn5.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn5.Location = this.GetPictureLocation(new Pair(6, 4));
            this.whitePawn5.Size = new System.Drawing.Size(60, 60);
            this.whitePawn5.TabStop = false;
            this.whitePawn5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn6
            // 
            this.whitePawn6.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn6.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn6.Location = this.GetPictureLocation(new Pair(6, 5));
            this.whitePawn6.Size = new System.Drawing.Size(60, 60);
            this.whitePawn6.TabStop = false;
            this.whitePawn6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn7
            // 
            this.whitePawn7.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn7.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn7.Location = this.GetPictureLocation(new Pair(6, 6));
            this.whitePawn7.Size = new System.Drawing.Size(60, 60);
            this.whitePawn7.TabStop = false;
            this.whitePawn7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);
            // 
            // whitePawn8
            // 
            this.whitePawn8.BackColor = System.Drawing.Color.Transparent;
            this.whitePawn8.BackgroundImage = (System.Drawing.Image)rm.GetObject("WhitePawn");
            this.whitePawn8.Location = this.GetPictureLocation(new Pair(6, 7));
            this.whitePawn8.Size = new System.Drawing.Size(60, 60);
            this.whitePawn8.TabStop = false;
            this.whitePawn8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Piece_Click);


            #endregion Pieces

            // 
            // Screen
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.AddRange(new Control[] {
                whiteHorse,
                whiteHorse2,
                whiteBishop,
                whiteBishop2,
                whiteTower,
                whiteTower2,
                whiteQueen,
                whiteKing,
                whitePawn1,
                whitePawn2,
                whitePawn3,
                whitePawn4,
                whitePawn5,
                whitePawn6,
                whitePawn7,
                whitePawn8,
                blackHorse,
                blackHorse2,
                blackBishop,
                blackBishop2,
                blackTower,
                blackTower2,
                blackQueen,
                blackKing,
                blackPawn1,
                blackPawn2,
                blackPawn3,
                blackPawn4,
                blackPawn5,
                blackPawn6,
                blackPawn7,
                blackPawn8,
                 });
            this.Name = "Screen";
            this.Text = "Chess";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Screen_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Screen_Click);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox whiteHorse;
        private System.Windows.Forms.PictureBox whiteHorse2;
        private System.Windows.Forms.PictureBox whiteBishop;
        private System.Windows.Forms.PictureBox whiteBishop2;
        private System.Windows.Forms.PictureBox whiteTower;
        private System.Windows.Forms.PictureBox whiteTower2;
        private System.Windows.Forms.PictureBox whiteQueen;
        private System.Windows.Forms.PictureBox whiteKing;
        private System.Windows.Forms.PictureBox whitePawn1;
        private System.Windows.Forms.PictureBox whitePawn2;
        private System.Windows.Forms.PictureBox whitePawn3;
        private System.Windows.Forms.PictureBox whitePawn4;
        private System.Windows.Forms.PictureBox whitePawn5;
        private System.Windows.Forms.PictureBox whitePawn6;
        private System.Windows.Forms.PictureBox whitePawn7;
        private System.Windows.Forms.PictureBox whitePawn8;

        private System.Windows.Forms.PictureBox blackHorse;
        private System.Windows.Forms.PictureBox blackHorse2;
        private System.Windows.Forms.PictureBox blackBishop;
        private System.Windows.Forms.PictureBox blackBishop2;
        private System.Windows.Forms.PictureBox blackTower;
        private System.Windows.Forms.PictureBox blackTower2;
        private System.Windows.Forms.PictureBox blackQueen;
        private System.Windows.Forms.PictureBox blackKing;
        private System.Windows.Forms.PictureBox blackPawn1;
        private System.Windows.Forms.PictureBox blackPawn2;
        private System.Windows.Forms.PictureBox blackPawn3;
        private System.Windows.Forms.PictureBox blackPawn4;
        private System.Windows.Forms.PictureBox blackPawn5;
        private System.Windows.Forms.PictureBox blackPawn6;
        private System.Windows.Forms.PictureBox blackPawn7;
        private System.Windows.Forms.PictureBox blackPawn8;
    }
}

