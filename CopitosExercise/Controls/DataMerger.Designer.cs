namespace CopitosExercise.Views.Controls
{
    partial class DataMerger
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataMerger));
            this.btnUploadExcel = new System.Windows.Forms.Button();
            this.btnUploadCsv = new System.Windows.Forms.Button();
            this.btnSaveAsPdf = new System.Windows.Forms.Button();
            this.grdMergedData = new System.Windows.Forms.DataGridView();
            this.dlgExcel = new System.Windows.Forms.OpenFileDialog();
            this.dlgCsv = new System.Windows.Forms.OpenFileDialog();
            this.btnMergeData = new System.Windows.Forms.Button();
            this.pnlDataMergerContent = new System.Windows.Forms.Panel();
            this.btnIconCsv = new System.Windows.Forms.Button();
            this.btnIconExcel = new System.Windows.Forms.Button();
            this.btnResetData = new System.Windows.Forms.Button();
            this.dlgSavePdf = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdMergedData)).BeginInit();
            this.pnlDataMergerContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUploadExcel
            // 
            this.btnUploadExcel.Location = new System.Drawing.Point(336, 16);
            this.btnUploadExcel.Name = "btnUploadExcel";
            this.btnUploadExcel.Size = new System.Drawing.Size(109, 44);
            this.btnUploadExcel.TabIndex = 0;
            this.btnUploadExcel.Text = "Excel hochladen";
            this.btnUploadExcel.UseVisualStyleBackColor = true;
            this.btnUploadExcel.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // btnUploadCsv
            // 
            this.btnUploadCsv.Location = new System.Drawing.Point(629, 16);
            this.btnUploadCsv.Name = "btnUploadCsv";
            this.btnUploadCsv.Size = new System.Drawing.Size(109, 44);
            this.btnUploadCsv.TabIndex = 1;
            this.btnUploadCsv.Text = "CSV hochladen";
            this.btnUploadCsv.UseVisualStyleBackColor = true;
            this.btnUploadCsv.Click += new System.EventHandler(this.btnUploadCsv_Click);
            // 
            // btnSaveAsPdf
            // 
            this.btnSaveAsPdf.Location = new System.Drawing.Point(346, 464);
            this.btnSaveAsPdf.Name = "btnSaveAsPdf";
            this.btnSaveAsPdf.Size = new System.Drawing.Size(147, 36);
            this.btnSaveAsPdf.TabIndex = 3;
            this.btnSaveAsPdf.Text = "PDF exportieren";
            this.btnSaveAsPdf.UseVisualStyleBackColor = true;
            this.btnSaveAsPdf.Click += new System.EventHandler(this.btnSaveAsPdf_Click);
            // 
            // grdMergedData
            // 
            this.grdMergedData.AllowUserToAddRows = false;
            this.grdMergedData.AllowUserToDeleteRows = false;
            this.grdMergedData.AllowUserToResizeColumns = false;
            this.grdMergedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMergedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMergedData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMergedData.Location = new System.Drawing.Point(0, 149);
            this.grdMergedData.MultiSelect = false;
            this.grdMergedData.Name = "grdMergedData";
            this.grdMergedData.RowHeadersVisible = false;
            this.grdMergedData.Size = new System.Drawing.Size(1073, 308);
            this.grdMergedData.TabIndex = 4;
            this.grdMergedData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMergedData_CellClick);
            this.grdMergedData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMergedData_CellValueChanged);
            // 
            // dlgCsv
            // 
            this.dlgCsv.FileName = "openFileDialog1";
            // 
            // btnMergeData
            // 
            this.btnMergeData.Location = new System.Drawing.Point(488, 99);
            this.btnMergeData.Name = "btnMergeData";
            this.btnMergeData.Size = new System.Drawing.Size(147, 44);
            this.btnMergeData.TabIndex = 5;
            this.btnMergeData.Text = "Daten zusammenführen";
            this.btnMergeData.UseVisualStyleBackColor = true;
            this.btnMergeData.Click += new System.EventHandler(this.btnMergeData_Click);
            // 
            // pnlDataMergerContent
            // 
            this.pnlDataMergerContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataMergerContent.Controls.Add(this.btnIconCsv);
            this.pnlDataMergerContent.Controls.Add(this.btnIconExcel);
            this.pnlDataMergerContent.Controls.Add(this.btnResetData);
            this.pnlDataMergerContent.Controls.Add(this.btnMergeData);
            this.pnlDataMergerContent.Controls.Add(this.btnUploadExcel);
            this.pnlDataMergerContent.Controls.Add(this.btnUploadCsv);
            this.pnlDataMergerContent.Controls.Add(this.btnSaveAsPdf);
            this.pnlDataMergerContent.Controls.Add(this.grdMergedData);
            this.pnlDataMergerContent.Location = new System.Drawing.Point(0, 0);
            this.pnlDataMergerContent.Name = "pnlDataMergerContent";
            this.pnlDataMergerContent.Size = new System.Drawing.Size(1073, 511);
            this.pnlDataMergerContent.TabIndex = 6;
            // 
            // btnIconCsv
            // 
            this.btnIconCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnIconCsv.Image")));
            this.btnIconCsv.Location = new System.Drawing.Point(744, 16);
            this.btnIconCsv.Name = "btnIconCsv";
            this.btnIconCsv.Size = new System.Drawing.Size(42, 44);
            this.btnIconCsv.TabIndex = 8;
            this.btnIconCsv.UseVisualStyleBackColor = true;
            // 
            // btnIconExcel
            // 
            this.btnIconExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnIconExcel.Image")));
            this.btnIconExcel.Location = new System.Drawing.Point(451, 16);
            this.btnIconExcel.Name = "btnIconExcel";
            this.btnIconExcel.Size = new System.Drawing.Size(42, 44);
            this.btnIconExcel.TabIndex = 7;
            this.btnIconExcel.UseVisualStyleBackColor = true;
            // 
            // btnResetData
            // 
            this.btnResetData.Location = new System.Drawing.Point(623, 464);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(147, 36);
            this.btnResetData.TabIndex = 6;
            this.btnResetData.Text = "Alle Daten zurücksetzen";
            this.btnResetData.UseVisualStyleBackColor = true;
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // DataMerger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDataMergerContent);
            this.Name = "DataMerger";
            this.Size = new System.Drawing.Size(1074, 511);
            ((System.ComponentModel.ISupportInitialize)(this.grdMergedData)).EndInit();
            this.pnlDataMergerContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUploadExcel;
        private System.Windows.Forms.Button btnUploadCsv;
        private System.Windows.Forms.Button btnSaveAsPdf;
        private System.Windows.Forms.DataGridView grdMergedData;
        private System.Windows.Forms.OpenFileDialog dlgExcel;
        private System.Windows.Forms.OpenFileDialog dlgCsv;
        private System.Windows.Forms.Button btnMergeData;
        private System.Windows.Forms.Panel pnlDataMergerContent;
        private System.Windows.Forms.SaveFileDialog dlgSavePdf;
        private System.Windows.Forms.Button btnResetData;
        private System.Windows.Forms.Button btnIconExcel;
        private System.Windows.Forms.Button btnIconCsv;
    }
}
