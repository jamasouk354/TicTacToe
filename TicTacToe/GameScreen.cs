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
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown; 
        int current = 0;

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
                case Keys.Space:
                    spaceDown = true;
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
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < sqList.Count; i++)
            if (upArrowDown == true)
            {
                upArrowDown = false;
            }
            if (leftArrowDown == true)
            {
                leftArrowDown = false;
            }
            if (downArrowDown == true)
            {
                downArrowDown = false;
            }
            if (rightArrowDown == true)
            {
                rightArrowDown = false;
            }

            if (spaceDown == true)
            {

            }

            for (int i = 0; i < sqList.Count; i++)
            {
                
            }
        }

        private void PaintGame(object sender, PaintEventArgs e)
        {
            Pen cBrush = new Pen(Color.Black, 4);
            //Lines
            e.Graphics.DrawLine(line, (this.Width / 3) + 4, 40, (this.Width / 3) + 4, this.Height - 40);
            e.Graphics.DrawLine(line, (this.Width / 3) * 2 - 4, 40, (this.Width / 3) * 2 - 4, this.Height - 40); 
            e.Graphics.DrawLine(line, 40, (this.Height / 3) + 4, this.Width - 40, (this.Height / 3) + 4);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) * 2 - 4, this.Width - 40, (this.Height / 3) * 2 - 4);

            //XandO Squares
            foreach (Square sq in sqList)
            {
                e.Graphics.FillRectangle(squareBrush, sqList[i].x, sqList[i].y, sqList[i].size, sqList[i].size);
                if ( sqList[i].contents == "x")
                {
                    e.Graphics.DrawLine(cBrush, sqList[i].x, sqList[i].y, sqList[i].x + sqList[i].size, sqList[i].y + sqList[i].size);
                    e.Graphics.DrawLine(cBrush, sqList[i].x + sqList[i].size, sqList[i].y + sqList[i].size, sqList[i].x, sqList[i].y);
                }
            }
            Refresh();
        }

        /// <summary>
        /// Create Squares
        /// </summary>
        public void Square()
        {
            //Top Row
            sqList.Add(new Squares(33, 33, 120));
            sqList.Add(new Squares((this.Width / 3) + 22, 33, 120));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, 33, 120));
            //Mid Row
            sqList.Add(new Squares(33, (this.Height / 2) - 60, 120));
            sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 2) - 60, 120));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, (this.Height / 2) - 60, 120));
            //Bot Row
            sqList.Add(new Squares(33, (this.Height / 3) * 2 + 14, 120));
            sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 3) * 2 + 14, 120));
            sqList.Add(new Squares((this.Height / 3) * 2 + 14, (this.Height / 3) * 2 + 14, 120));
        }
    }
}
