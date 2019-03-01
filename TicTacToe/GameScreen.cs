using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameScreen : UserControl
    {
        Pen line = new Pen(Color.Black, 8);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void PaintGame(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(line, (this.Width / 3) + 4, 40, (this.Width / 3) + 4, this.Height - 40);
            e.Graphics.DrawLine(line, (this.Width / 3)*2 - 4, 40, (this.Width / 3)*2 - 4, this.Height - 40);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) + 4, this.Width - 40, (this.Height / 3) + 4);
            e.Graphics.DrawLine(line, 40, (this.Height / 3)*2 - 4, this.Width - 40, (this.Height / 3)*2 - 4);
        }
    }
}
