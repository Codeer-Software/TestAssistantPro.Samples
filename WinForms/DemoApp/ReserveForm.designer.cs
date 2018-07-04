namespace DemoApp
{
    partial class ReserveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxCount = new System.Windows.Forms.TextBox();
            this._date = new System.Windows.Forms.MonthCalendar();
            this._textBoxTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._buttonOK = new System.Windows.Forms.Button();
            this._checkBoxNonSmoke = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(52, 12);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(161, 19);
            this._textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of people";
            // 
            // _textBoxCount
            // 
            this._textBoxCount.Location = new System.Drawing.Point(114, 39);
            this._textBoxCount.Name = "_textBoxCount";
            this._textBoxCount.Size = new System.Drawing.Size(99, 19);
            this._textBoxCount.TabIndex = 3;
            // 
            // _date
            // 
            this._date.Location = new System.Drawing.Point(14, 70);
            this._date.Name = "_date";
            this._date.TabIndex = 4;
            // 
            // _textBoxTime
            // 
            this._textBoxTime.Location = new System.Drawing.Point(48, 244);
            this._textBoxTime.Name = "_textBoxTime";
            this._textBoxTime.Size = new System.Drawing.Size(165, 19);
            this._textBoxTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time";
            // 
            // _buttonOK
            // 
            this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOK.Location = new System.Drawing.Point(138, 307);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 23);
            this._buttonOK.TabIndex = 7;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _checkBoxNonSmoke
            // 
            this._checkBoxNonSmoke.AutoSize = true;
            this._checkBoxNonSmoke.Location = new System.Drawing.Point(15, 273);
            this._checkBoxNonSmoke.Name = "_checkBoxNonSmoke";
            this._checkBoxNonSmoke.Size = new System.Drawing.Size(116, 16);
            this._checkBoxNonSmoke.TabIndex = 8;
            this._checkBoxNonSmoke.Text = "Non smoking seat";
            this._checkBoxNonSmoke.UseVisualStyleBackColor = true;
            // 
            // ReserveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 338);
            this.Controls.Add(this._checkBoxNonSmoke);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._textBoxTime);
            this.Controls.Add(this._date);
            this.Controls.Add(this._textBoxCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxName);
            this.Name = "ReserveForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBoxCount;
        private System.Windows.Forms.MonthCalendar _date;
        private System.Windows.Forms.TextBox _textBoxTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.CheckBox _checkBoxNonSmoke;
    }
}