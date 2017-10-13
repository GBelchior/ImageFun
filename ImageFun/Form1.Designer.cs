namespace ImageFun
{
    partial class Form1
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
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.picCreated = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkFaster = new System.Windows.Forms.CheckBox();
            this.chkFast = new System.Windows.Forms.CheckBox();
            this.nudEllipseY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEllipseX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIterations = new System.Windows.Forms.Label();
            this.prgIterations = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSearchImage = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCreated)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOriginal.Location = new System.Drawing.Point(4, 71);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(384, 366);
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // tblMain
            // 
            this.tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Controls.Add(this.picCreated, 1, 1);
            this.tblMain.Controls.Add(this.picOriginal, 0, 1);
            this.tblMain.Controls.Add(this.panel1, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(784, 441);
            this.tblMain.TabIndex = 1;
            // 
            // picCreated
            // 
            this.picCreated.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCreated.Location = new System.Drawing.Point(395, 71);
            this.picCreated.Name = "picCreated";
            this.picCreated.Size = new System.Drawing.Size(385, 366);
            this.picCreated.TabIndex = 1;
            this.picCreated.TabStop = false;
            // 
            // panel1
            // 
            this.tblMain.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.chkFaster);
            this.panel1.Controls.Add(this.chkFast);
            this.panel1.Controls.Add(this.nudEllipseY);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nudEllipseX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblIterations);
            this.panel1.Controls.Add(this.prgIterations);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nudIterations);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnSearchImage);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(782, 66);
            this.panel1.TabIndex = 2;
            // 
            // chkFaster
            // 
            this.chkFaster.AutoSize = true;
            this.chkFaster.Location = new System.Drawing.Point(527, 10);
            this.chkFaster.Name = "chkFaster";
            this.chkFaster.Size = new System.Drawing.Size(55, 17);
            this.chkFaster.TabIndex = 13;
            this.chkFaster.Text = "Faster";
            this.chkFaster.UseVisualStyleBackColor = true;
            // 
            // chkFast
            // 
            this.chkFast.AutoSize = true;
            this.chkFast.Location = new System.Drawing.Point(475, 10);
            this.chkFast.Name = "chkFast";
            this.chkFast.Size = new System.Drawing.Size(46, 17);
            this.chkFast.TabIndex = 12;
            this.chkFast.Text = "Fast";
            this.chkFast.UseVisualStyleBackColor = true;
            // 
            // nudEllipseY
            // 
            this.nudEllipseY.Location = new System.Drawing.Point(179, 36);
            this.nudEllipseY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudEllipseY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEllipseY.Name = "nudEllipseY";
            this.nudEllipseY.Size = new System.Drawing.Size(49, 20);
            this.nudEllipseY.TabIndex = 11;
            this.nudEllipseY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudEllipseY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ellipse Y:";
            // 
            // nudEllipseX
            // 
            this.nudEllipseX.Location = new System.Drawing.Point(68, 36);
            this.nudEllipseX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudEllipseX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEllipseX.Name = "nudEllipseX";
            this.nudEllipseX.Size = new System.Drawing.Size(49, 20);
            this.nudEllipseX.TabIndex = 9;
            this.nudEllipseX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudEllipseX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ellipse X:";
            // 
            // lblIterations
            // 
            this.lblIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(551, 38);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(0, 13);
            this.lblIterations.TabIndex = 7;
            // 
            // prgIterations
            // 
            this.prgIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgIterations.Location = new System.Drawing.Point(234, 34);
            this.prgIterations.Name = "prgIterations";
            this.prgIterations.Size = new System.Drawing.Size(311, 23);
            this.prgIterations.TabIndex = 6;
            this.prgIterations.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(591, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Iterations:";
            // 
            // nudIterations
            // 
            this.nudIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIterations.Location = new System.Drawing.Point(650, 9);
            this.nudIterations.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(120, 20);
            this.nudIterations.TabIndex = 4;
            this.nudIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(695, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSearchImage
            // 
            this.btnSearchImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchImage.Location = new System.Drawing.Point(434, 6);
            this.btnSearchImage.Name = "btnSearchImage";
            this.btnSearchImage.Size = new System.Drawing.Size(35, 23);
            this.btnSearchImage.TabIndex = 2;
            this.btnSearchImage.Text = "...";
            this.btnSearchImage.UseVisualStyleBackColor = true;
            this.btnSearchImage.Click += new System.EventHandler(this.btnSearchImage_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(94, 8);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(334, 20);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Image:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.tblMain);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCreated)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.PictureBox picCreated;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.ProgressBar prgIterations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSearchImage;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown nudEllipseY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudEllipseX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFaster;
        private System.Windows.Forms.CheckBox chkFast;
    }
}

