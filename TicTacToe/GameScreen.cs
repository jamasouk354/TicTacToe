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
        SolidBrush squareBrush = new SolidBrush(Color.DarkKhaki);
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        List<Squares> sqList = new List<Squares>();

        public GameScreen()
        {
            InitializeComponent();
            Square();
        }
       
        #region Game Controls
        private void GameScreenKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void GameScreenKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //if (leftArrowDown == true)
        }

        private void PaintGame(object sender, PaintEventArgs e)
        {
            //Lines
            e.Graphics.DrawLine(line, (this.Width / 3) + 4, 40, (this.Width / 3) + 4, this.Height - 40);
            e.Graphics.DrawLine(line, (this.Width / 3)*2 - 4, 40, (this.Width / 3)*2 - 4, this.Height - 40);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) + 4, this.Width - 40, (this.Height / 3) + 4);
            e.Graphics.DrawLine(line, 40, (this.Height / 3)*2 - 4, this.Width - 40, (this.Height / 3)*2 - 4);

            //e.Graphics.DrawRectangle(line, 33, 33, 120, 120);
            //e.Graphics.DrawRectangle(line, );
            //e.Graphics.DrawRectangle(line, , 120);

            //XandO Squares
            foreach (Squares sq in sqList)
            {
                e.Graphics.FillRectangle(squareBrush, sq.x, sq.y, sq.size, sq.size);
            }
            this.Refresh();
        }

        public void Square()
        {
            sqList.Add(new Squares(33, 33, 120));
            sqList.Add(new Squares((this.Width / 3) + 22, 33, 120));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, 33, 120));
            sqList.Add(new Squares(33, (this.Height / 2) - 60, 120));
            sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 2) - 60, 120));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, (this.Height / 2) - 60, 120));

        }
    }
}
