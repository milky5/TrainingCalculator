using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator
{
    public partial class frmMain
    {
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

    }
}
