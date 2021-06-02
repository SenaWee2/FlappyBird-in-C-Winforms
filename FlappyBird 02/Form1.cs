using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird_02
{
    public partial class Form1 : Form
    {
        
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
           
            label1.Hide();
            label2.Hide();
            flappyBird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            PipeUp.Left -= pipeSpeed;
            Score.Text  = "Score: " + score;

            if (pipeDown.Left < -150)
            {
                pipeDown.Left = 700;
                score++;
            }

            if (PipeUp.Left < -180)
            {
                PipeUp.Left = 850;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) ||
                flappyBird.Bounds.IntersectsWith(PipeUp.Bounds)  || flappyBird.Top < -10 ||
               flappyBird.Bounds.IntersectsWith(ground.Bounds))

            {
                endGame();
                
            }

            if (score > 5 )
            {
                pipeSpeed = 10;
                flappyBird.Width = 60;
                flappyBird.Height = 57;
            }

            if (score > 10)
            {
                pipeSpeed = 13;
                flappyBird.Width = 62;
                flappyBird.Height = 60;
            }

            if (score > 15)
            {
                pipeSpeed = 15;
                flappyBird.Width = 62;
                flappyBird.Height = 60;
            }




        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            { 
                gravity = -11;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 11;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            Score.Text += " Game Over";
            System.Threading.Thread.Sleep(3000);
            label1.Show();
            label2.Show();

            //System.Threading.Thread.Sleep(5000);

            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
            Application.Restart();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
