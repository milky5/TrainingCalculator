﻿using System;
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
        /// 計算の答えが表示中か
        /// </summary>
        private bool m_isShowingAnswer;
        /// <summary>
        /// = 後の答えが表示中か
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

        #region ボタンが押された際に呼ばれるメソッド

        /// <summary>
        /// 保留された演算を実行し、加算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.add);

            // 定数計算のために加算を保持する
            m_beforeInputIsOperator = true;
            m_nextOperator = Operator.add;
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

            // 1文字以上入力されていたら
            if (lblInputField.Text.Length > 0)
            {
                // 文字列の最後の1字だけ削除する
                lblInputField.Text = lblInputField.Text.Remove(lblInputField.Text.Length - 1);
            }
            if (lblInputField.Text == "-")
            {
                lblInputField.Text = "";
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
        /// [=]ボタンが押された際に呼ばれるメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // (履歴が消える・数字が残る)

            // [演算子][=]連続で押された時の処理
            if (m_beforeInputIsOperator == true && m_isShowingAnswer == true)
            {
                m_beforeInputIsOperator = false;

                // answerを定数計算のために保持する
                m_calculateConstant = m_answer;
            }
            // 数字の後に[=]押された時の処理
            else if (m_beforeInputIsOperator == false && m_isShowingAnswer == false)
            {
                // 入力値を定数計算のために保持する
                m_calculateConstant = double.Parse(lblInputField.Text);
            }
            // [CE]の後に[=]押されたときの処理
            else if (m_beforeInputIsOperator == false && m_isShowingAnswer == true)
            {
                m_answer = double.Parse(lblInputField.Text);
            }

            // 3パターン共通の処理 ([=]のあとに[=]押された時の処理と同一)
            if (m_nextOperator == Operator.div && m_calculateConstant == 0)
            {
                MessageBox.Show("0で割ることはできません");
                return;
            }
            m_answer = Calculate(m_nextOperator);

            m_isShowingAnswer = true;
            m_isShowingFinalAnswer = true;
            btnPlusMinus.Enabled = true;
            btnBackSpace.Enabled = false;
            lblInputField.Text = m_answer.ToString();
            m_inputHistory = null;
            m_tempHistory = null;
            lblInputHistory.Text = "";

            m_beforeInputIsOperator = false;
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
            m_beforeInputIsOperator = false;
            m_calculateConstant = 0;
            m_nextOperator = Operator.nothing;
            m_inputHistory = null;
            m_tempHistory = null;

            btnPlusMinus.Enabled = false;
        }

        /// <summary>
        /// 入力フォームをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            lblInputField.Text = "0";
            btnPlusMinus.Enabled = false;
        }

        /// <summary>
        /// 保留された演算を実行し、除算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.div);

            // 定数計算のために除算を保持する
            m_beforeInputIsOperator = true;
            m_nextOperator = Operator.div;
        }

        private void btnInputNumber_Click(object sender, EventArgs e)
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
                var _keyNumberStr = _inputedKey.KeyCode.ToString().Remove(0, 1);
                lblInputField.Text += _keyNumberStr;
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
        /// 保留された演算を実行し、乗算を保留しておくメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            OperatorClick(Operator.multi);


            // 定数計算のために乗算を保持する
            m_beforeInputIsOperator = true;
            m_nextOperator = Operator.multi;
        }

        /// <summary>
        /// 小数点を入力する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {

            btnPlusMinus.Enabled = true;

            // 暫定答えが表示されているなら、[0.]を挿入
            if (m_isShowingAnswer == true)
            {
                // 先頭に[0.]を追加する
                lblInputField.Text = "";
                lblInputField.Text = lblInputField.Text.Insert(0, "0.");

                m_isShowingAnswer = false;
                btnPlusMinus.Enabled = true;
                btnBackSpace.Enabled = true;
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

            OperatorClick(Operator.sub);


            // 定数計算のために減算を保持する
            m_beforeInputIsOperator = true;
            m_nextOperator = Operator.sub;
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
                btnBackSpace.Enabled = true;

                m_nextOperator = Operator.nothing;
                m_calculateConstant = 0;
            }

            if (m_isShowingAnswer)
            {
                lblInputField.Text = "";
                m_isShowingAnswer = false;
                btnBackSpace.Enabled = true;

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
                m_isShowingFinalAnswer = false;
                m_nextOperator = Operator.nothing;
            }

            if (m_isShowingAnswer == true)
            {
                m_inputHistory += m_tempHistory;
            }


            m_calculateConstant = double.Parse(lblInputField.Text);

            // 保持されている四則演算がなければ
            if (m_nextOperator == Operator.nothing)
            {
                // 今回の入力値を答えとする
                m_answer = m_calculateConstant;

            }
            // 保持されている四則演算があれば
            else
            {
                // 保持されている四則演算を使って計算する
                if (m_nextOperator == Operator.div && m_calculateConstant == 0)
                {
                    MessageBox.Show("0で割ることはできません");
                    return;
                }
                m_answer = Calculate(m_nextOperator);
            }
            // デバッグ用
            m_isShowingAnswer = true;
            btnPlusMinus.Enabled = true;
            btnBackSpace.Enabled = false;
            lblInputField.Text = m_answer.ToString();

            // 確定string
            m_inputHistory += m_calculateConstant.ToString();
            m_tempHistory = GetOperatorStr(inputedOperator);
            lblInputHistory.Text = m_inputHistory + m_tempHistory;
        }




        private double Calculate(Operator inputedOperator)
        {
            switch (inputedOperator)
            {
                case Operator.nothing:
                    break;
                case Operator.add:
                    return m_answer + m_calculateConstant;
                case Operator.sub:
                    return m_answer - m_calculateConstant;
                case Operator.multi:
                    return m_answer * m_calculateConstant;
                case Operator.div:
                    return m_answer / m_calculateConstant;
                default:
                    break;
            }

            return 0;
        }

        private string GetOperatorStr(Operator inputedOperator)
        {
            switch (inputedOperator)
            {
                case Operator.nothing:
                    return null;
                case Operator.add:
                    return "＋";
                case Operator.sub:
                    return "－";
                case Operator.multi:
                    return "×";
                case Operator.div:
                    return "÷";
                default:
                    return null;
            }
        }


        #endregion

    }

    enum Operator
    {
        nothing,
        add,
        sub,
        multi,
        div
    }
}
