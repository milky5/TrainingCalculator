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
    /// 加減乗除いずれかの計算を保留しておく
    /// </summary>
    /// <param name="a"> 値1 </param>
    /// <param name="b"> 値2 </param>
    /// <returns> 計算の答え </returns>
    public delegate double Calc(double a, double b);

    public partial class frmMain : Form
    {
        #region メンバ変数
        private double m_calculateAnswer;
        private bool m_isDisplayingAnswer;
        private bool m_isDisplayingFinalAnswer;
        private Calc m_nextCalculation;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            MaximumSize = this.Size;
            MinimumSize = this.Size;
        }

        #region メンバメソッド

        /// <summary>
        /// [+]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 直前の最終答えを、演算に使おうとしていた場合
            if (m_isDisplayingFinalAnswer)
            {
                m_isDisplayingFinalAnswer = false;
                // 直前の演算の途中式をクリアする
                lblInputHistory.Text = null;
            }

            CalculateNumber((double a, double b) => a + b,"+");
        }

        /// <summary>
        /// [BackSpace]ボタンが押された際に文字列の末尾を削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            var _inputedText = txtInputField.Text;
            // 1文字以上入力されていたら
            if (_inputedText.Length > 0)
            {
                // 文字列の最後の1字だけ削除する
                _inputedText = _inputedText.Remove(_inputedText.Length - 1);
                txtInputField.Text = _inputedText;
            }
        }

        /// <summary>
        /// [=]ボタンが押された際に、計算の結果を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 入力された string型を double型に変換する
            double _convertedNumber;
            var result  = double.TryParse(txtInputField.Text, out _convertedNumber);

            // 変換に失敗、または演算記号を押す前に[=]を押した場合、
            // メッセージボックスを表示
            if (!result || m_nextCalculation == null)
            {
                MessageBox.Show("入力された値が正しくありません。");
                return;
            }
            // 変換に成功したら、Textboxに計算結果を表示する
            txtInputField.Text = m_nextCalculation(m_calculateAnswer,
            _convertedNumber).ToString();

            m_isDisplayingFinalAnswer = true;
            m_isDisplayingAnswer = true;
            // 変数を初期化する
            m_calculateAnswer = 0;
            m_nextCalculation = null;

            // Labelに途中式を表示する
            lblInputHistory.Text += _convertedNumber.ToString();
            lblInputHistory.Text += (" " + "=");
        }

        /// <summary>
        /// [C]が押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 表示・変数を初期化する
            txtInputField.Text = "";
            lblInputHistory.Text = "";
            m_calculateAnswer = 0;
            m_nextCalculation = null;
        }

        /// <summary>
        /// [CE]が押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            // テキストボックスのみ初期化する
            txtInputField.Text = "";
        }

        /// <summary>
        /// [÷]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, EventArgs e)
        {
            // 直前の最終答えを、演算に使おうとしていた場合
            if (m_isDisplayingFinalAnswer)
            {
                m_isDisplayingFinalAnswer = false;
                // 直前の演算の途中式をクリアする
                lblInputHistory.Text = null;
            }

            CalculateNumber((double a, double b) => a / b,"/");
        }

        #region 数字ボタンクリック時
        private void btnInput0_Click(object sender, EventArgs e)
        {
            DeleteDisplayAnswer();

            if (txtInputField.Text == "0")
            {
                return;
            }

            txtInputField.Text += "0";
        }

        private void btnInput1_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "1";
        }

        private void btnInput2_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "2";
        }

        private void btnInput3_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "3";
        }

        private void btnInput4_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "4";
        }

        private void btnInput5_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "5";
        }

        private void btnInput6_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "6";
        }

        private void btnInput7_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "7";
        }

        private void btnInput8_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "8";
        }

        private void btnInput9_Click(object sender, EventArgs e)
        {
            if (txtInputField.Text == "0")
            {
                txtInputField.Text = null;
            }

            DeleteDisplayAnswer();
            txtInputField.Text += "9";
        }
        #endregion

        /// <summary>
        /// [×]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            // 直前の最終答えを、演算に使おうとしていた場合
            if (m_isDisplayingFinalAnswer)
            {
                m_isDisplayingFinalAnswer = false;
                // 直前の演算の途中式をクリアする
                lblInputHistory.Text = null;
            }

            CalculateNumber((double a, double b) => a * b,"*");
        }

        /// <summary>
        /// [.]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            // 入力値に既に[.]が含まれていたら何もしない
            if (txtInputField.Text.Contains("."))
            {
                return;
            }
            // 何も入力されていなかったら
            if (txtInputField.Text == "")
            {
                // 先頭に[0.]を追加する
                txtInputField.Text = txtInputField.Text.Insert(0, "0.");
                return;
            }

            // 上記以外なら末尾に[.]を挿入する
            txtInputField.Text += ".";
        }

        /// <summary>
        /// [±]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            // 入力値に[-]が含まれていたら
            if (txtInputField.Text.Contains("-"))
            {
                // [-]のインデックスを探し、入力値から取り除く
                var index = txtInputField.Text.IndexOf("-");
                txtInputField.Text =  txtInputField.Text.Remove(index, 1);
                return;
            }

            // 入力値に[-]が含まれていなければ、先頭に[-]を挿入する
            txtInputField.Text =( "-" + txtInputField.Text);
        }

        /// <summary>
        /// [-]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSub_Click(object sender, EventArgs e)
        {
            // 直前の最終答えを、演算に使おうとしていた場合
            if (m_isDisplayingFinalAnswer)
            {
                m_isDisplayingFinalAnswer = false;
                // 直前の演算の途中式をクリアする
                lblInputHistory.Text = null;
            }

            CalculateNumber((double a, double b) => a - b,"-");
        }

        /// <summary>
        /// 四則演算し、コントロールに結果を描画
        /// </summary>
        /// <param name="calc"> 行う四則演算 </param>
        /// <param name="symbol"> 行う四則演算の記号 </param>
        private void CalculateNumber(Calc calc,string symbol)
        {
            // 入力された string型を double型に変換する
            double _convertedNumber;
            var result = double.TryParse(txtInputField.Text, 
            out _convertedNumber);
            // 変換に失敗したら、メッセージボックスを表示
            if (!result)
            {
                MessageBox.Show("入力された値が正しくありません。");
                return;
            }
            // 保留されている演算がなければ、入力値を暫定答えとする
            if (m_nextCalculation == null)
            {
                m_calculateAnswer = _convertedNumber;
            }
            // 保留されている演算があれば、暫定答えと入力値を基に演算をし、
            // 演算結果を暫定答えに代入する
            else
            {
                m_calculateAnswer = m_nextCalculation(m_calculateAnswer,
                _convertedNumber);
            }
            // 今回渡されてきた演算を保留する
            m_nextCalculation = calc;

            // 暫定答えを入力欄に表示する
            txtInputField.Text = m_calculateAnswer.ToString();
            m_isDisplayingAnswer = true;

            // 途中式を表示に追加
            lblInputHistory.Text += _convertedNumber.ToString();
            lblInputHistory.Text += (" " + symbol + " ");
        }

        /// <summary>
        /// 直前の最終答えが表示されたままなら欄を初期化
        /// </summary>
        private void DeleteDisplayAnswer()
        {
            if (m_isDisplayingFinalAnswer)
            {
                m_isDisplayingFinalAnswer = false;
                lblInputHistory.Text = null;
            }
            if (m_isDisplayingAnswer)
            {
                m_isDisplayingAnswer = false;
                // 直前の最終答えを削除する
                txtInputField.Text = null;
            }
        }

        #endregion

    }
}
