namespace DemoApp
{
    partial class EmployeeControl
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
			this._grid = new System.Windows.Forms.DataGridView();
			this._colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._colEngineer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this._colEtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
			this.SuspendLayout();
			// 
			// _grid
			// 
			this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colName,
            this._colAge,
            this._colEngineer,
            this._colEtc});
			this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this._grid.Location = new System.Drawing.Point(0, 0);
			this._grid.Name = "_grid";
			this._grid.RowTemplate.Height = 21;
			this._grid.Size = new System.Drawing.Size(571, 404);
			this._grid.TabIndex = 0;
			// 
			// _colName
			// 
			this._colName.HeaderText = "Name";
			this._colName.Name = "_colName";
			// 
			// _colAge
			// 
			this._colAge.HeaderText = "Age";
			this._colAge.Name = "_colAge";
			// 
			// _colEngineer
			// 
			this._colEngineer.HeaderText = "IsEngineer";
			this._colEngineer.Name = "_colEngineer";
			// 
			// _colEtc
			// 
			this._colEtc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this._colEtc.HeaderText = "Other";
			this._colEtc.Name = "_colEtc";
			// 
			// EmployeeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._grid);
			this.Name = "EmployeeControl";
			this.Size = new System.Drawing.Size(571, 404);
			((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grid;
		private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn _colAge;
		private System.Windows.Forms.DataGridViewCheckBoxColumn _colEngineer;
		private System.Windows.Forms.DataGridViewTextBoxColumn _colEtc;
	}
}
