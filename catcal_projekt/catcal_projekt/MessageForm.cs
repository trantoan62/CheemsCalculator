using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace catcal_projekt
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; //// xóa dấu X góc trái trên
        }

        int n = 0;
        int a = 0;
        private void TimerNhay_Tick(object sender, EventArgs e)
        {
            n++;
            if (n % 2 == 0) {
                LabelError.Visible = true; }
            else if (n % 2 == 1) {
                LabelError.Visible = false; }
            if (n == 10000000) {
                n = 0; } //// Đỡ nặng thôi
            if (n == a + 4) {
                button2.Text = "Hmu hmu :(";
                this.BackgroundImage = global::catcal_projekt.Properties.Resources.cheembonk;
            }                 //// do file âm thanh hơi trễ nên mình phải code lên đây cho hay
            if (n == a + 6) {
                button2.Text = "Đừng ấn";
                this.BackgroundImage = global::catcal_projekt.Properties.Resources.cheemonly;
            }
            if (n == a + 9) {
                button1.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SoundPlayer bonk = new SoundPlayer(catcal_projekt.Properties.Resources.bonk);
        private void button2_Click(object sender, EventArgs e)
        {
            bonk.Play();
            a = n; //// a ở đây có vai trò như 1 Task.Delay()
            button1.Visible = false;
        }
    }
}
