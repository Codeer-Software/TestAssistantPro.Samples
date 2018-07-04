namespace DemoApp
{
    partial class Demo
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
            this._tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._employee = new DemoApp.EmployeeControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._schedule = new DemoApp.ScheduleControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._allControl = new DemoApp.AllControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.originalControl1 = new DemoApp.OriginalControl();
            this._tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tab
            // 
            this._tab.Controls.Add(this.tabPage1);
            this._tab.Controls.Add(this.tabPage2);
            this._tab.Controls.Add(this.tabPage3);
            this._tab.Controls.Add(this.tabPage4);
            this._tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tab.Location = new System.Drawing.Point(0, 0);
            this._tab.Name = "_tab";
            this._tab.SelectedIndex = 0;
            this._tab.Size = new System.Drawing.Size(1032, 517);
            this._tab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._employee);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(993, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Sample";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _employee
            // 
            this._employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this._employee.Location = new System.Drawing.Point(3, 3);
            this._employee.Name = "_employee";
            this._employee.Size = new System.Drawing.Size(987, 495);
            this._employee.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._schedule);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reserve Sample";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _schedule
            // 
            this._schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this._schedule.Location = new System.Drawing.Point(3, 3);
            this._schedule.Name = "_schedule";
            this._schedule.Size = new System.Drawing.Size(696, 307);
            this._schedule.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._allControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1024, 491);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "All Controls";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _allControl
            // 
            this._allControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._allControl.Location = new System.Drawing.Point(0, 0);
            this._allControl.Name = "_allControl";
            this._allControl.Size = new System.Drawing.Size(1024, 491);
            this._allControl.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.originalControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(702, 313);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Original Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // originalControl1
            // 
            this.originalControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalControl1.Location = new System.Drawing.Point(0, 0);
            this.originalControl1.Name = "originalControl1";
            this.originalControl1.Size = new System.Drawing.Size(702, 313);
            this.originalControl1.TabIndex = 0;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 517);
            this.Controls.Add(this._tab);
            this.Name = "Demo";
            this.Text = "Demo";
            this._tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EmployeeControl _employee;
        private ScheduleControl _schedule;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private AllControl _allControl;
        private OriginalControl originalControl1;
    }
}

