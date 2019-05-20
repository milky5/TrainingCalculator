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
    /// <summary>
    /// 値1と値2を計算させるのに、加減乗除のどの計算を適応するかを保持するデリゲート 
    /// </summary>
    /// <param name="a"> 値1 </param>
    /// <param name="b"> 値2 </param>
    /// <returns> 計算の答え </returns>
    public delegate double Calc(double a, double b);

    public partial class frmMain : Form
    {
        #region メンバ変数
        private double m_calculateAnswer;
        private Calc m_NextCalculation;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// [+]ボタンが押された際に加算するメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Calculate((double a, double b) => a + b);
        }

        /// <summary>
        /// [BackSpace]ボタンが押された際に文字列の末尾を削除するメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            var _inputedText = txtInputField.Text;
            // 1文字以上入力されていたら
            if (_inputedText.Length > 0)
            {
                //文字列の最後の1字だけ削除する
                _inputedText = _inputedText.Remove(_inputedText.Length - 1);
                txtInputField.Text = _inputedText;
            }
        }

        /// <summary>
        /// [=]ボタンが押された際に計算するメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double _convertedNumber;
            var result = double.TryParse(txtInputField.Text, out _convertedNumber);
            if (!result)
            {
                MessageBox.Show("入力された値が正しくありません。");
                return;
            }
            txtInputField.Text = m_NextCalculation(m_calculateAnswer, _convertedNumber).ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCleaEnteredrEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Calculate((double a, double b) => a / b);
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
            Calculate((double a, double b) => a * b);
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {

        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {

        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Calculate((double a, double b) => a - b);
        }


        private void Calculate(Calc calc)
        {
            double _convertedNumber;
            var result = double.TryParse(txtInputField.Text, out _convertedNumber);
            if (!result)
            {
                MessageBox.Show("入力された値が正しくありません。");
                return;
            }
            // デリゲートがnullだったら、Addメソッドを入れる
            if (m_NextCalculation == null)
            {
                m_calculateAnswer = _convertedNumber;
            }
            else
            {
                m_calculateAnswer = m_NextCalculation(m_calculateAnswer, _convertedNumber);
            }

            m_NextCalculation = calc;

            lblInputHistory.Text += _convertedNumber.ToString();
            lblInputHistory.Text += " ";
            txtInputField.Text = null;
        }
    }
}
