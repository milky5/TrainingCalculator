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
