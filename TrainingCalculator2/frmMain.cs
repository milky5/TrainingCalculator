using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingCalculator2
{
    public delegate double Calculate(double a);

    public partial class frmMain : Form
    {
        private string m_inputHistory;
        private string m_tempHistory;
        private double m_answer;
        private bool m_isShowingAnswer;
        private bool m_isCanChangeSymbol;
        /// <summary>
        /// 定数計算のために直前の数値を保持する
        /// </summary>
        private double m_calculateConstant;
        /// <summary>
        /// 定数計算のために直前の四則演算を保持する
        /// </summary>
        private Calculate m_nextCalculation;



        public frmMain()
        {
            InitializeComponent();

            MaximumSize = Size;
            MinimumSize = Size;
        }

        #region ボタンが押された際に呼ばれるメソッド

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    btnInput0_Click(sender, e);
                    break;
                case Keys.D1:
                    btnInput1_Click(sender, e);
                    break;
                case Keys.D2:
                    btnInput2_Click(sender, e);
                    break;
                case Keys.D3:
                    btnInput3_Click(sender, e);
                    break;
                case Keys.D4:
                    btnInput4_Click(sender, e);
                    break;
                case Keys.D5:
                    btnInput5_Click(sender, e);
                    break;
                case Keys.D6:
                    btnInput6_Click(sender, e);
                    break;
                case Keys.D7:
                    btnInput7_Click(sender, e);
                    break;
                case Keys.D8:
                    btnInput8_Click(sender, e);
                    break;
                case Keys.D9:
                    btnInput9_Click(sender, e);
                    break;
                case Keys.Back:
                    btnBackSpace_Click(sender, e);
                    break;
                case Keys.OemPeriod:
                    btnPeriod_Click(sender, e);
                    break;
                default:
                    break;
            }

            //MessageBox.Show(e.KeyCode.ToString());

            e.Handled = true;
        }


        // 暫定答えが表示されているなら、暫定答えから入力された数字に切り替わる
        #region 数字ボタンが押された時
        private void btnInput0_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "0";
        }

        private void btnInput1_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "1";
        }

        private void btnInput2_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "2";
        }

        private void btnInput3_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "3";
        }

        private void btnInput4_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "4";
        }

        private void btnInput5_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "5";
        }

        private void btnInput6_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "6";
        }

        private void btnInput7_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "7";
        }

        private void btnInput8_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "8";
        }

        private void btnInput9_Click(object sender, EventArgs e)
        {
            DeleteZero();
            lblInputField.Text += "9";
        }
        #endregion

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            lblInputField.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 表示も内部(式など)も全消去
            lblInputField.Text = "0";
            lblInputHistory.Text = "";
            m_answer = 0;
            m_isCanChangeSymbol = false;
            m_calculateConstant = 0;
            m_nextCalculation = null;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            // 暫定答えの場合は消えない(何も起こらない)

            var _inputedText = lblInputField.Text;
            // 1文字以上入力されていたら
            if (_inputedText.Length > 0)
            {
                // 文字列の最後の1字だけ削除する
                _inputedText = _inputedText.Remove(_inputedText.Length - 1);
                lblInputField.Text = _inputedText;
            }
            // 最後の一文字だった場合は表示が0になる
            if (_inputedText.Length == 0)
            {
                lblInputField.Text = "0";
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            // 数字入力直後なら、暫定答えを表示する(履歴に数字と演算子を表示)
            // 演算子入力直後なら、演算子を変更し、履歴の演算子を変更する
            // 暫定答えはそのままにしておく


            OperatorClick();

            // 次回のために除算を保持する
            m_isCanChangeSymbol = true;
            m_nextCalculation = ((double a) => a / m_calculateConstant);
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            OperatorClick();

            // 今回のを定数式として取っておく
            m_isCanChangeSymbol = true;
            m_nextCalculation = ((double a) => a * m_calculateConstant);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            OperatorClick();

            // 次回のために除算を保持する
            m_isCanChangeSymbol = true;
            m_nextCalculation = ((double a) => a - m_calculateConstant);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperatorClick();

            // 次回のために除算を保持する
            m_isCanChangeSymbol = true;
            m_nextCalculation = ((double a) => a + m_calculateConstant);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // (履歴が消える・数字が残る)

            // [演算子][=]連続で押された時の処理
            if (m_isCanChangeSymbol == true && m_isShowingAnswer == true)
            {
                m_isCanChangeSymbol = false;

                // answerを定数計算のために保持する
                m_calculateConstant = m_answer;
            }
            // 数字の後に[=]押された時の処理
            else if (m_isCanChangeSymbol == false && m_isShowingAnswer == true)
            {
                // 入力値を定数計算のために保持する
                m_calculateConstant = double.Parse(lblInputField.Text);
            }

            // 3パターン共通の処理 ([=]のあとに[=]押された時の処理と同一)
            m_answer = m_nextCalculation(m_answer);

            //debug
            lblconsole.Text = m_answer.ToString();

        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {

            // 暫定答えが表示されているなら、[0.]を挿入
            if (m_isShowingAnswer == true)
            {
                // 先頭に[0.]を追加する
                lblInputField.Text = lblInputField.Text.Insert(0, "0.");

                m_isShowingAnswer = false;
                return;
            }

            // 入力値に既に[.]が含まれていたら何もしない
            if (lblInputField.Text.Contains(".") == true)
            {
                return;
            }

            // 上記以外なら末尾に[.]を挿入する
            lblInputField.Text += ".";
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            // 数字入力直後なら、+,-の切り替え
            // 暫定答えが表示されているなら、暫定答えの +,-が切り替わり、計算予定になる

            if (m_isShowingAnswer == true)
            {

            }


            // 入力値に[-]が含まれていたら
            if (lblInputField.Text.Contains("-") == true)
            {
                // [-]のインデックスを探し、入力値から取り除く
                var index = lblInputField.Text.IndexOf("-");
                lblInputField.Text = lblInputField.Text.Remove(index, 1);
                return;
            }

            // 入力値に[-]が含まれていなければ、先頭に[-]を挿入する
            lblInputField.Text = ("-" + lblInputField.Text);

        }


        #endregion

        private void DeleteZero()
        {
            if (lblInputField.Text == "0")
            {
                lblInputField.Text = "";
            }

            // あとで修正する処理
            lblInputField.Text = "";
            m_isCanChangeSymbol = false;
            m_isShowingAnswer = false;
        }

        void OperatorClick()
        {
            m_calculateConstant = double.Parse(lblInputField.Text);

            // 保持されている四則演算がなければ
            if (m_nextCalculation == null)
            {
                // 今回の入力値を答えとする
                m_answer = m_calculateConstant;
            }
            // 保持されている四則演算があれば
            else
            {
                // 保持されている四則演算を使って計算する
                m_answer = m_nextCalculation(m_answer);
            }
            // デバッグ用
            lblconsole.Text = m_answer.ToString();
        }

    }
}
