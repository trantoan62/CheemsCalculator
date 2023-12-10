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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Code private void thêm vào
        //
        //// void Clicksoundeffect_MouseClick để tạo hiệu ứng âm thanh (WMP hạn chế URL nên em học cách khác chèn URL vào Source luôn)
        SoundPlayer clicksound = new SoundPlayer(catcal_projekt.Properties.Resources.clicksound); //source am thanh
        SoundPlayer bonk = new SoundPlayer(catcal_projekt.Properties.Resources.bonk);
        private void Clicksoundeffect_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickchuot = sender as Button;
            if (clickchuot != null) {
                clicksound.Play(); }
        }

        //// Textchange L2 khi chứa dấu = tại L1 thì xóa L1 như máy casio
        private void EqualsignL1_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickchuot = sender as Button;
            if (clickchuot != null) {
                if (this.L1.Text.Contains("=") == true)  {
                    this.L1.Text = ""; }
            }
        }

        ////void Tinhtoan() dùng để tính các phép toán chứa dấu
        string sign = "";
        double val1 = 0;
        private void Tinhtoan()
        {
            if (sign == "+") { val1 = val1 + Convert.ToDouble(this.L2.Text); }
            if (sign == "-") { val1 = val1 - Convert.ToDouble(this.L2.Text); }
            if (sign == "*") { val1 = val1 * Convert.ToDouble(this.L2.Text); }
            if (sign == "/") { val1 = val1 / Convert.ToDouble(this.L2.Text); }
            if (sign == "=") {
                val1 = Convert.ToDouble(this.L2.Text);
                this.L1.Text = "";
            }
            Kiemtra15kytu(val1); /// dau bang ko co kha nang lam tang ky tu'
            sign = "";
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; } //// sẽ giải thích ở void ThongbaoError()
            this.L1.Text = this.L1.Text + this.L2.Text + " =";
            this.L2.Text = Convert.ToString(Convert.ToDecimal(val1));
        }

        //// void Texttinhtoan() dùng để hiển thị L1, L2 sau void Tinhtoan(), Không gộp chung vì giá trị sign
        
        private void Texttinhtoan()
        {
            val1 = Convert.ToDouble(this.L2.Text);
            this.L1.Text = this.L2.Text + " " + sign + " ";
            this.L2.Text = "0";
        }

        ////void Kiemtra15kytu với ý tưởng làm tròn phần thập phân đủ với 15 ký tự
        int numpart = 1;
        private void Kiemtra15kytu(double giatri)
        {
            if (   giatri >=   Math.Pow(10, 14) && Convert.ToString(giatri).Contains('.') == true
                || giatri >=   Math.Pow(10, 15)
                || giatri <= - Math.Pow(10, 13) && Convert.ToString(giatri).Contains('.') == true
                || giatri <= - Math.Pow(10, 14)
                || Convert.ToString(giatri) == "NaN")
            {
                ThongbaoError();
                return; ////(tránh infinity) và vì dấu . và - cũng tính 1 ký tự
            } 
            else if (giatri < Math.Pow(10, 15) && giatri > -Math.Pow(10, 14))
            {
                numpart = Convert.ToString(Math.Floor(Math.Abs(giatri))).Length;
                if (Convert.ToString(giatri).Contains('.') == true) { numpart++; }
                if (Convert.ToString(giatri).Contains('-') == true) { numpart++; }
                giatri = Math.Round(giatri, 15 - numpart);
            }           //// 15 - numpart là phần ký tự thập phân còn lại có thể hiển thị trên L2
            if (giatri < 0.000000000001) {
                giatri = 0;
            }
        }

        ////void ThongbaoError() hiển thị khi có lỗi dù chỉ dùng vài lần
        MessageForm ErrorForm;
        private void ThongbaoError()
        {
            this.L1.Text = "Cậu đi mà tự tính 1 mình đi";
            this.L2.Text = "0";
            //// Giải thích những dòng "if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi"){}" 
            // là vì mình muốn dừng mọi lệnh sau khi báo lỗi 
            bonk.Play();
            ErrorForm = new MessageForm();
            ErrorForm.Location = new Point(this.Location.X, this.Location.Y + 185);
            ErrorForm.ShowDialog();
        } 

        ////void Tinhval2() để thực hiện các lệnh tính toán ở 2 dòng trên
        string trangthai = "";
        double val2 = 0;
        double valhienthi = 0;
        private void Tinhval2()
        {
            valhienthi = Convert.ToDouble(this.L2.Text);
            if (trangthai == "sqrt")    { val2 = Math.Sqrt(valhienthi); }
            if (trangthai == "sin")     { val2 = Math.Sin(numx*valhienthi); }
            if (trangthai == "cos")     { val2 = Math.Cos(numx*valhienthi); }
            if (trangthai == "tan")     { val2 = Math.Tan(numx*valhienthi); }
            if (trangthai == "inverse") { val2 = 1 / valhienthi; }
            if (trangthai == "cube")    { val2 = valhienthi * valhienthi * valhienthi; }
            if (trangthai == "square")  { val2 = valhienthi * valhienthi; }
            Kiemtra15kytu(val2);
            trangthai = "";
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            this.L2.Text = Convert.ToString(Convert.ToDecimal(val2));
        }
        #endregion

        #region Code các event
        //
        ////number
        private void B1_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "1";
        private void B2_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "2";
        private void B3_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "3";
        private void B4_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "4";
        private void B5_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "5";
        private void B6_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "6";
        private void B7_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "7";
        private void B8_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "8";
        private void B9_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "9";
        private void B0_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "0";
        private void B00_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + "00";
        private void Bdot_Click(object sender, EventArgs e) => this.L2.Text = this.L2.Text + ".";
        ////first column
        private void Bac_Click(object sender, EventArgs e)
        {
            this.L1.Text = "";
            this.L2.Text = "0"; // xoa het du lieu
            val1 = 0; ////em mới bổ sung thêm sau thuyết trình
            val2 = 0; ////em mới bổ sung thêm sau thuyết trình
        }
        private void Bdel_Click(object sender, EventArgs e)
        {
            if (this.L2.Text.Length > 1) {
                this.L2.Text = this.L2.Text.Remove(this.L2.Text.Length - 1, 1);
                return;
            }
            if (this.L2.Text.Length == 1) {
                this.L2.Text = "0"; }   // so co 1 chu so
            if (this.L2.Text.Length == 2 && this.L1.Text.Contains("-") == true) {
                this.L2.Text = "0"; }   // so am co 1 chu so
        } 
        private void Bneg_Click(object sender, EventArgs e)
        {
            if (this.L2.Text.Contains('-') == false) {
                if (this.L2.Text.Length == 15 && this.L2.Text.Contains('.') == false) {
                    ThongbaoError();
                    return;
                }           // do mình muốn max 15 ký tự, chứa dấu - sẽ làm sai số
                else {
                    valhienthi = Convert.ToDouble(this.L2.Text);
                    Kiemtra15kytu(val1);
                    this.L2.Text = "-" + Convert.ToString(Convert.ToDecimal(valhienthi));
                }
            }
            else if (this.L2.Text.Contains('-') == true) {
                this.L2.Text = this.L2.Text.Remove(0, 1); }
        }
        ////textchanged
        private void L1_TextChanged(object sender, EventArgs e) {}
        private void L2_TextChanged(object sender, EventArgs e)
        {
            ////dot
            if (this.L2.Text.Contains('.') == true) {
                this.Bdot.Enabled = false; }
            else if (this.L2.Text.Contains('.') == false) {
                this.Bdot.Enabled = true; }
            //// thay đổi kí tự khi L2 = 0
            if (this.L2.Text.Length == 2 && this.L2.Text.Substring(0, 1) == "0"
                && this.L2.Text.Substring(1, 1) != ".")
            {
                this.L2.Text = this.L2.Text.Remove(0, 1);
            }
            /// thay đổi kí tự khi L2 = 0 và ấn Bneg
            if (this.L2.Text.Length == 3 && this.L2.Text.Substring(0, 2) == "-0" 
                && this.L2.Text.Substring(2, 1) != ".")
            {
                this.L2.Text = this.L2.Text.Remove(1, 1);
            }
            ////B00 & B0
            if (this.L2.Text.Length == 1 && this.L2.Text.Substring(0, 1) == "0") {
                this.B00.Enabled = false;
                this.B0.Enabled = false;
            }
            else if (this.L2.Text.Substring(0, 1) != "0" || this.L2.Text.Length > 1) {
                this.B00.Enabled = true;
                this.B0.Enabled = true;
            }
            ////limit
            if (this.L2.Text.Length > 15) {
                this.L2.Text = this.L2.Text.Substring(0, 15); }
        }
        ////button dấu
        private void Bplus_Click(object sender, EventArgs e)
        {
            if (sign != "") { Tinhtoan(); }
            sign = "+";
            Texttinhtoan();
        }
        private void Bminus_Click(object sender, EventArgs e)
        {
            if (sign != "") { Tinhtoan(); }
            sign = "-";
            Texttinhtoan();
        }
        private void Bmult_Click(object sender, EventArgs e)
        {
            if (sign != "") { Tinhtoan(); }
            sign = "*";
            Texttinhtoan();
        }
        private void Bdiv_Click(object sender, EventArgs e)
        {
            if (sign != "") { Tinhtoan(); }
            sign = "/";
            Texttinhtoan();
        }
        //// Dau bang
        AdsForm Quangcao; //// chạy quảng cáo kiếm tiền học lại :')
        int quangcaoo = 0;
        private void Bequal_Click(object sender, EventArgs e)
        {
            quangcaoo++;
            if (quangcaoo % 8 == 7 && quangcaoo < 35) {
                Quangcao = new AdsForm();
                Quangcao.Location = this.Location;
                Quangcao.ShowDialog(); } //// quảng cáo 4 lần thôi, sợ ăn gạch :< 
            if (this.L1.Text == "2021 =") {
                L1.Text = "!! Chúc mừng năm mới !!";
                return;
            }
            if (this.L1.Text == "!! Chúc mừng năm mới !!") {
                L1.Text = "!! Vạn sự như ý !!";
                return;
            }
            if (sign == "") { sign = "="; }
            Tinhtoan();
        }
        ////first row (vì mình muốn tiện lợi khi ấn dấu + - * / sẽ tính luôn thay vì ấn dấu = nên sẽ xét sign)
        private void Bsqrt_Click(object sender, EventArgs e)
        {
            trangthai = "sqrt";
            Tinhval2();
            if (valhienthi < 0 || this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                ThongbaoError();
                return;
            }
            if (sign == "") {
                this.L1.Text = "sqrt(" + Convert.ToString(valhienthi) + ") ="; }
            if (sign != "") {
                Tinhtoan(); }
        }
        private void Bsin_Click(object sender, EventArgs e)
        {
            trangthai = "sin";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "sin(" + Convert.ToString(valhienthi) + ") ="; }
            else if (sign != "") {
                Tinhtoan(); }
        }
        private void Bcos_Click(object sender, EventArgs e)
        {
            trangthai = "cos";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "cos(" + Convert.ToString(valhienthi) + ") ="; }
            else if (sign != "") {
                Tinhtoan(); }
        }
        private void Btan_Click(object sender, EventArgs e)
        {
            trangthai = "tan";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "tan(" + Convert.ToString(valhienthi) + ") ="; }
            else if (sign != "") {
                Tinhtoan(); }
        }
        ////small row 
        private void Binverse_Click(object sender, EventArgs e)
        {
            trangthai = "inverse";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "1/(" + Convert.ToString(valhienthi) + ") ="; }
            else {
                Tinhtoan(); }
        }
        private void Bcube_Click(object sender, EventArgs e)
        {
            trangthai = "cube";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "cube(" + Convert.ToString(valhienthi) + ") ="; }
            else if (sign != "") {
                Tinhtoan(); }
        }
        private void Bsquare_Click(object sender, EventArgs e)
        {
            trangthai = "square";
            Tinhval2();
            if (this.L1.Text == "Cậu đi mà tự tính 1 mình đi") {
                return; }
            if (sign == "") {
                this.L1.Text = "square(" + Convert.ToString(valhienthi) + ") ="; }
            else if (sign != "") {
                Tinhtoan(); }
        }
        double numx = 1;
        private void Rdeg_CheckedChanged(object sender, EventArgs e)
        {
            numx = Math.PI / 180;
        }
        private void Rrad_CheckedChanged(object sender, EventArgs e)
        {
            numx = 1;
        }
        private void Bper_Click(object sender, EventArgs e)
        {
            this.L2.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDouble(this.L2.Text) / 100));
        }
        private void Bround_Click(object sender, EventArgs e)
        {
            this.L2.Text = Convert.ToString(Convert.ToDecimal(Math.Round(Convert.ToDouble(this.L2.Text),4)));
        }
        //
        //// Load này hơi nhiều code xíu ạ
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            this.L2.Text = "0"; //// mục đích là L2.Textchange
            this.Rdeg.Checked = true;
            this.B1.MouseClick += Clicksoundeffect_MouseClick;
            this.B2.MouseClick += Clicksoundeffect_MouseClick;
            this.B3.MouseClick += Clicksoundeffect_MouseClick;
            this.B4.MouseClick += Clicksoundeffect_MouseClick;
            this.B5.MouseClick += Clicksoundeffect_MouseClick;
            this.B6.MouseClick += Clicksoundeffect_MouseClick;
            this.B7.MouseClick += Clicksoundeffect_MouseClick;
            this.B8.MouseClick += Clicksoundeffect_MouseClick;
            this.B9.MouseClick += Clicksoundeffect_MouseClick;
            this.B0.MouseClick += Clicksoundeffect_MouseClick;
            this.B00.MouseClick += Clicksoundeffect_MouseClick;
            this.Bdot.MouseClick += Clicksoundeffect_MouseClick;
            this.Bac.MouseClick += Clicksoundeffect_MouseClick;
            this.Bdel.MouseClick += Clicksoundeffect_MouseClick;
            this.Bneg.MouseClick += Clicksoundeffect_MouseClick;
            this.Bplus.MouseClick += Clicksoundeffect_MouseClick;
            this.Bminus.MouseClick += Clicksoundeffect_MouseClick;
            this.Bmult.MouseClick += Clicksoundeffect_MouseClick;
            this.Bdiv.MouseClick += Clicksoundeffect_MouseClick;
            this.Bequal.MouseClick += Clicksoundeffect_MouseClick;
            this.Bsqrt.MouseClick += Clicksoundeffect_MouseClick;
            this.Bsin.MouseClick += Clicksoundeffect_MouseClick;
            this.Bcos.MouseClick += Clicksoundeffect_MouseClick;
            this.Btan.MouseClick += Clicksoundeffect_MouseClick;
            this.Binverse.MouseClick += Clicksoundeffect_MouseClick;
            this.Bcube.MouseClick += Clicksoundeffect_MouseClick;
            this.Bsquare.MouseClick += Clicksoundeffect_MouseClick;
            this.Bper.MouseClick += Clicksoundeffect_MouseClick;
            this.Bround.MouseClick += Clicksoundeffect_MouseClick;
            this.B1.MouseClick += EqualsignL1_MouseClick;
            this.B2.MouseClick += EqualsignL1_MouseClick;
            this.B3.MouseClick += EqualsignL1_MouseClick;
            this.B4.MouseClick += EqualsignL1_MouseClick;
            this.B5.MouseClick += EqualsignL1_MouseClick;
            this.B6.MouseClick += EqualsignL1_MouseClick;
            this.B7.MouseClick += EqualsignL1_MouseClick;
            this.B8.MouseClick += EqualsignL1_MouseClick;
            this.B9.MouseClick += EqualsignL1_MouseClick;
            this.B0.MouseClick += EqualsignL1_MouseClick;
            this.B00.MouseClick += EqualsignL1_MouseClick;
            this.Bdot.MouseClick += EqualsignL1_MouseClick;
            this.Bneg.MouseClick += EqualsignL1_MouseClick;
            this.Bdel.MouseClick += EqualsignL1_MouseClick;
            this.Bper.MouseClick += EqualsignL1_MouseClick;
            this.Bround.MouseClick += EqualsignL1_MouseClick;
        }
        #endregion
    }
}
