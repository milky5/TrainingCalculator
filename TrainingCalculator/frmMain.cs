using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingCalculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            txtInputField.Text = txtInputField.Text.Remove(txtInputField.Text.Length - 1, 1);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCleaEnteredrEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {

        }

        #region 数字ボタンクリック時
        private void btnInput0_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "0";
        }

        private void btnInput1_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "1";
        }

        private void btnInput2_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "2";
        }

        private void btnInput3_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "3";
        }

        private void btnInput4_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "4";
        }

        private void btnInput5_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "5";
        }

        private void btnInput6_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "6";
        }

        private void btnInput7_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "7";
        }

        private void btnInput8_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "8";
        }

        private void btnInput9_Click(object sender, EventArgs e)
        {
            txtInputField.Text += "9";
        }
        #endregion

        private void btnMulti_Click(object sender, EventArgs e)
        {

        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {

        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {

        }

        private void btnSub_Click(object sender, EventArgs e)
        {

        }


    }
}
