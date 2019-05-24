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
        /// 直前の入力は演算子か
        /// </summary>
        private bool m_beforeInputIsOperator;
        /// <summary>
        /// 計算の途中の答えが表示中か
        /// </summary>
        private bool m_isShowingAnswer;
        /// <summary>
        /// 計算終了後の答えが表示中か
        /// </summary>
        private bool m_isShowingFinalAnswer;
        /// <summary>
        /// 計算の実行をするクラスのインスタンス
        /// </summary>
        clsCalculateManager m_calcManager;
        /// <summary>
        /// 直前の入力は±か
        /// </summary>
        private bool m_beforeInputIsPlusMinus;

        #endregion


        #region メンバメソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            m_calcManager = new clsCalculateManager();
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
                m_calcManager.AssignAnswerToConstant();
            }
            // 数字の後に[=]を押された時の処理
            else if (m_beforeInputIsOperator == false
                    && m_isShowingAnswer == false)
            {
                m_calcManager.CalculateConstant = double.Parse(lblInputField.Text);
            }
            else if (m_beforeInputIsPlusMinus == true)
            {
                m_calcManager.CalculateConstant = double.Parse(lblInputField.Text);
                m_beforeInputIsPlusMinus = false;
            }
            // [CE]の後に[=]押された時と、[=]のあとに[=]押された時の処理
            else if (m_beforeInputIsOperator == false && m_isShowingAnswer == true)
            {
                m_calcManager.AssignToAnswer(double.Parse(lblInputField.Text));
            }

            // 以下、共通の処理

            if (m_calcManager.NextCalculationIsDiv0() == true)
            {
                MessageBox.Show("0で割ることはできません");
                return;
            }

            m_calcManager.Calculate();
            m_calcManager.ResetHistory();

            m_isShowingAnswer = true;
            m_isShowingFinalAnswer = true;
            m_beforeInputIsOperator = false;

            lblInputField.Text = m_calcManager.Answer.ToString();
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
            m_beforeInputIsPlusMinus = false;

            m_calcManager.ResetValue();

            lblInputField.Text = "0";
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
            m_beforeInputIsPlusMinus = false;
            btnPlusMinus.Enabled = false;

            lblInputField.Text = "0";
        }

        /// <summary>
        /// 数字ボタンが押された際の共通イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 演算子ボタンが押された際の共通イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputOperator_Click(object sender, EventArgs e)
        {
            var _sender = (Button)sender;
            switch (_sender.Text)
            {
                case "＋":
                    OperatorClick(Operator.Add);
                    break;
                case "－":
                    OperatorClick(Operator.Sub);
                    break;
                case "×":
                    OperatorClick(Operator.Multi);
                    break;
                case "÷":
                    OperatorClick(Operator.Div);
                    break;
                default:
                    break;
            }
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
        /// [±]ボタンが押された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (m_beforeInputIsOperator == true && m_isShowingAnswer == true)
            {
                m_beforeInputIsOperator = false;
            }

            ControlPlusMinus();

            m_beforeInputIsPlusMinus = true;
        }

        /// <summary>
        ///  表示されている数字の正負を切り替える
        /// </summary>
        private void ControlPlusMinus()
        {
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
                m_calcManager.ResetValue();
            }

            if (m_isShowingAnswer)
            {
                lblInputField.Text = "";
                m_isShowingAnswer = false;

                m_calcManager.EnterTempHistory();
            }
            if (lblInputField.Text == "0")
            {
                lblInputField.Text = "";
            }

            m_beforeInputIsOperator = false;
            m_beforeInputIsPlusMinus = false;
        }

        /// <summary>
        /// 保留された演算を実行し、結果をラベルに表示する
        /// </summary>
        private void OperatorClick(Operator inputedOperator)
        {
            m_beforeInputIsPlusMinus = false;

            if (m_beforeInputIsOperator == true)
            {
                m_calcManager.NextOperator = inputedOperator;

                m_calcManager.AssignTempHistory(GetOperatorStr(inputedOperator));
                lblInputHistory.Text = m_calcManager.History;
                return;
            }

            if (m_isShowingFinalAnswer == true)
            {
                m_calcManager.ResetValue();

                m_isShowingFinalAnswer = false;
            }

            if (m_isShowingAnswer == true)
            {
                m_calcManager.EnterTempHistory();
            }

            m_calcManager.CalculateConstant = double.Parse(lblInputField.Text);

            // 保持されている四則演算がなければ
            if (m_calcManager.HasNextOperator() == false)
            {
                // 今回の入力値を答えとする
                m_calcManager.AssignConstantToAnswer();

            }
            // 保持されている四則演算があれば
            else
            {
                if (m_calcManager.NextCalculationIsDiv0() == true)
                {
                    MessageBox.Show("0で割ることはできません");
                    return;
                }
                else
                {
                    m_calcManager.Calculate();
                }
            }


            m_isShowingAnswer = true;
            m_beforeInputIsOperator = true;

            m_calcManager.NextOperator = inputedOperator;

            lblInputField.Text = m_calcManager.Answer.ToString();
            m_calcManager.AssignCalculateConstantToInputHistory();
            m_calcManager.AssignTempHistory(GetOperatorStr(inputedOperator));
            lblInputHistory.Text = m_calcManager.History;

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