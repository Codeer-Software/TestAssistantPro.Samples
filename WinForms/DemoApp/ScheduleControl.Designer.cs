namespace DemoApp
{
    partial class ScheduleControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._lsit = new System.Windows.Forms.ListBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lsit
            // 
            this._lsit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._lsit.FormattingEnabled = true;
            this._lsit.ItemHeight = 12;
            this._lsit.Location = new System.Drawing.Point(3, 3);
            this._lsit.Name = "_lsit";
            this._lsit.Size = new System.Drawing.Size(260, 364);
            this._lsit.TabIndex = 0;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(269, 3);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(129, 23);
            this._buttonAdd.TabIndex = 1;
            this._buttonAdd.Text = "Add reservation";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // ScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonAdd);
            this.Controls.Add(this._lsit);
            this.Name = "ScheduleControl";
            this.Size = new System.Drawing.Size(447, 377);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _lsit;
        private System.Windows.Forms.Button _buttonAdd;
    }
}
