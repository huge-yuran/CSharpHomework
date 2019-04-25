using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics==null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2, -3 * Math.PI / 4);
            //drawCayleyTree(10, 200, 310, 100, -3*Math.PI / 4);
        }

        private Graphics graphics;
        //double th1 = 30 * Math.PI / 180;
        //double th1 = 45 * Math.PI / 180;
        //double th2 = 20 * Math.PI / 180;
        //double per1 = double.Parse(textBox1.Text);
        //double per2 = double.Parse(textBox2.Text);

        void drawCayleyTree(int n,double x0,double y0,double leng,double tha,double thb)
        {
            double per1 = double.Parse(textBox1.Text);
            double per2 = double.Parse(textBox2.Text);
            double th1 = 0;
            double th2 = 0;
            string angleOne = listBox2.SelectedItem.ToString();
            string angleTwo = listBox3.SelectedItem.ToString();
            switch (angleOne)
            {
                case "20":th1= 20 * Math.PI / 180;break;
                case "30": th1 = 30 * Math.PI / 180;break;
                case "45": th1 = 45 * Math.PI / 180;break;
                default: th1 = 60 * Math.PI / 180;break;
            }
            switch (angleTwo)
            {
                case "20": th2 = 20 * Math.PI / 180; break;
                case "30": th2 = 30 * Math.PI / 180; break;
                case "45": th2 = 45 * Math.PI / 180; break;
                default: th2 = 60 * Math.PI / 180; break;
            }
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(tha);
            double y1 = y0 + leng * Math.Sin(tha);
            double x2 = x0 + leng * Math.Cos(thb);
            double y2 = y0 + leng * Math.Sin(thb);

            //两颗子树的生长点不同，一个是（x1,y1）一个是(x2,y2)
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, tha + th1,tha + th2);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, thb + th1,thb + th2);


        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen penColor=new Pen(Color.Black,1); //画笔颜色
            float brushwidth=float.Parse(textBox3.Text);
            penColor.Width=brushwidth;
            string color = listBox1.SelectedItem.ToString();
            switch (color){
                case "Yellow": penColor = Pens.Yellow; break;
                case "Green":penColor = Pens.Green; break;
                case "Black": penColor = Pens.Black; break;
                case "Red": penColor = Pens.Red; break;
               default: penColor = Pens.Blue; break;
                //default: MessageBox.Show("你没有选择画笔颜色");
            }            
                
            
            graphics.DrawLine(
                penColor,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}