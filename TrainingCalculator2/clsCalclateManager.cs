using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator2
{
    class clsCalculateManager
    {
        #region メンバ変数
        /// <summary>
        /// 入力履歴(確定部分)
        /// </summary>
        private string m_inputHistory;
        /// <summary>
        /// 入力履歴(未確定部分)
        /// </summary>
        private string m_tempHistory;
        #endregion


        #region メンバメソッド

        /// <summary>
        /// 現在の答えを定数に代入する
        /// </summary>
        public void AssignAnswerToConstant()
        {
            CalculateConstant = Answer;
        }

        /// <summary>
        /// 確定した数字部分を履歴に入力する
        /// </summary>
        public void AssignCalculateConstantToInputHistory()
        {
            m_inputHistory += CalculateConstant.ToString();
        }

        /// <summary>
        /// 現在の定数を答えに代入する
        /// </summary>
        public void AssignConstantToAnswer()
        {
            Answer = CalculateConstant;
        }

        /// <summary>
        /// 未確定の演算子を入力履歴に代入する
        /// </summary>
        /// <param name="operatorStr"> 文字列型の演算子 </param>
        public void AssignTempHistory(string operatorStr)
        {
            m_tempHistory = operatorStr;
        }

        /// <summary>
        /// 答えに入力値を代入する
        /// </summary>
        public void AssignToAnswer(double inputNumber)
        {
            Answer = inputNumber;
        }

        /// <summary>
        /// 定数計算を実行し、答えに代入する
        /// </summary>
        public void Calculate()
        {
            switch (NextOperator)
            {
                case Operator.Add:
                     Answer += CalculateConstant;
                    break;
                case Operator.Sub:
                    Answer -= CalculateConstant;
                    break;
                case Operator.Multi:
                    Answer *= CalculateConstant;
                    break;
                case Operator.Div:
                    Answer /= CalculateConstant;
                    break;
                case Operator.Nothing:
                default:
                    break;
            }
        }

        /// <summary>
        /// 入力履歴の未確定部分を確定する
        /// </summary>
        public void EnterTempHistory()
        {
            m_inputHistory += m_tempHistory;
            m_tempHistory = "";
        }

        /// <summary>
        /// 次の演算子を保持しているか
        /// </summary>
        /// <returns> 保持している true, 保持していない false </returns>
        public bool HasNextOperator()
        {
            if (NextOperator == Operator.Nothing)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 次の計算が0除算かどうか
        /// </summary>
        /// <returns> 0除算 true, 0除算でない false </returns>
        public bool NextCalculationIsDiv0()
        {
            if (NextOperator == Operator.Div && CalculateConstant == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 履歴の値を初期化する
        /// </summary>
        public void ResetHistory()
        {
            m_inputHistory = "";
            m_tempHistory = "";
        }
        /// <summary>
        /// 計算に使う値を初期化する
        /// </summary>
        public void ResetValue()
        {
            Answer = 0;
            CalculateConstant = 0;
            NextOperator = Operator.Nothing;
            m_inputHistory = "";
            m_tempHistory = "";
        }






        #endregion


        #region プロパティ
        /// <summary>
        /// 計算の答え
        /// </summary>
        public double Answer { get; private set; }
        /// <summary>
        /// 定数計算の数値
        /// </summary>
        public double CalculateConstant { get; set; }
        /// <summary>
        /// 入力履歴
        /// </summary>
        public string History
        {
            get
            {
                return m_inputHistory + m_tempHistory;
            }
        }
        /// <summary>
        /// 定数計算の演算子
        /// </summary>
        public Operator NextOperator { get; set; }

        #endregion
    }
}
