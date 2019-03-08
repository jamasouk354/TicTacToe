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
        List<string> XandO = new List<string>();
        PointF[] squares = new PointF[4];

        //List<PointF[]> squares = new List<PointF[]>();

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
            if (upArrowDown == true)
            {
                current++;
                upArrowDown = false;
            }
            if (downArrowDown == true)
            {
                current--;
                downArrowDown = false;
            }
            if (current == 10) { current = 0; }
            if (current == -1) { current = 10; }

            if (spaceDown == true)
            {
                sqList[current].contents = "X";
                spaceDown = false;
            }
            if (bDown == true)
            {
                sqList[current].contents = "O";
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
                e.Graphics.FillPolygon(squareBrush, squares);
            }
            for (int i = 0; i < sqList.Count; i++)
            {
                if (i != current)
                {
                    e.Graphics.DrawRectangle(cBrush, sqList[current].x, sqList[current].y, 120, 120);                    
                }                
            }
            foreach (Squares sq in sqList)
            {
                if (sqList[current].contents == "X")
                {
                    e.Graphics.DrawLine(cBrush, sqList[current].x + 5, sqList[current].y + 5, sqList[current].x + 115, sqList[current].y + 115);
                    e.Graphics.DrawLine(cBrush, sqList[current].x + 115, sqList[current].y + 5, sqList[current].x + 5, sqList[current].y + 115);
                }
                else if (sqList[current].contents == "O")
                {
                    e.Graphics.DrawEllipse(cBrush, sqList[current].x + 5, sqList[current].y + 5, 110, 110);
                }
            }
        }

        /// <summary>
        /// Create Squares
        /// </summary>
        public void Square()
        {
            //squares[0] = new PointF(33, 33);
            //squares[1] = new PointF(153, 33);
            //squares[2] = new PointF(153, 153);
            //squares[3] = new PointF(33, 153);

            squares[0] = new PointF(33 + (156 * 2), 33 + (156 * 2));
            squares[1] = new PointF(153 + (156 * 2), 33 + (156 * 2));
            squares[2] = new PointF(153 + (156 * 2), 153 + (156 * 2));
            squares[3] = new PointF(33 + (156 * 2), 153 + (156 * 2));
            foreach (Squares sq in sqList)
            {
                
            }
            //Top Row
            sqList.Add(new Squares(squares, "empty"));
            sqList.Add(new Squares(squares, "empty"));
            //sqList.Add(new Squares((this.Width / 3) * 2 + 14, 33, 120, "empty"));
            ////Mid Row
            //sqList.Add(new Squares(33, (this.Height / 2) - 60, 120, "empty"));
            //sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 2) - 60, 120, "empty"));
            //sqList.Add(new Squares((this.Width / 3) * 2 + 14, (this.Height / 2) - 60, 120, "empty"));
            ////Bot Row
            //sqList.Add(new Squares(33, (this.Height / 3) * 2 + 14, 120, "empty"));
            //sqList.Add(new Squares((this.Width / 2) - 60, (this.Height / 3) * 2 + 14, 120, "empty"));
            //sqList.Add(new Squares((this.Height / 3) * 2 + 14, (this.Height / 3) * 2 + 14, 120, "empty"));
        }
    }
}