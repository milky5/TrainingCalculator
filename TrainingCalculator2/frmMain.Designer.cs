﻿namespace TrainingCalculator2
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInputHistory = new System.Windows.Forms.Label();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnInput5 = new System.Windows.Forms.Button();
            this.btnInput6 = new System.Windows.Forms.Button();
            this.btnInput4 = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.btnClearEntry = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInput2 = new System.Windows.Forms.Button();
            this.btnInput3 = new System.Windows.Forms.Button();
            this.btnInput1 = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnInput0 = new System.Windows.Forms.Button();
            this.btnPeriod = new System.Windows.Forms.Button();
            this.btnPlusMinus = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnInput8 = new System.Windows.Forms.Button();
            this.btnInput9 = new System.Windows.Forms.Button();
            this.btnInput7 = new System.Windows.Forms.Button();
            this.lblInputField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInputHistory
            // 
            this.lblInputHistory.Location = new System.Drawing.Point(11, 9);
            this.lblInputHistory.Name = "lblInputHistory";
            this.lblInputHistory.Size = new System.Drawing.Size(335, 55);
            this.lblInputHistory.TabIndex = 43;
            this.lblInputHistory.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnSub
            // 
            this.btnSub.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSub.Location = new System.Drawing.Point(266, 215);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(79, 44);
            this.btnSub.TabIndex = 42;
            this.btnSub.Text = "－";
            this.btnSub.UseVisualStyleBackColor = false;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnInput5
            // 
            this.btnInput5.Location = new System.Drawing.Point(96, 215);
            this.btnInput5.Name = "btnInput5";
            this.btnInput5.Size = new System.Drawing.Size(79, 44);
            this.btnInput5.TabIndex = 41;
            this.btnInput5.Text = "5";
            this.btnInput5.UseVisualStyleBackColor = true;
            this.btnInput5.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput6
            // 
            this.btnInput6.Location = new System.Drawing.Point(181, 215);
            this.btnInput6.Name = "btnInput6";
            this.btnInput6.Size = new System.Drawing.Size(79, 44);
            this.btnInput6.TabIndex = 40;
            this.btnInput6.Text = "6";
            this.btnInput6.UseVisualStyleBackColor = true;
            this.btnInput6.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput4
            // 
            this.btnInput4.Location = new System.Drawing.Point(11, 215);
            this.btnInput4.Name = "btnInput4";
            this.btnInput4.Size = new System.Drawing.Size(79, 44);
            this.btnInput4.TabIndex = 39;
            this.btnInput4.Text = "4";
            this.btnInput4.UseVisualStyleBackColor = true;
            this.btnInput4.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDiv.Location = new System.Drawing.Point(266, 115);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(79, 44);
            this.btnDiv.TabIndex = 38;
            this.btnDiv.Text = "÷";
            this.btnDiv.UseVisualStyleBackColor = false;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnClear.Location = new System.Drawing.Point(96, 115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 44);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBackSpace.Location = new System.Drawing.Point(181, 115);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(79, 44);
            this.btnBackSpace.TabIndex = 36;
            this.btnBackSpace.Text = "Back Space";
            this.btnBackSpace.UseVisualStyleBackColor = false;
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnClearEntry
            // 
            this.btnClearEntry.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnClearEntry.Location = new System.Drawing.Point(11, 115);
            this.btnClearEntry.Name = "btnClearEntry";
            this.btnClearEntry.Size = new System.Drawing.Size(79, 44);
            this.btnClearEntry.TabIndex = 35;
            this.btnClearEntry.Text = "CE";
            this.btnClearEntry.UseVisualStyleBackColor = false;
            this.btnClearEntry.Click += new System.EventHandler(this.btnClearEntry_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAdd.Location = new System.Drawing.Point(266, 265);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 44);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "＋";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInput2
            // 
            this.btnInput2.Location = new System.Drawing.Point(96, 265);
            this.btnInput2.Name = "btnInput2";
            this.btnInput2.Size = new System.Drawing.Size(79, 44);
            this.btnInput2.TabIndex = 33;
            this.btnInput2.Text = "2";
            this.btnInput2.UseVisualStyleBackColor = true;
            this.btnInput2.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput3
            // 
            this.btnInput3.Location = new System.Drawing.Point(181, 265);
            this.btnInput3.Name = "btnInput3";
            this.btnInput3.Size = new System.Drawing.Size(79, 44);
            this.btnInput3.TabIndex = 32;
            this.btnInput3.Text = "3";
            this.btnInput3.UseVisualStyleBackColor = true;
            this.btnInput3.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput1
            // 
            this.btnInput1.Location = new System.Drawing.Point(11, 265);
            this.btnInput1.Name = "btnInput1";
            this.btnInput1.Size = new System.Drawing.Size(79, 44);
            this.btnInput1.TabIndex = 31;
            this.btnInput1.Text = "1";
            this.btnInput1.UseVisualStyleBackColor = true;
            this.btnInput1.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCalculate.Location = new System.Drawing.Point(266, 315);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(79, 44);
            this.btnCalculate.TabIndex = 30;
            this.btnCalculate.Text = "＝";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnInput0
            // 
            this.btnInput0.Location = new System.Drawing.Point(96, 315);
            this.btnInput0.Name = "btnInput0";
            this.btnInput0.Size = new System.Drawing.Size(79, 44);
            this.btnInput0.TabIndex = 29;
            this.btnInput0.Text = "0";
            this.btnInput0.UseVisualStyleBackColor = true;
            this.btnInput0.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnPeriod
            // 
            this.btnPeriod.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPeriod.Location = new System.Drawing.Point(181, 315);
            this.btnPeriod.Name = "btnPeriod";
            this.btnPeriod.Size = new System.Drawing.Size(79, 44);
            this.btnPeriod.TabIndex = 28;
            this.btnPeriod.Text = ".";
            this.btnPeriod.UseVisualStyleBackColor = false;
            this.btnPeriod.Click += new System.EventHandler(this.btnPeriod_Click);
            // 
            // btnPlusMinus
            // 
            this.btnPlusMinus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPlusMinus.Location = new System.Drawing.Point(11, 315);
            this.btnPlusMinus.Name = "btnPlusMinus";
            this.btnPlusMinus.Size = new System.Drawing.Size(79, 44);
            this.btnPlusMinus.TabIndex = 27;
            this.btnPlusMinus.Text = "±";
            this.btnPlusMinus.UseVisualStyleBackColor = false;
            this.btnPlusMinus.Click += new System.EventHandler(this.btnPlusMinus_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnMulti.Location = new System.Drawing.Point(266, 165);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(79, 44);
            this.btnMulti.TabIndex = 26;
            this.btnMulti.Text = "×";
            this.btnMulti.UseVisualStyleBackColor = false;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // btnInput8
            // 
            this.btnInput8.Location = new System.Drawing.Point(96, 165);
            this.btnInput8.Name = "btnInput8";
            this.btnInput8.Size = new System.Drawing.Size(79, 44);
            this.btnInput8.TabIndex = 25;
            this.btnInput8.Text = "8";
            this.btnInput8.UseVisualStyleBackColor = true;
            this.btnInput8.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput9
            // 
            this.btnInput9.Location = new System.Drawing.Point(181, 165);
            this.btnInput9.Name = "btnInput9";
            this.btnInput9.Size = new System.Drawing.Size(79, 44);
            this.btnInput9.TabIndex = 24;
            this.btnInput9.Text = "9";
            this.btnInput9.UseVisualStyleBackColor = true;
            this.btnInput9.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // btnInput7
            // 
            this.btnInput7.Location = new System.Drawing.Point(11, 165);
            this.btnInput7.Name = "btnInput7";
            this.btnInput7.Size = new System.Drawing.Size(79, 44);
            this.btnInput7.TabIndex = 23;
            this.btnInput7.Text = "7";
            this.btnInput7.UseVisualStyleBackColor = true;
            this.btnInput7.Click += new System.EventHandler(this.btnInputNumber_Click);
            // 
            // lblInputField
            // 
            this.lblInputField.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInputField.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInputField.Location = new System.Drawing.Point(11, 74);
            this.lblInputField.Name = "lblInputField";
            this.lblInputField.Size = new System.Drawing.Size(334, 24);
            this.lblInputField.TabIndex = 44;
            this.lblInputField.Text = "0";
            this.lblInputField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 365);
            this.Controls.Add(this.lblInputField);
            this.Controls.Add(this.lblInputHistory);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnInput5);
            this.Controls.Add(this.btnInput6);
            this.Controls.Add(this.btnInput4);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBackSpace);
            this.Controls.Add(this.btnClearEntry);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnInput2);
            this.Controls.Add(this.btnInput3);
            this.Controls.Add(this.btnInput1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnInput0);
            this.Controls.Add(this.btnPeriod);
            this.Controls.Add(this.btnPlusMinus);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnInput8);
            this.Controls.Add(this.btnInput9);
            this.Controls.Add(this.btnInput7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "電卓";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInputHistory;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnInput5;
        private System.Windows.Forms.Button btnInput6;
        private System.Windows.Forms.Button btnInput4;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.Button btnClearEntry;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInput2;
        private System.Windows.Forms.Button btnInput3;
        private System.Windows.Forms.Button btnInput1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnInput0;
        private System.Windows.Forms.Button btnPeriod;
        private System.Windows.Forms.Button btnPlusMinus;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnInput8;
        private System.Windows.Forms.Button btnInput9;
        private System.Windows.Forms.Button btnInput7;
        private System.Windows.Forms.Label lblInputField;
    }
}

