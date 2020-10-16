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

        bool turn = true; // true = X false = O
        int turn_count = 0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static void PlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        private void wyjscieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "O";
            else
                b.Text = "X";

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool The_winner = false;

            //poziomo
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                The_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                The_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                The_winner = true;

            //pionowo
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                The_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                The_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                The_winner = true;

            //skosy
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                The_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                The_winner = true;

            if (The_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = player2;
                    o_wins.Text = (Int32.Parse(o_wins.Text) + 1).ToString();
                }
                else
                {
                    winner = player1;
                    x_wins.Text = (Int32.Parse(x_wins.Text) + 1).ToString();
                }                  

                MessageBox.Show(winner + " Wygral!", "Gratulacje!");
            }

            else
            {
                if(turn_count == 9)
                {
                    MessageBox.Show("Remis!", "Ups!");
                    draws.Text = (Int32.Parse(draws.Text) + 1).ToString();
                }

            }

        } // Koniec funkcji

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }

        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }        
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "";
                else
                    b.Text = "";
            }
        }

        private void resetWynikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_wins.Text = "0";
            x_wins.Text = "0";
            draws.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;
        }
    }
}
