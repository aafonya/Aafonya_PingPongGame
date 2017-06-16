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
        Timer timer1;
        Timer timer2 = new Timer();

        int xPos;
        int yPos;

        int scoreGamer = 0;
        int scoreAuto = 0;

        Level level;

        enum Level { High, Medium, Low};

        public Form1()
        {
            InitializeComponent();
            label1.Text = scoreGamer.ToString(); //bad naming
            label2.Text = scoreAuto.ToString();
            label3.Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ball1.Visible = true;
            autoMovingElement.Visible = true;
            MoveableElement.Visible = true;
            Create_Timer();
            Create_Timer2();

            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints

            OrienttaionY = rInt;
        }

        private void ChangeOrientation()
        {
            OrienttaionY *= -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball1.Visible = false;
            autoMovingElement.Visible = false;
            MoveableElement.Visible = false;

        }

       

        int OrienttaionY = 2;
        int OrienttaionX = 20;
        private void Create_Timer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball1.Location = new Point(ball1.Location.X + OrienttaionX, ball1.Location.Y + OrienttaionY );

            
            if (ball1.Bounds.IntersectsWith(MoveableElement.Bounds))
            {
                scoreGamer += 1;

                if (scoreGamer == 10)
                {
                    timer1.Stop();
                    timer2.Stop();
                    menuStrip1.Visible = true;

                    const string text = "You Win!";
                    const string caption = "Result";
                    MessageBoxButtons buttonsForMessageBox = MessageBoxButtons.OK;
                    MessageBox.Show(text, caption, buttonsForMessageBox);

                    scoreAuto = 0;
                    scoreGamer = 0;
                    label2.Text = scoreAuto.ToString();
                    label1.Text = scoreGamer.ToString();
                }

                label1.Text = scoreGamer.ToString();
                
                ball1.Location = new Point(220, 120);
                Random r = new Random();
                int rInt = r.Next(0, 10);
                OrienttaionY = rInt;
            }
            if (ball1.Bounds.IntersectsWith(autoMovingElement.Bounds))
            {
                scoreAuto += 1;
                if (scoreAuto == 10)
                {
                    timer1.Stop();
                    timer2.Stop();
                    menuStrip1.Visible = true;

                    const string text = "Game over";
                    const string caption = "Result";
                    MessageBoxButtons buttonsForMessageBox = MessageBoxButtons.OK;
                    MessageBox.Show(text, caption, buttonsForMessageBox);

                    scoreAuto = 0;
                    scoreGamer = 0;
                    label2.Text = scoreAuto.ToString();
                    label1.Text = scoreGamer.ToString();
                }
                label2.Text = scoreAuto.ToString();

                ball1.Location = new Point(220, 120);
                Random r = new Random();
                int rInt = r.Next(0, 10);
                OrienttaionY = rInt;
            }
            if (ball1.Location.X  + ball1.Width > this.Width)
            {
                Random r = new Random();
                int rInt = r.Next(0, 10); 
                OrienttaionY = rInt;
                OrienttaionX *= -1;
                
            }
            if (ball1.Location.X < 0)
            {
                Random r = new Random();
                int rInt;
                if (OrienttaionY > 0)
                {
                    rInt = r.Next(0, 10);
                } else
                {
                    rInt = r.Next(0, 10);
                }
                OrienttaionY = rInt;
                OrienttaionX *= -1;
            }
            if (ball1.Location.Y < 0)
            {
                Random r = new Random();
                int rInt = r.Next(0, 10);
                OrienttaionX = rInt;
                OrienttaionY *= -1;
            }
            if (ball1.Location.Y + ball1.Height > this.ClientRectangle.Height)
            {
                Random r = new Random();
                int rInt = r.Next(-10, 0); 
                OrienttaionY = rInt ;
            }
        }

        private void Create_Timer2()
        {
            //timer2.Interval = 200;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
        }

        private bool GoUp = true;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GoUp)
            {
                autoMovingElement.Location = new Point(autoMovingElement.Location.X, autoMovingElement.Location.Y - 20);
            } else
            {
                autoMovingElement.Location = new Point(autoMovingElement.Location.X, autoMovingElement.Location.Y + 20);
            }

            if(autoMovingElement.Location.Y < 0)
            {
                GoUp = false;
            }
            if (autoMovingElement.Location.Y + autoMovingElement.Size.Height > this.Height - 50)
            {
                GoUp = true;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            menuStrip1.Visible = true;
            scoreAuto = 0;
            label2.Text = scoreAuto.ToString();
            scoreGamer = 0;
            label1.Text = scoreGamer.ToString();
        }

        private void MoveableElement_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos);
                }
            }
        }

        private void MoveableElement_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                yPos = e.Y;
            }
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e) //initMethod
        {
            level = Level.High;
            label3.Text = level.ToString();
            label3.Visible = true;
            MoveableElement.Height = 20;
            timer2.Interval = 50;
            menuStrip1.Visible = false;
            
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = Level.Medium;
            label3.Text = level.ToString();
            label3.Visible = true;
            MoveableElement.Height = 60;
            timer2.Interval = 100;
            menuStrip1.Visible = false;
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = Level.Low;
            label3.Text = level.ToString();
            label3.Visible = true;
            MoveableElement.Height = 100;
            timer2.Interval = 200;
            menuStrip1.Visible = false;
        }

       
    }
}
