using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class frmGameFinished : Form
    {
        public frmGameFinished()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
