namespace VisualInspec
{
    partial class Form_Picture
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxRaw = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDescrip = new System.Windows.Forms.Label();
            this.lbCurrPicNum = new System.Windows.Forms.Label();
            this.bttnSave = new System.Windows.Forms.Button();
            this.lbCurrSerialNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnQuit = new System.Windows.Forms.Button();
            this.bttnStart = new System.Windows.Forms.Button();
            this.tbJobNumStr = new System.Windows.Forms.TextBox();
            this.tbSerialChar = new System.Windows.Forms.TextBox();
            this.tbSerialStart = new System.Windows.Forms.TextBox();
            this.tbSerialEnd = new System.Windows.Forms.TextBox();
            this.tbSerialCurr = new System.Windows.Forms.TextBox();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.tbPictCurrNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bttnUpdate = new System.Windows.Forms.Button();
            this.cbCameraRes = new System.Windows.Forms.ComboBox();
            this.tbCameraFPS = new System.Windows.Forms.TextBox();
            this.bttnExpUp = new System.Windows.Forms.Button();
            this.bttnExpDown = new System.Windows.Forms.Button();
            this.bttnBrightDwn = new System.Windows.Forms.Button();
            this.bttnBrightUp = new System.Windows.Forms.Button();
            this.bttnManExposure = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaw)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBoxScreen);
            this.panel1.Controls.Add(this.pictureBoxRaw);
            this.panel1.Location = new System.Drawing.Point(13, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 480);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxScreen
            // 
            this.pictureBoxScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxScreen.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScreen.Name = "pictureBoxScreen";
            this.pictureBoxScreen.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScreen.TabIndex = 0;
            this.pictureBoxScreen.TabStop = false;
            // 
            // pictureBoxRaw
            // 
            this.pictureBoxRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRaw.Enabled = false;
            this.pictureBoxRaw.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRaw.Name = "pictureBoxRaw";
            this.pictureBoxRaw.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxRaw.TabIndex = 1;
            this.pictureBoxRaw.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbDescrip);
            this.panel2.Controls.Add(this.lbCurrPicNum);
            this.panel2.Controls.Add(this.bttnSave);
            this.panel2.Controls.Add(this.lbCurrSerialNum);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 501);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 100);
            this.panel2.TabIndex = 1;
            // 
            // lbDescrip
            // 
            this.lbDescrip.AutoSize = true;
            this.lbDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescrip.Location = new System.Drawing.Point(251, 64);
            this.lbDescrip.Name = "lbDescrip";
            this.lbDescrip.Size = new System.Drawing.Size(370, 20);
            this.lbDescrip.TabIndex = 9;
            this.lbDescrip.Text = "CURRENT DESCRIPTION OF THE PICTURE";
            // 
            // lbCurrPicNum
            // 
            this.lbCurrPicNum.AutoSize = true;
            this.lbCurrPicNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrPicNum.Location = new System.Drawing.Point(251, 37);
            this.lbCurrPicNum.Name = "lbCurrPicNum";
            this.lbCurrPicNum.Size = new System.Drawing.Size(64, 17);
            this.lbCurrPicNum.TabIndex = 8;
            this.lbCurrPicNum.Text = "PIC NUM";
            // 
            // bttnSave
            // 
            this.bttnSave.Location = new System.Drawing.Point(18, 29);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(92, 42);
            this.bttnSave.TabIndex = 2;
            this.bttnSave.Text = "S&ave";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // lbCurrSerialNum
            // 
            this.lbCurrSerialNum.AutoSize = true;
            this.lbCurrSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrSerialNum.Location = new System.Drawing.Point(251, 10);
            this.lbCurrSerialNum.Name = "lbCurrSerialNum";
            this.lbCurrSerialNum.Size = new System.Drawing.Size(130, 20);
            this.lbCurrSerialNum.TabIndex = 7;
            this.lbCurrSerialNum.Text = "CURR SERIAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Serial Num";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Pic Num";
            // 
            // bttnQuit
            // 
            this.bttnQuit.Location = new System.Drawing.Point(873, 526);
            this.bttnQuit.Name = "bttnQuit";
            this.bttnQuit.Size = new System.Drawing.Size(75, 42);
            this.bttnQuit.TabIndex = 3;
            this.bttnQuit.Text = "&Quit";
            this.bttnQuit.UseVisualStyleBackColor = true;
            this.bttnQuit.Click += new System.EventHandler(this.bttnQuit_Click);
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(697, 526);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(90, 42);
            this.bttnStart.TabIndex = 1;
            this.bttnStart.Text = "Start";
            this.bttnStart.UseVisualStyleBackColor = true;
            this.bttnStart.Click += new System.EventHandler(this.bttnStart_Click);
            // 
            // tbJobNumStr
            // 
            this.tbJobNumStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJobNumStr.Location = new System.Drawing.Point(697, 39);
            this.tbJobNumStr.Name = "tbJobNumStr";
            this.tbJobNumStr.Size = new System.Drawing.Size(233, 23);
            this.tbJobNumStr.TabIndex = 4;
            this.tbJobNumStr.Text = "Job Num Str";
            // 
            // tbSerialChar
            // 
            this.tbSerialChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialChar.Location = new System.Drawing.Point(697, 68);
            this.tbSerialChar.Name = "tbSerialChar";
            this.tbSerialChar.Size = new System.Drawing.Size(233, 23);
            this.tbSerialChar.TabIndex = 5;
            this.tbSerialChar.Text = "Serial Char";
            // 
            // tbSerialStart
            // 
            this.tbSerialStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialStart.Location = new System.Drawing.Point(697, 97);
            this.tbSerialStart.Name = "tbSerialStart";
            this.tbSerialStart.Size = new System.Drawing.Size(233, 23);
            this.tbSerialStart.TabIndex = 6;
            this.tbSerialStart.Text = "Serial Start";
            // 
            // tbSerialEnd
            // 
            this.tbSerialEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialEnd.Location = new System.Drawing.Point(697, 126);
            this.tbSerialEnd.Name = "tbSerialEnd";
            this.tbSerialEnd.Size = new System.Drawing.Size(233, 23);
            this.tbSerialEnd.TabIndex = 7;
            this.tbSerialEnd.Text = "Serial End";
            // 
            // tbSerialCurr
            // 
            this.tbSerialCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialCurr.Location = new System.Drawing.Point(697, 155);
            this.tbSerialCurr.Name = "tbSerialCurr";
            this.tbSerialCurr.Size = new System.Drawing.Size(233, 23);
            this.tbSerialCurr.TabIndex = 8;
            this.tbSerialCurr.Text = "Serial Curr";
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutputPath.Location = new System.Drawing.Point(697, 266);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.Size = new System.Drawing.Size(233, 23);
            this.tbOutputPath.TabIndex = 9;
            this.tbOutputPath.Text = "Output path";
            // 
            // tbPictCurrNum
            // 
            this.tbPictCurrNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPictCurrNum.Location = new System.Drawing.Point(697, 212);
            this.tbPictCurrNum.Name = "tbPictCurrNum";
            this.tbPictCurrNum.Size = new System.Drawing.Size(233, 23);
            this.tbPictCurrNum.TabIndex = 10;
            this.tbPictCurrNum.Text = "Pict Curr Num";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current Picture Number";
            // 
            // bttnUpdate
            // 
            this.bttnUpdate.Location = new System.Drawing.Point(697, 359);
            this.bttnUpdate.Name = "bttnUpdate";
            this.bttnUpdate.Size = new System.Drawing.Size(90, 42);
            this.bttnUpdate.TabIndex = 12;
            this.bttnUpdate.Text = "Update";
            this.bttnUpdate.UseVisualStyleBackColor = true;
            this.bttnUpdate.Click += new System.EventHandler(this.bttnUpdate_Click);
            // 
            // cbCameraRes
            // 
            this.cbCameraRes.FormattingEnabled = true;
            this.cbCameraRes.Items.AddRange(new object[] {
            "VGA",
            "HP  hires",
            "Laptop  hires"});
            this.cbCameraRes.Location = new System.Drawing.Point(697, 321);
            this.cbCameraRes.Name = "cbCameraRes";
            this.cbCameraRes.Size = new System.Drawing.Size(121, 21);
            this.cbCameraRes.TabIndex = 13;
            // 
            // tbCameraFPS
            // 
            this.tbCameraFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCameraFPS.Location = new System.Drawing.Point(842, 321);
            this.tbCameraFPS.Name = "tbCameraFPS";
            this.tbCameraFPS.Size = new System.Drawing.Size(88, 23);
            this.tbCameraFPS.TabIndex = 14;
            this.tbCameraFPS.Text = "FPS";
            // 
            // bttnExpUp
            // 
            this.bttnExpUp.Location = new System.Drawing.Point(840, 394);
            this.bttnExpUp.Name = "bttnExpUp";
            this.bttnExpUp.Size = new System.Drawing.Size(51, 42);
            this.bttnExpUp.TabIndex = 15;
            this.bttnExpUp.Text = "+Exp";
            this.bttnExpUp.UseVisualStyleBackColor = true;
            this.bttnExpUp.Click += new System.EventHandler(this.bttnExpUp_Click);
            // 
            // bttnExpDown
            // 
            this.bttnExpDown.Location = new System.Drawing.Point(840, 445);
            this.bttnExpDown.Name = "bttnExpDown";
            this.bttnExpDown.Size = new System.Drawing.Size(51, 42);
            this.bttnExpDown.TabIndex = 16;
            this.bttnExpDown.Text = "- Exp";
            this.bttnExpDown.UseVisualStyleBackColor = true;
            this.bttnExpDown.Click += new System.EventHandler(this.bttnExpDown_Click);
            // 
            // bttnBrightDwn
            // 
            this.bttnBrightDwn.Location = new System.Drawing.Point(897, 445);
            this.bttnBrightDwn.Name = "bttnBrightDwn";
            this.bttnBrightDwn.Size = new System.Drawing.Size(51, 42);
            this.bttnBrightDwn.TabIndex = 18;
            this.bttnBrightDwn.Text = "- Bright";
            this.bttnBrightDwn.UseVisualStyleBackColor = true;
            this.bttnBrightDwn.Click += new System.EventHandler(this.bttnBrightDwn_Click);
            // 
            // bttnBrightUp
            // 
            this.bttnBrightUp.Location = new System.Drawing.Point(897, 394);
            this.bttnBrightUp.Name = "bttnBrightUp";
            this.bttnBrightUp.Size = new System.Drawing.Size(51, 42);
            this.bttnBrightUp.TabIndex = 17;
            this.bttnBrightUp.Text = "+Bright";
            this.bttnBrightUp.UseVisualStyleBackColor = true;
            this.bttnBrightUp.Click += new System.EventHandler(this.bttnBrightUp_Click);
            // 
            // bttnManExposure
            // 
            this.bttnManExposure.Location = new System.Drawing.Point(783, 425);
            this.bttnManExposure.Name = "bttnManExposure";
            this.bttnManExposure.Size = new System.Drawing.Size(51, 42);
            this.bttnManExposure.TabIndex = 19;
            this.bttnManExposure.Text = "Man Exp";
            this.bttnManExposure.UseVisualStyleBackColor = true;
            this.bttnManExposure.Click += new System.EventHandler(this.bttnManExposure_Click);
            // 
            // Form_Picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 607);
            this.Controls.Add(this.bttnManExposure);
            this.Controls.Add(this.bttnBrightDwn);
            this.Controls.Add(this.bttnBrightUp);
            this.Controls.Add(this.bttnExpDown);
            this.Controls.Add(this.bttnExpUp);
            this.Controls.Add(this.tbCameraFPS);
            this.Controls.Add(this.cbCameraRes);
            this.Controls.Add(this.bttnUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPictCurrNum);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.tbSerialCurr);
            this.Controls.Add(this.tbSerialEnd);
            this.Controls.Add(this.tbSerialStart);
            this.Controls.Add(this.tbSerialChar);
            this.Controls.Add(this.tbJobNumStr);
            this.Controls.Add(this.bttnQuit);
            this.Controls.Add(this.bttnStart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Picture";
            this.Text = "Visual Inspection Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Picture_FormClosing);
            this.Load += new System.EventHandler(this.Form_Picture_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Picture_Paint);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaw)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxScreen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.PictureBox pictureBoxRaw;
        private System.Windows.Forms.Button bttnQuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDescrip;
        private System.Windows.Forms.Label lbCurrPicNum;
        private System.Windows.Forms.Label lbCurrSerialNum;
        private System.Windows.Forms.TextBox tbJobNumStr;
        private System.Windows.Forms.TextBox tbSerialChar;
        private System.Windows.Forms.TextBox tbSerialStart;
        private System.Windows.Forms.TextBox tbSerialEnd;
        private System.Windows.Forms.TextBox tbSerialCurr;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.TextBox tbPictCurrNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttnUpdate;
        private System.Windows.Forms.ComboBox cbCameraRes;
        private System.Windows.Forms.TextBox tbCameraFPS;
        private System.Windows.Forms.Button bttnExpUp;
        private System.Windows.Forms.Button bttnExpDown;
        private System.Windows.Forms.Button bttnBrightDwn;
        private System.Windows.Forms.Button bttnBrightUp;
        private System.Windows.Forms.Button bttnManExposure;
    }
}

