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
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, bDown;
        int current = 0;

        List<Squares> sqList = new List<Squares>();
        List<Points> sqPoints = new List<Points>();
        List<string> XandO = new List<string>();


        public GameScreen()
        {
            InitializeComponent();
            Square();
        }

        

        #region Game Controls
        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            foreach (Squares sq in sqList)
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
                    case Keys.B:
                        bDown = true;
                        break;
                }                                
            }               
        }

        private void GameScreenKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                upArrowDown = downArrowDown = leftArrowDown = rightArrowDown = spaceDown = bDown = false;
            }            
        }

        private void GameScreenKeyUp(object sender, KeyEventArgs e)
        {
            foreach (Squares sq in sqList)
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
                    case Keys.B:
                        bDown = false;
                        break;
                }
            }           
        }
        #endregion
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (spaceDown == true)
            {
                sqList[4].contents = "X";
                spaceDown = false;
            }
            if (bDown == true)
            {
                sqList[4].contents = "O";
                bDown = false;
            }

            Refresh();
        }
        private void PaintGame(object sender, PaintEventArgs e)
        {
            Pen cBrush = new Pen(Color.Black, 6);
            //Lines
            e.Graphics.DrawLine(line, (this.Width / 3) + 4, 40, (this.Width / 3) + 4, this.Height - 40);
            e.Graphics.DrawLine(line, (this.Width / 3) * 2 - 4, 40, (this.Width / 3) * 2 - 4, this.Height - 40); 
            e.Graphics.DrawLine(line, 40, (this.Height / 3) + 4, this.Width - 40, (this.Height / 3) + 4);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) * 2 - 4, this.Width - 40, (this.Height / 3) * 2 - 4);

            //XandO Squares
            foreach (Squares sq in sqList)
            {
                e.Graphics.FillRectangle(squareBrush, sq.x, sq.y, sq.size, sq.size);

               
                //foreach (string xo in XandO)
                //{
                //    if (xo == "x")
                //    {
                //        label1.Text = "x";
                //        e.Graphics.DrawLine(cBrush, sq.x + 5, sq.y + 5, sq.x + sq.size - 5, sq.y + sq.size - 5);
                //        e.Graphics.DrawLine(cBrush, sq.x + sq.size - 5, sq.y + 5, sq.x + 5, sq.y + sq.size - 5);
                //    }
                //    else if (xo == "o")
                //    {
                //        label1.Text = "o";
                //        e.Graphics.DrawEllipse(cBrush, sq.x + 5, sq.y + 5, sq.size - 10, sq.size - 10);
                //    }
                //}
                //e.Graphics.DrawRectangle(cBrush, )
            }
            foreach (Squares sq in sqList)
            {
                if (sq.contents == "X")
                {
                    e.Graphics.DrawLine(cBrush, sq.x + 5, sq.y + 5, sq.x + sq.size - 5, sq.y + sq.size - 5);
                    e.Graphics.DrawLine(cBrush, sq.x + sq.size - 5, sq.y + 5, sq.x + 5, sq.y + sq.size - 5);
                }
                else if (sq.contents == "O")
                {
                    e.Graphics.DrawEllipse(cBrush, sq.x + 5, sq.y + 5, sq.x + sq.size - 5, sq.y + sq.size - 5);
                }
            }
        }

        /// <summary>
        /// Create Squares
        /// </summary>
        public void Square()
        {
            //Top Row
            sqList.Add(new Squares(33, 33, 120, "empty"));
            sqList.Add(new Squares((this.Width / 3) + 22, 33, 120, "empty"));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, 33, 120, "empty"));
            //Mid Row
            sqList.Add(new Squares(33, (this.Height / 2) - 60, 120, "empty"));
            sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 2) - 60, 120, "empty"));
            sqList.Add(new Squares((this.Width / 3) * 2 + 14, (this.Height / 2) - 60, 120, "empty"));
            //Bot Row
            sqList.Add(new Squares(33, (this.Height / 3) * 2 + 14, 120, "empty"));
            sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 3) * 2 + 14, 120, "empty"));
            sqList.Add(new Squares((this.Height / 3) * 2 + 14, (this.Height / 3) * 2 + 14, 120, "empty"));

            //Point point1 = new Point(33, this.Height / 3) * 2 + 14);
        }
    }
}
