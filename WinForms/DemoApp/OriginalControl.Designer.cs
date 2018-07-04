namespace DemoApp
{
    partial class OriginalControl
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
            this._buttonAdd = new System.Windows.Forms.Button();
            this._blockControl = new DemoApp.BlockControl();
            this.SuspendLayout();
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(3, 11);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(75, 23);
            this._buttonAdd.TabIndex = 1;
            this._buttonAdd.Text = "Add";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // _blockControl
            // 
            this._blockControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._blockControl.Location = new System.Drawing.Point(3, 40);
            this._blockControl.Name = "_blockControl";
            this._blockControl.SelectedIndex = -1;
            this._blockControl.Size = new System.Drawing.Size(353, 232);
            this._blockControl.TabIndex = 0;
            this._blockControl.Text = "blockControl1";
            // 
            // OriginalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._buttonAdd);
            this.Controls.Add(this._blockControl);
            this.Name = "OriginalControl";
            this.Size = new System.Drawing.Size(359, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private BlockControl _blockControl;
        private System.Windows.Forms.Button _buttonAdd;
    }
}
