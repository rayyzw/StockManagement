namespace StockManagement
{
    partial class FormStockManagement
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
            this.components = new System.ComponentModel.Container();
            this.treeViewStock = new System.Windows.Forms.TreeView();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.buttonRequest = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.checkedListBoxRecord = new System.Windows.Forms.CheckedListBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonShowLocation = new System.Windows.Forms.Button();
            this.textBoxTrackingNo = new System.Windows.Forms.TextBox();
            this.labelTrackingNo = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonAddStockType = new System.Windows.Forms.Button();
            this.buttonAddStock = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOderList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewStock
            // 
            this.treeViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewStock.Location = new System.Drawing.Point(242, 18);
            this.treeViewStock.Name = "treeViewStock";
            this.treeViewStock.Size = new System.Drawing.Size(724, 406);
            this.treeViewStock.TabIndex = 2;
            // 
            // listBoxUser
            // 
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.Location = new System.Drawing.Point(12, 18);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(84, 407);
            this.listBoxUser.TabIndex = 4;
            this.listBoxUser.SelectedIndexChanged += new System.EventHandler(this.listBoxUser_SelectedIndexChanged);
            // 
            // buttonRequest
            // 
            this.buttonRequest.Location = new System.Drawing.Point(132, 134);
            this.buttonRequest.Name = "buttonRequest";
            this.buttonRequest.Size = new System.Drawing.Size(75, 23);
            this.buttonRequest.TabIndex = 5;
            this.buttonRequest.Text = "request";
            this.buttonRequest.UseVisualStyleBackColor = true;
            this.buttonRequest.Click += new System.EventHandler(this.buttonRequest_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(132, 163);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 6;
            this.buttonReturn.Text = "return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // checkedListBoxRecord
            // 
            this.checkedListBoxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxRecord.FormattingEnabled = true;
            this.checkedListBoxRecord.Location = new System.Drawing.Point(12, 430);
            this.checkedListBoxRecord.Name = "checkedListBoxRecord";
            this.checkedListBoxRecord.Size = new System.Drawing.Size(954, 184);
            this.checkedListBoxRecord.TabIndex = 7;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(774, 625);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 8;
            this.buttonProcess.Text = "process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonShowLocation
            // 
            this.buttonShowLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowLocation.Location = new System.Drawing.Point(855, 625);
            this.buttonShowLocation.Name = "buttonShowLocation";
            this.buttonShowLocation.Size = new System.Drawing.Size(111, 23);
            this.buttonShowLocation.TabIndex = 9;
            this.buttonShowLocation.Text = "show location";
            this.buttonShowLocation.UseVisualStyleBackColor = true;
            this.buttonShowLocation.Click += new System.EventHandler(this.buttonShowLocation_Click);
            // 
            // textBoxTrackingNo
            // 
            this.textBoxTrackingNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTrackingNo.Location = new System.Drawing.Point(668, 627);
            this.textBoxTrackingNo.Name = "textBoxTrackingNo";
            this.textBoxTrackingNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTrackingNo.TabIndex = 10;
            // 
            // labelTrackingNo
            // 
            this.labelTrackingNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTrackingNo.AutoSize = true;
            this.labelTrackingNo.Location = new System.Drawing.Point(599, 630);
            this.labelTrackingNo.Name = "labelTrackingNo";
            this.labelTrackingNo.Size = new System.Drawing.Size(63, 13);
            this.labelTrackingNo.TabIndex = 11;
            this.labelTrackingNo.Text = "tracking no.";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 346);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(134, 20);
            this.textBoxName.TabIndex = 12;
            // 
            // buttonAddStockType
            // 
            this.buttonAddStockType.Location = new System.Drawing.Point(102, 372);
            this.buttonAddStockType.Name = "buttonAddStockType";
            this.buttonAddStockType.Size = new System.Drawing.Size(134, 23);
            this.buttonAddStockType.TabIndex = 13;
            this.buttonAddStockType.Text = "add type";
            this.buttonAddStockType.UseVisualStyleBackColor = true;
            this.buttonAddStockType.Click += new System.EventHandler(this.buttonAddStockType_Click);
            // 
            // buttonAddStock
            // 
            this.buttonAddStock.Location = new System.Drawing.Point(102, 401);
            this.buttonAddStock.Name = "buttonAddStock";
            this.buttonAddStock.Size = new System.Drawing.Size(134, 23);
            this.buttonAddStock.TabIndex = 14;
            this.buttonAddStock.Text = "add item";
            this.buttonAddStock.UseVisualStyleBackColor = true;
            this.buttonAddStock.Click += new System.EventHandler(this.buttonAddStock_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(102, 317);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(134, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOderList
            // 
            this.buttonOderList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOderList.Location = new System.Drawing.Point(12, 625);
            this.buttonOderList.Name = "buttonOderList";
            this.buttonOderList.Size = new System.Drawing.Size(75, 23);
            this.buttonOderList.TabIndex = 16;
            this.buttonOderList.Text = "order list";
            this.buttonOderList.UseVisualStyleBackColor = true;
            this.buttonOderList.Click += new System.EventHandler(this.buttonOderList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "WindowsUser:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(121, 79);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 18;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(132, 105);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 19;
            this.buttonSearch.Text = "search item";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 660);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOderList);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddStock);
            this.Controls.Add(this.buttonAddStockType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelTrackingNo);
            this.Controls.Add(this.textBoxTrackingNo);
            this.Controls.Add(this.buttonShowLocation);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.checkedListBoxRecord);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonRequest);
            this.Controls.Add(this.listBoxUser);
            this.Controls.Add(this.treeViewStock);
            this.Name = "Form1";
            this.Text = "LinkPoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewStock;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.Button buttonRequest;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.CheckedListBox checkedListBoxRecord;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonShowLocation;
        private System.Windows.Forms.TextBox textBoxTrackingNo;
        private System.Windows.Forms.Label labelTrackingNo;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonAddStockType;
        private System.Windows.Forms.Button buttonAddStock;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonOderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
    }
}

