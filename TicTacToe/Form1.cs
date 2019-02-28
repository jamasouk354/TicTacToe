using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Pen line = new Pen(Color.Black, 10);
        List<int> lines = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void Graphics(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(line, this.Width * (1 / 3), 10, this.Width * ( 1 / 3 ), this.Height - 10);
        }

        public void CreateLines()
        {
            
        }        
    }
}
