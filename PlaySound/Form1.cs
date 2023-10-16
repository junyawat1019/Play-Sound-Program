using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaySound
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            try
            {
                player.SoundLocation = textBox1.Text;
                player.PlayLooping();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() {Filter="Wav|*.wav",Multiselect=false,ValidateNames=true })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }
        }

    }
}
