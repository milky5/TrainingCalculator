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
    /// <summary>
    /// 定数計算するために加減乗除いずれかの計算を保留しておく
    /// </summary>
    /// <param name="a"> 定数と計算する値 </param>
    /// <returns> 計算結果 </returns>
    public delegate double Calculate(double a);

    public partial class frmMain : Form
    {
        #region メンバ変数

        /// <summary>
        /// 計算の答え
        /// </summary>
        private double m_answer;
        /// <summary>
        /// 直前の入力は演算子か
        /// </summary>
        private bool m_beforeInputIsSymbol;
        /// <summary>
        /// 定数計算のための直前の四則演算は除算か
        /// </summary>
        private bool m_beforeInputSymbolIsDiv;
        /// <summary>
        /// 定数計算のために直前の数値を保持する
        /// </summary>
        private double m_calculateConstant;
        /// <summary>
        /// 入力履歴(確定部分)
        /// </summary>
        private string m_inputHistory;
        /// <summary>
        /// 計算の答えが表示中か
        /// </summary>
        private bool m_isShowingAnswer;
        /// <summary>
        /// 定数計算のために直前の四則演算を保持する
        /// </summary>
        private Calculate m_nextCalculation;
        /// <summary>
        /// 入力履歴(未確定部分)
        /// </summary>
        private string m_tempHistory;

        bool m_isShowingFinalAnswer;

        #endregion


        #region メンバメソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

        }

        #region ボタンが押された際に呼ばれるメソッド

        /// <summary>
        /// 保留された演算を実行し、加算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperatorClick("+");

            // 定数計算のために加算を保持する
            m_beforeInputIsSymbol = true;
            m_nextCalculation = ((double a) => a + m_calculateConstant);
            m_beforeInputSymbolIsDiv = false;
        }

        /// <summary>
        /// 入力された値の末尾1文字を消す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            // 暫定答えの場合は消えない(何も起こらない)
            if (m_isShowingAnswer == true)
            {
                return;
            }

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

        /// <summary>
        /// [=]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // (履歴が消える・数字が残る)

            // [演算子][=]連続で押された時の処理
            if (m_beforeInputIsSymbol == true && m_isShowingAnswer == true)
            {
                m_beforeInputIsSymbol = false;

                // answerを定数計算のために保持する
                m_calculateConstant = m_answer;
            }
            // 数字の後に[=]押された時の処理
            else if (m_beforeInputIsSymbol == false && m_isShowingAnswer == false)
            {
                // 入力値を定数計算のために保持する
                m_calculateConstant = double.Parse(lblInputField.Text);
            }

            // 3パターン共通の処理 ([=]のあとに[=]押された時の処理と同一)
            if (m_beforeInputSymbolIsDiv == true && m_calculateConstant == 0)
            {
                MessageBox.Show("0で割ることはできません");
                return;
            }
            m_answer = m_nextCalculation(m_answer);

            m_isShowingAnswer = true;
            m_isShowingFinalAnswer = true;
            btnPlusMinus.Enabled = false;
            lblInputField.Text = m_answer.ToString();
            m_inputHistory = null;
            m_tempHistory = null;
            lblInputHistory.Text = "";

            m_beforeInputIsSymbol = false;
        }

        /// <summary>
        /// 入力をすべてクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 表示も内部(式など)も全消去
            lblInputField.Text = "0";
            lblInputHistory.Text = "";
            m_answer = 0;
            m_isShowingAnswer = false;
            m_beforeInputIsSymbol = false;
            m_calculateConstant = 0;
            m_nextCalculation = null;
            m_beforeInputSymbolIsDiv = false;
            m_inputHistory = null;
            m_tempHistory = null;
        }

        /// <summary>
        /// 入力フォームをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            lblInputField.Text = "0";
        }

        /// <summary>
        /// 保留された演算を実行し、除算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, EventArgs e)
        {
            OperatorClick("÷");

            // 定数計算のために除算を保持する
            m_beforeInputIsSymbol = true;
            m_nextCalculation = ((double a) => a / m_calculateConstant);
            m_beforeInputSymbolIsDiv = true;
        }

        private void btnInputNumber_Click(object sender ,EventArgs e)
        {
            InputNumberCommon();

            var _sender = sender.GetType();

            // senderがButtonなら
            if (sender is Button)
            {
                var _inputedButton = (Button)sender;
                lblInputField.Text += _inputedButton.Text;
            }
            // senderがformなら、keyeventargsから値を取得
            else if (sender is Form)
            {
                var _inputedKey = (KeyEventArgs)e;
                var _key = _inputedKey.KeyCode;
                var _result = _key.ToString();

            }

            
            
        }

        /// <summary>
        /// 保留された演算を実行し、乗算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            OperatorClick("×");

            // 定数計算のために乗算を保持する
            m_beforeInputIsSymbol = true;
            m_nextCalculation = ((double a) => a * m_calculateConstant);
            m_beforeInputSymbolIsDiv = false;
        }

        /// <summary>
        /// 小数点を入力する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {

            // 暫定答えが表示されているなら、[0.]を挿入
            if (m_isShowingAnswer == true)
            {
                // 先頭に[0.]を追加する
                lblInputField.Text = lblInputField.Text.Insert(0, "0.");

                m_isShowingAnswer = false;
                btnPlusMinus.Enabled = true;
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

        /// <summary>
        /// 正数負数の切り替えをする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// 保留された演算を実行し、減算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSub_Click(object sender, EventArgs e)
        {
            OperatorClick("-");

            // 定数計算のために減算を保持する
            m_beforeInputIsSymbol = true;
            m_nextCalculation = ((double a) => a - m_calculateConstant);
            m_beforeInputSymbolIsDiv = false;
        }

        #endregion

        /// <summary>
        /// キーボード入力イベントを受けとり、適切なメソッドに割り振る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    btnInputNumber_Click(sender, e);
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

            // 子コントロールでこのイベントを拾わないようにする
            e.Handled = true;
        }

        /// <summary>
        /// 数字入力の際に文字列を適切に表示する
        /// </summary>
        private void InputNumberCommon()
        {
            if (m_isShowingFinalAnswer)
            {
                m_isShowingFinalAnswer = false;

                m_nextCalculation = null;
                m_calculateConstant = 0;
            }

            if (m_isShowingAnswer)
            {
                lblInputField.Text = "";
                m_isShowingAnswer = false;
                btnPlusMinus.Enabled = true;

                m_inputHistory += m_tempHistory;
                m_tempHistory = null;
            }
            if (lblInputField.Text == "0")
            {
                lblInputField.Text = "";
            }

            m_beforeInputIsSymbol = false;
        }

        /// <summary>
        /// 保留された演算を実行し、結果をラベルに表示する
        /// </summary>
        void OperatorClick(string symbol)
        {
            if (m_beforeInputIsSymbol == true)
            {
                m_tempHistory = $" {symbol} ";
                lblInputHistory.Text = m_inputHistory + m_tempHistory;
                return;
            }

            if (m_isShowingFinalAnswer == true)
            {
                m_calculateConstant = 0;
                m_nextCalculation = null;
                m_beforeInputSymbolIsDiv = false;
                m_answer = 0;
                m_isShowingFinalAnswer = false;
            }


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
                if (m_beforeInputSymbolIsDiv == true && m_calculateConstant == 0)
                {
                    MessageBox.Show("0で割ることはできません");
                    return;
                }
                m_answer = m_nextCalculation(m_answer);
            }
            // デバッグ用
            m_isShowingAnswer = true;
            btnPlusMinus.Enabled = false;
            lblInputField.Text = m_answer.ToString();

            // 確定string
            m_inputHistory += m_calculateConstant.ToString();
            m_tempHistory = $" {symbol} ";
            lblInputHistory.Text = m_inputHistory + m_tempHistory;
        }

        #endregion

    }
}
