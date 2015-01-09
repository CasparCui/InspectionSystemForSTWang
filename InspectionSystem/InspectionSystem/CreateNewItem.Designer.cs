namespace InspectionSystem
{
    partial class CreateNewItem
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
            if (disposing&&( components!=null ))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewItem));
            this.ProjectId = new System.Windows.Forms.Label();
            this._Name = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Dictionary = new System.Windows.Forms.Label();
            this.ProjectIdText = new System.Windows.Forms.TextBox();
            this.DateData = new System.Windows.Forms.DateTimePicker();
            this.NameText = new System.Windows.Forms.TextBox();
            this.DictionaryText = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectId
            // 
            this.ProjectId.AutoSize = true;
            this.ProjectId.Location = new System.Drawing.Point(27, 14);
            this.ProjectId.Name = "ProjectId";
            this.ProjectId.Size = new System.Drawing.Size(31, 13);
            this.ProjectId.TabIndex = 0;
            this.ProjectId.Text = "编号";
            // 
            // _Name
            // 
            this._Name.AutoSize = true;
            this._Name.Location = new System.Drawing.Point(27, 50);
            this._Name.Name = "_Name";
            this._Name.Size = new System.Drawing.Size(31, 13);
            this._Name.TabIndex = 1;
            this._Name.Text = "名称";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(199, 14);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(31, 13);
            this.Date.TabIndex = 2;
            this.Date.Text = "日期";
            // 
            // Dictionary
            // 
            this.Dictionary.AutoSize = true;
            this.Dictionary.Location = new System.Drawing.Point(27, 86);
            this.Dictionary.Name = "Dictionary";
            this.Dictionary.Size = new System.Drawing.Size(31, 13);
            this.Dictionary.TabIndex = 3;
            this.Dictionary.Text = "备注";
            // 
            // ProjectIdText
            // 
            this.ProjectIdText.Location = new System.Drawing.Point(74, 11);
            this.ProjectIdText.Name = "ProjectIdText";
            this.ProjectIdText.Size = new System.Drawing.Size(100, 20);
            this.ProjectIdText.TabIndex = 4;
            // 
            // DateData
            // 
            this.DateData.Location = new System.Drawing.Point(246, 11);
            this.DateData.Name = "DateData";
            this.DateData.Size = new System.Drawing.Size(121, 20);
            this.DateData.TabIndex = 5;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(74, 47);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(293, 20);
            this.NameText.TabIndex = 6;
            // 
            // DictionaryText
            // 
            this.DictionaryText.Location = new System.Drawing.Point(74, 82);
            this.DictionaryText.Name = "DictionaryText";
            this.DictionaryText.Size = new System.Drawing.Size(293, 20);
            this.DictionaryText.TabIndex = 7;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(246, 111);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 25);
            this.CreateButton.TabIndex = 8;
            this.CreateButton.Text = "添加";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(327, 111);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "取消";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 148);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DictionaryText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.DateData);
            this.Controls.Add(this.ProjectIdText);
            this.Controls.Add(this.Dictionary);
            this.Controls.Add(this.Date);
            this.Controls.Add(this._Name);
            this.Controls.Add(this.ProjectId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(443, 187);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(443, 187);
            this.Name = "CreateNewItem";
            this.Text = "添加工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProjectId;
        private System.Windows.Forms.Label _Name;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Dictionary;
        private System.Windows.Forms.TextBox ProjectIdText;
        private System.Windows.Forms.DateTimePicker DateData;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox DictionaryText;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
    }
}