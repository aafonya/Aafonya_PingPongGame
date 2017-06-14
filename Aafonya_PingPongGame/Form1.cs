using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aafonya_PingPongGame
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1;

        int xPos;
        int yPos;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void MainMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball1.Visible = true;
            autoMovingElement.Visible = true;
            MoveableElement.Visible = true;
            Create_Timer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball1.Visible = false;
            autoMovingElement.Visible = false;
            MoveableElement.Visible = false;

        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos);
                    p.Left += (e.X - xPos);
                }
            }

        }

        private void Create_Timer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball1.Location = new Point(ball1.Location.X + 5, ball1.Location.Y);

            if (ball1.Location.X > this.Width)
            {
                ball1.Location = new Point(0 - ball1.Width, ball1.Location.Y);
            }
        }

        private void Create_Timer2()
        {
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 500;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            autoMovingElement.Location = new Point(autoMovingElement.Location.X, autoMovingElement.Location.Y + 5);

            if (autoMovingElement.Location.X > this.Width)
            {
                autoMovingElement.Location = new Point(0 - autoMovingElement.Width, autoMovingElement.Location.Y);
            }
        }
    }
}
