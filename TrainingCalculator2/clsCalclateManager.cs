using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator2
{
    class clsCalculateManager
    {

        /// <summary>
        /// 計算の答え
        /// </summary>
        private double m_answer;
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
        /// 入力履歴(未確定部分)
        /// </summary>
        private string m_tempHistory;



        /// <summary>
        /// 演算子を基に定数計算を実行する
        /// </summary>
        /// <param name="useOperator"> 使用する演算子の種類 </param>
        /// <returns> 計算結果 </returns>
        public double Calculate(Operator useOperator)
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
        /// 現在の答えを定数に代入する
        /// （[演算子][＝]連続で押されたときの処理）
        /// </summary>
        public void AnswerToConstant()
        {
            m_calculateConstant = m_answer;
        }
        /// <summary>
        /// 現在の定数を答えに代入する
        /// (計算の最初の数字が入力され、それがそのまま暫定答えになるときの処理)
        /// </summary>
        public void ConstantToAnswer()
        {
            m_answer = m_calculateConstant;
        }
        /// <summary>
        /// 入力された値を定数に代入する
        /// (数字入力直後に演算子や＝が押され、数字が確定した時の処理)
        /// </summary>
        /// <param name="inputNumber"></param>
        public void IntoConstant(double inputNumber)
        {
            m_calculateConstant = inputNumber;
        }
        /// <summary>
        /// 定数計算の数値部分は残したまま、暫定答えだけ0にする
        /// ([CE]の後に[=]が押されたときの処理)
        /// </summary>
        /// <param name="inputNumber"></param>
        public void IntoAnswer(double inputNumber)
        {
            m_answer = inputNumber;
        }
        /// <summary>
        /// 最終答えを計算する際の処理
        /// (＝ボタンが押されたときの処理)
        /// </summary>
        public void DoCalculate()
        {
            m_answer = Calculate(m_nextOperator);
            m_inputHistory = "";
            m_tempHistory = "";
        }
        /// <summary>
        /// 暫定答えを計算する際の処理
        /// (演算子ボタンが2回目以降に押されたとき(計算ができるとき)の処理)
        /// </summary>
        public void DoCalculate2()
        {
            m_answer = Calculate(m_nextOperator);
        }
        /// <summary>
        /// 現在の答えを返すメソッド（プロパティでいい）
        /// </summary>
        /// <returns> 現在の答え </returns>
        public double GetAnswer()
        {
            return m_answer;
        }

        /// <summary>
        /// 計算に使う値を初期化する
        /// ([C]が押されたときの処理)
        /// </summary>
        public void Reset()
        {
            m_answer = 0;
            m_calculateConstant = 0;
            m_nextOperator = Operator.Nothing;
            m_inputHistory = "";
            m_tempHistory = "";
        }
        /// <summary>
        /// 計算に使う値を初期化する
        /// (最終答え表示中に数字が押されたとき(新しい計算が始まるとき)の処理)
        /// </summary>
        public void Reset2()
        {
            m_nextOperator = Operator.Nothing;
            m_calculateConstant = 0;
        }
        /// <summary>
        /// 未確定部分の入力履歴を確定し、未確定部分の入力履歴を初期化する
        /// (暫定答え表示中に[演算子]もしくは[数字]が押されたときの処理)
        /// </summary>
        public void EnterTempHistory()
        {
            m_inputHistory += m_tempHistory;
            m_tempHistory = "";
        }
        /// <summary>
        /// 未確定の演算子を入力履歴に表示する
        /// (演算子直後に演算子を入力された際、入力された演算子を未確定とする
        /// 数字の後に演算子が押された際に、演算子を未確定とする)
        /// </summary>
        /// <param name="str"> 文字列型の演算子 </param>
        public void IntoTempHistory(string str)
        {
            m_tempHistory = str;
        }
        /// <summary>
        /// 現在の入力履歴(確定部分+未確定部分)を返すメソッド（プロパティでもよい）
        /// </summary>
        /// <returns></returns>
        public string GetHistoryStr()
        {
            return m_inputHistory + m_tempHistory;
        }
        /// <summary>
        /// 計算に使う値を初期化する
        /// (最終答え表示中に演算子が押されたとき(新しい計算が始まるとき)の処理)
        /// </summary>
        public void Reset3()
        {
            m_calculateConstant = 0;
            m_answer = 0;
            m_nextOperator = Operator.Nothing;
        }
        /// <summary>
        /// 次に使用する演算子をセットする（プロパティでいい）
        /// </summary>
        /// <param name="inputedOperator"></param>
        public void IntoNextOperator(Operator inputedOperator)
        {
            m_nextOperator = inputedOperator;
        }
        /// <summary>
        /// 数字部分が確定した際、数字部分を履歴に入力する
        /// (演算子が押された際の処理)
        /// </summary>
        public void CalculateConstantToInputHistory()
        {
            m_inputHistory += m_calculateConstant.ToString();
        }
        /// <summary>
        /// 次の計算が0除算かどうか
        /// </summary>
        /// <returns> 0除算 true, 0除算でない false </returns>
        public bool WillDiv0()
        {
            if (m_nextOperator == Operator.Div && m_calculateConstant == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 次の演算子を保持しているか
        /// </summary>
        /// <returns> 保持している true, 保持していない false </returns>
        public bool HasNextOperator()
        {
            if (m_nextOperator == Operator.Nothing)
            {
                return false;
            }
            return true;
        }
    }
}
