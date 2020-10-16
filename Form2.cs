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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Form1.PlayerNames(player1.Text, player2.Text);
            this.Close();
        }
    }
}
