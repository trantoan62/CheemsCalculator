using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catcal_projekt
{
    public partial class AdsForm : Form
    {
        public AdsForm()
        {
            InitializeComponent();
        }
        String A = "";
        Random ngaunhien = new Random();
        int adsnum = 0;
        private void AdsForm_Load(object sender, EventArgs e)
        {
            adsnum = ngaunhien.Next(1, 4);
            if (adsnum == 1) { Adsnum1(); }
            if (adsnum == 2) { Adsnum2(); }
            if (adsnum == 3) { Adsnum3(); }
        }
        private void Adsnum1()
        {
            this.WMP.Visible = false;
            button1.Visible = false;
            this.P1.Visible = true;
            button2.Visible = true;
            T1.Interval = 275;
        }
        private void Adsnum2()
        {
            this.WMP.Visible = true;
            button1.Visible = true;
            this.P1.Visible = false;
            button2.Visible = false;
            T1.Interval = 1000;
            T1.Enabled = true;
            A = "C:\\Users\\Admin\\Downloads\\TranQuocToan_19146090_tieuluanAPEN\\URLsource\\CheemsDancin.mp4";
            this.WMP.URL = A;
            this.WMP.Ctlcontrols.currentPosition = 0;
            this.WMP.Ctlcontrols.play();
        }
        private void Adsnum3()
        {
            this.WMP.Visible = true;
            button1.Visible = true;
            this.P1.Visible = false;
            button2.Visible = false;
            T1.Interval = 1000;
            T1.Enabled = true;
            A = "C:\\Users\\Admin\\Downloads\\TranQuocToan_19146090_tieuluanAPEN\\URLsource\\CheemsAnimee.mp4";
            this.WMP.URL = A;
            this.WMP.Ctlcontrols.play();
        }
        int n = 6;
        int a = 0;
        private void T1_Tick(object sender, EventArgs e)
        {
            //// Ad 1
            a++;
            if (a == 100000) { a = 0; }
            if (a % 2 == 0) {
                A = "C:\\Users\\Admin\\Downloads\\TranQuocToan_19146090_tieuluanAPEN\\URLsource\\quangcao1.png";
                this.P1.Image = System.Drawing.Bitmap.FromFile(A); }
            if (a % 2 == 1) {
                A = "C:\\Users\\Admin\\Downloads\\TranQuocToan_19146090_tieuluanAPEN\\URLsource\\quangcao2.png";
                this.P1.Image = System.Drawing.Bitmap.FromFile(A); }
            //// Ad 2 3
            if (n > 1) {
                button1.Enabled = false;
                n -= 1;
                this.button1.Text = Convert.ToString(n);
            }
            else if (n == 1) {
                this.button1.Text = "Bỏ qua quảng cáo";
                this.button1.Location = new System.Drawing.Point(342, 463);
                this.button1.Size = new Size(114, 40);
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T1.Enabled = false;
            this.WMP.Ctlcontrols.stop();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            T1.Enabled = false;
            this.Close();
        }
        //
        //// 1 chút nhảm nhí 
        //
        int Aba = 0;
        private void P1_Click(object sender, EventArgs e)
        {
            Aba++;
            if (Aba == 1) {
                MessageBox.Show(" *Đang lái xe chở hàng các thứ* ");
                MessageBox.Show("Ai ném gì trúng kính zị trời!", "Bonk"); }
            if (Aba == 2)  {
                DialogResult hihi = MessageBox.Show("Xin đừng giở ra","Huhu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(hihi == DialogResult.No) {
                    MessageBox.Show("Không bán"); }
            }
            if (Aba == 3) {
                MessageBox.Show("Hàng đi giao, không bán đâu"); }
            if (Aba == 4) {
                MessageBox.Show("Hàng không bán đâu, đừng giở ra");
                MessageBox.Show("Ê ê ê ế...");
            }
            if (Aba == 5) {
                DialogResult hihi = MessageBox.Show("Đã nói là không mà", "Đừng ép cháu", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (hihi == DialogResult.Abort || hihi == DialogResult.Retry || hihi == DialogResult.Ignore)
                {
                    MessageBox.Show("Cháu không phải là nhân viên bán hàng ạ");
                }
            }
            if (Aba == 6) {
                MessageBox.Show("Dạ, nhưng mà ...");
                MessageBox.Show("Nhưng nếu cháu bán thì cháu phải làm thống kê, báo cáo, giải trình, và còn nộp tiền nữa ạ :<");
            }
            if (Aba == 7) {
                MessageBox.Show("..."); }
            if (Aba == 8) {
                MessageBox.Show("...."); }
            if (Aba == 9) {
                MessageBox.Show("Chú ép cháu quá, thôi bán luôn ..."); }
            if (Aba > 9 && Aba < 13)  {
                MessageBox.Show("Uhhh, thôi chú gọi thằng Toàn á @@ hỏi nó bán nhiêu, cháu chịu, cháu chỉ biết chạy code thôi :<",
                                "Không bán đâu!"); }
            if (Aba > 12) {
                MessageBox.Show("Đã nói là không biết giá bán rồi mà :< hmu hmu","Đến đây là hết rồi"); }
        }
    }
}
