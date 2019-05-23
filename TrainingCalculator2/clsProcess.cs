using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator2
{
    class clsProcess
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

        public void AnswerToConstant()
        {
            m_calculateConstant = m_answer;
        }
        public void ConstantToAnswer()
        {
            m_answer = m_calculateConstant;
        }
        public void IntoConstant(double inputNumber)
        {
            m_calculateConstant = inputNumber;
        }

        public void IntoAnswer(double inputNumber)
        {
            m_answer = inputNumber;
        }
        public void DoCalculate()
        {
            m_answer = Calculate(m_nextOperator);
            m_inputHistory = "";
            m_tempHistory = "";
        }
        public void DoCalculate2()
        {
            m_answer = Calculate(m_nextOperator);
        }

        public double GetAnswer()
        {
            return m_answer;
        }

        public void Reset()
        {
            m_answer = 0;
            m_calculateConstant = 0;
            m_nextOperator = Operator.Nothing;
            m_inputHistory = "";
            m_tempHistory = "";
        }
        public void Reset2()
        {
            m_nextOperator = Operator.Nothing;
            m_calculateConstant = 0;
        }
        public void EnterTempHistory()
        {
            m_inputHistory += m_tempHistory;
            m_tempHistory = "";
        }
        public void IntoTempHistory(string str)
        {
            m_tempHistory = str;
        }
        public string GetHistoryStr()
        {
            return m_inputHistory + m_tempHistory;
        }
        public void Reset3()
        {
            m_calculateConstant = 0;
            m_answer = 0;
            m_nextOperator = Operator.Nothing;
        }
        public void IntoNextOperator(Operator inputedOperator)
        {
            m_nextOperator = inputedOperator;
        }
        public void CalculateConstantToInputHistory()
        {
            m_inputHistory += m_calculateConstant.ToString();
        }
        public bool WillDiv0()
        {
            if (m_nextOperator == Operator.Div && m_calculateConstant == 0)
            {
                return true;
            }
            return false;
        }
        public bool NextOperatorIsDiv()
        {
            if (m_nextOperator == Operator.Div)
            {
                return true;
            }
            return false;
        }
    }
}
