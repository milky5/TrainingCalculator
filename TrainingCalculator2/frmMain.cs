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
        private bool m_beforeInputIsOperator;
        /// <summary>
        /// 定数計算の数値
        /// </summary>
        private double m_calculateConstant;
        /// <summary>
        /// 入力履歴(確定部分)
        /// </summary>
        private string m_inputHistory;
        /// <summary>
        /// 定数計算の演算子
        /// </summary>
        Operator m_nextOperator;
        /// <summary>
        /// 計算の途中の答えが表示中か
        /// </summary>
        private bool m_isShowingAnswer;
        /// <summary>
        /// 計算終了後の答えが表示中か
        /// </summary>
        bool m_isShowingFinalAnswer;
        /// <summary>
        /// 入力履歴(未確定部分)
        /// </summary>
        private string m_tempHistory;

        #endregion


        #region メンバメソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保留された演算を実行し、加算を保留する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.Add);
        }

        /// <summary>
        /// 入力欄の末尾1文字を消す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            // 入力欄に値があれば、文字列の最後の1字だけ削除する
            if (lblInputField.Text.Length > 0)
            {
                lblInputField.Text
                    = lblInputField.Text.Remove(lblInputField.Text.Length - 1);

                // 入力欄が[-]だけであれば空文字列にする
                if (lblInputField.Text == "-")
                {
                    lblInputField.Text = "";
                }
            }
            // 文字列がない場合は表示が0になる
            if (lblInputField.Text.Length == 0)
            {
                lblInputField.Text = "0";
                btnPlusMinus.Enabled = false;
                btnBackSpace.Enabled = false;
            }
        }

        /// <summary>
        /// 演算を実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // [演算子][=]連続で押された時の処理
            if (m_beforeInputIsOperator == true && m_isShowingAnswer == true)
            {
                m_beforeInputIsOperator = false;
                m_calculateConstant = m_answer;
            }
            // 数字の後に[=]を押された時の処理
            else if (m_beforeInputIsOperator == false
                    && m_isShowingAnswer == false)
            {
                m_calculateConstant = double.Parse(lblInputField.Text);
            }
            // [CE]の後に[=]押されたときの処理
            else if (m_beforeInputIsOperator == false && m_isShowingAnswer == true)
            {
                m_answer = double.Parse(lblInputField.Text);
            }

            // 以下、共通の処理 ([=]のあとに[=]押された時の処理と同一)

            if (m_nextOperator == Operator.Div && m_calculateConstant == 0)
            {
                MessageBox.Show("0で割ることはできません");
                return;
            }

            m_answer = Calculate(m_nextOperator);

            m_isShowingAnswer = true;
            m_isShowingFinalAnswer = true;
            m_beforeInputIsOperator = false;

            lblInputField.Text = m_answer.ToString();
            m_inputHistory = "";
            m_tempHistory = "";
            lblInputHistory.Text = "";

            btnPlusMinus.Enabled = true;
            btnBackSpace.Enabled = false;
        }

        /// <summary>
        /// 入力をすべてクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            m_isShowingAnswer = false;
            m_beforeInputIsOperator = false;

            m_answer = 0;
            m_calculateConstant = 0;
            m_nextOperator = Operator.Nothing;

            lblInputField.Text = "0";
            m_inputHistory = "";
            m_tempHistory = "";
            lblInputHistory.Text = "";

            btnPlusMinus.Enabled = false;
        }

        /// <summary>
        /// 入力フォームをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            btnPlusMinus.Enabled = false;

            lblInputField.Text = "0";
        }

        /// <summary>
        /// 保留された演算を実行し、除算を保留する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.Div);
        }

        private void btnInputNumber_Click(object sender, EventArgs e)
        {
            InputNumberCommon();

            var _sender = sender.GetType();
            if (sender is Button)
            {
                var _inputedButton = (Button)sender;
                lblInputField.Text += _inputedButton.Text;
            }
            else if (sender is Form)
            {
                var _inputedKey = (KeyEventArgs)e;
                lblInputField.Text += _inputedKey.KeyCode.ToString().Remove(0, 1);
            }

            if (lblInputField.Text == "0")
            {
                btnPlusMinus.Enabled = false;
                btnBackSpace.Enabled = false;
            }
            else
            {
                btnPlusMinus.Enabled = true;
                btnBackSpace.Enabled = true;
            }
        }

        /// <summary>
        /// 保留された演算を実行し、乗算を保留する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.Multi);
        }

        /// <summary>
        /// 小数点を入力する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {

            btnPlusMinus.Enabled = true;
            btnBackSpace.Enabled = true;

            // 暫定答えが表示されているなら、[0.]を挿入
            if (m_isShowingAnswer == true)
            {
                lblInputField.Text = "";
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

        /// <summary>
        /// 正数負数の切り替えをする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (m_beforeInputIsOperator == true && m_isShowingAnswer == true)
            {
                m_beforeInputIsOperator = false;
            }

            // 入力値に[-]が含まれていたら、[-]を入力値から取り除く
            if (lblInputField.Text.Contains("-") == true)
            {
                var index = lblInputField.Text.IndexOf("-");
                lblInputField.Text = lblInputField.Text.Remove(index, 1);
                return;
            }

            // 入力値に[-]が含まれていなければ、先頭に[-]を挿入する
            lblInputField.Text = ("-" + lblInputField.Text);
        }

        /// <summary>
        /// 保留された演算を実行し、減算を保留する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSub_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.Sub);
        }

        /// <summary>
        /// 演算子を基に定数計算を実行する
        /// </summary>
        /// <param name="useOperator"> 使用する演算子の種類 </param>
        /// <returns> 計算結果 </returns>
        private double Calculate(Operator useOperator)
        {
            switch (useOperator)
            {
                case Operator.Add:
                    return m_answer + m_calculateConstant;
                case Operator.Sub:
                    return m_answer - m_calculateConstant;
                case Operator.Multi:
                    return m_answer * m_calculateConstant;
                case Operator.Div:
                    return m_answer / m_calculateConstant;
                case Operator.Nothing:
                default:
                    break;
            }

            return 0;
        }

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
        /// 演算子を文字列型で返す
        /// </summary>
        /// <param name="inputedOperator"> 演算子の種類 </param>
        /// <returns></returns>
        private string GetOperatorStr(Operator inputedOperator)
        {
            switch (inputedOperator)
            {
                case Operator.Nothing:
                    return null;
                case Operator.Add:
                    return "＋";
                case Operator.Sub:
                    return "－";
                case Operator.Multi:
                    return "×";
                case Operator.Div:
                    return "÷";
                default:
                    return null;
            }
        }

        /// <summary>
        /// 数字入力のために入力欄を整える
        /// </summary>
        private void InputNumberCommon()
        {
            if (m_isShowingFinalAnswer)
            {
                m_isShowingFinalAnswer = false;

                m_nextOperator = Operator.Nothing;
                m_calculateConstant = 0;
            }

            if (m_isShowingAnswer)
            {
                lblInputField.Text = "";
                m_isShowingAnswer = false;

                m_inputHistory += m_tempHistory;
                m_tempHistory = null;
            }
            if (lblInputField.Text == "0")
            {
                lblInputField.Text = "";
            }

            m_beforeInputIsOperator = false;
        }

        /// <summary>
        /// 保留された演算を実行し、結果をラベルに表示する
        /// </summary>
        private void OperatorClick(Operator inputedOperator)
        {
            if (m_beforeInputIsOperator == true)
            {
                m_tempHistory = GetOperatorStr(inputedOperator);
                lblInputHistory.Text = m_inputHistory + m_tempHistory;
                return;
            }

            if (m_isShowingFinalAnswer == true)
            {
                m_calculateConstant = 0;
                m_answer = 0;
                m_nextOperator = Operator.Nothing;

                m_isShowingFinalAnswer = false;
            }

            if (m_isShowingAnswer == true)
            {
                m_inputHistory += m_tempHistory;
            }

            m_calculateConstant = double.Parse(lblInputField.Text);

            // 保持されている四則演算がなければ
            if (m_nextOperator == Operator.Nothing)
            {
                // 今回の入力値を答えとする
                m_answer = m_calculateConstant;

            }
            // 保持されている四則演算があれば
            else
            {
                // 保持されている四則演算を使って計算する
                if (m_nextOperator == Operator.Div && m_calculateConstant == 0)
                {
                    MessageBox.Show("0で割ることはできません");
                    return;
                }
                m_answer = Calculate(m_nextOperator);
            }


            m_isShowingAnswer = true;
            m_beforeInputIsOperator = true;

            m_nextOperator = inputedOperator;

            lblInputField.Text = m_answer.ToString();
            m_inputHistory += m_calculateConstant.ToString();
            m_tempHistory = GetOperatorStr(inputedOperator);
            lblInputHistory.Text = m_inputHistory + m_tempHistory;

            btnPlusMinus.Enabled = true;
            btnBackSpace.Enabled = false;
        }

        #endregion
    }

    enum Operator
    {
        Nothing,
        Add,
        Sub,
        Multi,
        Div
    }
}
