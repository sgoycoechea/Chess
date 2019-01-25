using System.Windows.Forms;

namespace Chess
{
    public partial class frmCrowning : Form
    {
        public PieceType pieceSelected;

        public frmCrowning()
        {
            InitializeComponent();
        }

        private void btnQueen_Click(object sender, System.EventArgs e)
        {
            pieceSelected = PieceType.Queen;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRook_Click(object sender, System.EventArgs e)
        {
            pieceSelected = PieceType.Tower;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBishop_Click(object sender, System.EventArgs e)
        {
            pieceSelected = PieceType.Bishop;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnKnight_Click(object sender, System.EventArgs e)
        {
            pieceSelected = PieceType.Horse;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
