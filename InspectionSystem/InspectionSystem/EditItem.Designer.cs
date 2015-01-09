namespace InspectionSystem
{
    partial class EditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
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
            resources.ApplyResources(this.ProjectId, "ProjectId");
            this.ProjectId.Name = "ProjectId";
            // 
            // _Name
            // 
            resources.ApplyResources(this._Name, "_Name");
            this._Name.Name = "_Name";
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            this.Date.Name = "Date";
            // 
            // Dictionary
            // 
            resources.ApplyResources(this.Dictionary, "Dictionary");
            this.Dictionary.Name = "Dictionary";
            // 
            // ProjectIdText
            // 
            resources.ApplyResources(this.ProjectIdText, "ProjectIdText");
            this.ProjectIdText.Name = "ProjectIdText";
            // 
            // DateData
            // 
            resources.ApplyResources(this.DateData, "DateData");
            this.DateData.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DateData.Name = "DateData";
            // 
            // NameText
            // 
            resources.ApplyResources(this.NameText, "NameText");
            this.NameText.Name = "NameText";
            // 
            // DictionaryText
            // 
            resources.ApplyResources(this.DictionaryText, "DictionaryText");
            this.DictionaryText.Name = "DictionaryText";
            // 
            // CreateButton
            // 
            resources.ApplyResources(this.CreateButton, "CreateButton");
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditItem";
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