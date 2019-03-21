using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TicTacToe
{
    public partial class GameScreen : UserControl
    {
        Pen line = new Pen(Color.Black, 8);
        SolidBrush squareBrush = new SolidBrush(Color.DarkKhaki);
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, spaceDown;
        public static Random randGen = new Random();
        int playerTurn = randGen.Next(1, 3);
        int win = 0;

        List<Squares> sqList = new List<Squares>();
        PointF[] squares = new PointF[4];

        Player player = new Player(33, 33, 120);

        public GameScreen()
        {
            InitializeComponent();
            Square();
            Cursor.Hide();
        }

        #region Game Controls
        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            foreach (Squares sq in sqList)
            {
                switch (e.KeyCode)
                {
                    //Player 1 Keys
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
                    case Keys.B:
                        bDown = true;
                        break;
                    case Keys.Space:
                        spaceDown = true;
                        break;
                }
            }
        }

        private void GameScreenKeyUp(object sender, KeyEventArgs e)
        {
            foreach (Squares sq in sqList)
            {
                switch (e.KeyCode)
                {
                    //Player 1 Keys
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
                    case Keys.B:
                        bDown = false;
                        break;
                    case Keys.Space:
                        spaceDown = false;
                        break;
                }
            }
        }
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            PlayerMove();

            //Check if the player 1/2 has won
            foreach (Squares sq in sqList)
            {
                if (player.x == sq.x && player.y == sq.y)
                {
                    if (sq.contents == "empty")
                    {
                        if (playerTurn == 1)
                        {
                            if (bDown == true)
                            {
                                sq.contents = "X";
                                playerTurn = 2;
                                bDown = false;
                            }
                            //X
                            //Horizontal Rows
                            if (sqList[0].contents == "X" && sqList[1].contents == "X" && sqList[2].contents == "X"
                                || sqList[3].contents == "X" && sqList[4].contents == "X" && sqList[5].contents == "X"
                                || sqList[6].contents == "X" && sqList[7].contents == "X" && sqList[8].contents == "X"
                                //Vertical Rows
                                || sqList[0].contents == "X" && sqList[3].contents == "X" && sqList[6].contents == "X"
                                || sqList[1].contents == "X" && sqList[4].contents == "X" && sqList[7].contents == "X"
                                || sqList[2].contents == "X" && sqList[5].contents == "X" && sqList[8].contents == "X"
                                //Diagonal Rows
                                || sqList[0].contents == "X" && sqList[4].contents == "X" && sqList[8].contents == "X"
                                || sqList[6].contents == "X" && sqList[4].contents == "X" && sqList[2].contents == "X")
                            {
                                outputLabel.Text = "X Player Wins!";
                                win = 1;
                                gameTimer.Stop();
                            }
                        }
                        else if (playerTurn == 2)
                        {
                            if (spaceDown == true)
                            {
                                sq.contents = "O";
                                playerTurn = 1;
                                spaceDown = false;
                            }
                            //O
                            //Horizontal Rows
                            if (sqList[0].contents == "O" && sqList[1].contents == "O" && sqList[2].contents == "O"
                                || sqList[3].contents == "O" && sqList[4].contents == "O" && sqList[5].contents == "O"
                                || sqList[6].contents == "O" && sqList[7].contents == "O" && sqList[8].contents == "O"
                                //Vertical Rows
                                || sqList[0].contents == "O" && sqList[3].contents == "O" && sqList[6].contents == "O"
                                || sqList[1].contents == "O" && sqList[4].contents == "O" && sqList[7].contents == "O"
                                || sqList[2].contents == "O" && sqList[5].contents == "O" && sqList[8].contents == "O"
                                //Diagonal Rows
                                || sqList[0].contents == "O" && sqList[4].contents == "O" && sqList[8].contents == "O"
                                || sqList[6].contents == "O" && sqList[4].contents == "O" && sqList[2].contents == "O")
                            {
                                outputLabel.Text = "O Player Wins!";
                                win = 2;
                                gameTimer.Stop();
                            }
                        }
                    }
                    else if (sqList[0].contents != "empty" && sqList[1].contents != "empty" && sqList[2].contents != "empty" &&
                                sqList[3].contents != "empty" && sqList[4].contents != "empty" && sqList[5].contents != "empty" &&
                                sqList[6].contents != "empty" && sqList[7].contents != "empty" && sqList[8].contents != "empty")
                    {
                        win = 3;
                    }
                }
            }
            Refresh();
        }

        private void PaintGame(object sender, PaintEventArgs e)
        {
            Pen cPen = new Pen(Color.Black, 6);
            Font drawFont = new Font("Arial", 30, FontStyle.Bold);
            Font dFont = new Font("Arial", 24, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            //Lines
            e.Graphics.DrawLine(line, (this.Width / 3) + 4, 40, (this.Width / 3) + 4, this.Height - 40);
            e.Graphics.DrawLine(line, (this.Width / 3) * 2 - 4, 40, (this.Width / 3) * 2 - 4, this.Height - 40);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) + 4, this.Width - 40, (this.Height / 3) + 4);
            e.Graphics.DrawLine(line, 40, (this.Height / 3) * 2 - 4, this.Width - 40, (this.Height / 3) * 2 - 4);

            //XandO Squares
            foreach (Squares sq in sqList)
            {
                squares[0] = new PointF(0 + sq.x, 0 + sq.y);
                squares[1] = new PointF(120 + sq.x, 0 + sq.y);
                squares[2] = new PointF(120 + sq.x, 120 + sq.y);
                squares[3] = new PointF(0 + sq.x, 120 + sq.y);

                e.Graphics.FillPolygon(squareBrush, squares);
                e.Graphics.DrawRectangle(cPen, player.x, player.y, player.size, player.size);

                if (sq.contents == "X")
                {
                    e.Graphics.DrawLine(cPen, sq.x + 5, sq.y + 5, sq.x + 115, sq.y + 115);
                    e.Graphics.DrawLine(cPen, sq.x + 115, sq.y + 5, sq.x + 5, sq.y + 115);
                }
                else if (sq.contents == "O")
                {
                    e.Graphics.DrawEllipse(cPen, sq.x + 5, sq.y + 5, 110, 110);
                }
            }

            if (win == 1)
            {
                e.Graphics.Clear(Color.Khaki);
                e.Graphics.DrawString("Player 1 wins!", drawFont, drawBrush, (this.Width / 2) - 140, 50);
                e.Graphics.DrawString("Press 'M' to go back to Menu", dFont, drawBrush, (this.Width / 2) - 20, 110);
                e.Graphics.DrawString("Press 'C' to Exit the Game", dFont, drawBrush, (this.Width / 2) - 195, 150);
            }
            if (win == 2)
            {
                e.Graphics.Clear(Color.Khaki);
                e.Graphics.DrawString("Player 2 wins!", drawFont, drawBrush, (this.Width / 2) - 140, 50);
                e.Graphics.DrawString("Press 'M' to go back to Menu", dFont, drawBrush, (this.Width / 2) - 220, 110);
                e.Graphics.DrawString("Press 'C' to Exit the Game", dFont, drawBrush, (this.Width / 2) - 195, 150);
            }
            if (win == 3)
            {
                e.Graphics.Clear(Color.Khaki);
                e.Graphics.DrawString("Tie", drawFont, drawBrush, (this.Width / 2) - 30, 50);
                e.Graphics.DrawString("Press 'M' to go back to Menu", dFont, drawBrush, (this.Width / 2) - 220, 110);
                e.Graphics.DrawString("Press 'C' to Exit the Game", dFont, drawBrush, (this.Width / 2) - 195, 150);
            }
        }

        /// <summary>
        /// Create Squares
        /// </summary>
        public void Square()
        {
            //Top Row
            sqList.Add(new Squares(33, 33, squares, "empty"));
            sqList.Add(new Squares(189, 33, squares, "empty"));
            sqList.Add(new Squares(345, 33, squares, "empty"));
            //Mid Row
            sqList.Add(new Squares(33, 189, squares, "empty"));
            sqList.Add(new Squares(189, 189, squares, "empty"));
            sqList.Add(new Squares(345, 189, squares, "empty"));
            //Bot Row
            sqList.Add(new Squares(33, 345, squares, "empty"));
            sqList.Add(new Squares(189, 345, squares, "empty"));
            sqList.Add(new Squares(345, 345, squares, "empty"));
        }

        public void PlayerMove()
        {
            if (player.x < this.Width && player.x > 0)
            {
                if (leftArrowDown == true)
                {
                    player.x -= 156;
                    leftArrowDown = false;
                }
                if (rightArrowDown == true)
                {
                    player.x += 156;
                    rightArrowDown = false;
                }
            }
            else if (player.x > this.Width) { player.x -= 156; }
            else if (player.x < 0) { player.x += 156; }

            if (player.y < this.Height && player.y > 0)
            {
                if (upArrowDown == true)
                {
                    player.y -= 156;
                    upArrowDown = false;
                }
                if (downArrowDown == true)
                {
                    player.y += 156;
                    downArrowDown = false;
                }
            }
            else if (player.y > this.Height) { player.y -= 156; }
            else if (player.y < 0) { player.y += 156; }
        }
    }
}
