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
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Add(gs);
            f.Controls.Remove(this);
            
            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);
            this.Dispose();
        }

        private void StartScreen(object sender, PaintEventArgs e)
        {
            Font dFont = new Font("Arial", 24, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("Once you've read the controls press \nany key to Start the game", dFont, drawBrush, 10, 50);
            e.Graphics.DrawString("Controls", dFont, drawBrush, 10, 100);
        }
    }
}
