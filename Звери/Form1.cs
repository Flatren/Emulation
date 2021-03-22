using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Звери
{
    public partial class Form1 : Form
    {
        Field field;
        public Form1()
        {
            InitializeComponent();
            
            field = new Field(pictureBoxField.Size.Width, pictureBoxField.Size.Height);
            field.GenericNewField();
            Bitmap bitmap = new Bitmap(pictureBoxField.Size.Width, pictureBoxField.Size.Height);
            pictureBoxField.Image = bitmap;
            pictureBoxField.Image = (Image)field.GetBitmap((Bitmap)pictureBoxField.Image);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (field != null)
            {
                for (int i = 0; i < 1; i++)
                    field.GladV2();
                pictureBoxField.Image = (Image)field.GetBitmap((Bitmap)pictureBoxField.Image);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            field.sid = int.Parse(textBox1.Text);
            field.deep = int.Parse(textBox2.Text);
            field.max = int.Parse(textBox3.Text);
            field.GenericNewField();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
