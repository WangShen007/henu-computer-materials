namespace ClientWinFormsExamples.ch07.E06
{
    partial class E0706DrawForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panelDraw = new Panel();
            groupBox1 = new GroupBox();
            rbImage = new RadioButton();
            rbCurve = new RadioButton();
            rbArrowCurve = new RadioButton();
            rbText = new RadioButton();
            radioButton1 = new RadioButton();
            rbRectangle = new RadioButton();
            rbPointer = new RadioButton();
            uc1 = new PanelUC();
            textBoxServer = new TextBox();
            label1 = new Label();
            buttonOK = new Button();
            label2 = new Label();
            panelServerIP = new Panel();
            labelUserName = new Label();
            buttonSave = new Button();
            labelStatus = new Label();
            panelDraw.SuspendLayout();
            groupBox1.SuspendLayout();
            panelServerIP.SuspendLayout();
            SuspendLayout();
            // 
            // panelDraw
            // 
            panelDraw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDraw.Controls.Add(groupBox1);
            panelDraw.Controls.Add(uc1);
            panelDraw.Location = new Point(18, 65);
            panelDraw.Name = "panelDraw";
            panelDraw.Size = new Size(864, 238);
            panelDraw.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbImage);
            groupBox1.Controls.Add(rbCurve);
            groupBox1.Controls.Add(rbArrowCurve);
            groupBox1.Controls.Add(rbText);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(rbRectangle);
            groupBox1.Controls.Add(rbPointer);
            groupBox1.Location = new Point(22, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(112, 224);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "绘制类型";
            // 
            // rbImage
            // 
            rbImage.AutoSize = true;
            rbImage.Location = new Point(12, 186);
            rbImage.Name = "rbImage";
            rbImage.Size = new Size(50, 21);
            rbImage.TabIndex = 0;
            rbImage.Text = "图像";
            rbImage.UseVisualStyleBackColor = true;
            // 
            // rbCurve
            // 
            rbCurve.AutoSize = true;
            rbCurve.Location = new Point(12, 132);
            rbCurve.Name = "rbCurve";
            rbCurve.Size = new Size(50, 21);
            rbCurve.TabIndex = 0;
            rbCurve.Text = "曲线";
            rbCurve.UseVisualStyleBackColor = true;
            // 
            // rbArrowCurve
            // 
            rbArrowCurve.AutoSize = true;
            rbArrowCurve.Location = new Point(12, 159);
            rbArrowCurve.Name = "rbArrowCurve";
            rbArrowCurve.Size = new Size(74, 21);
            rbArrowCurve.TabIndex = 0;
            rbArrowCurve.Text = "箭头曲线";
            rbArrowCurve.UseVisualStyleBackColor = true;
            // 
            // rbText
            // 
            rbText.AutoSize = true;
            rbText.Location = new Point(12, 105);
            rbText.Name = "rbText";
            rbText.Size = new Size(50, 21);
            rbText.TabIndex = 0;
            rbText.Text = "文字";
            rbText.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 78);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 21);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "椭圆";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbRectangle
            // 
            rbRectangle.AutoSize = true;
            rbRectangle.Location = new Point(12, 51);
            rbRectangle.Name = "rbRectangle";
            rbRectangle.Size = new Size(50, 21);
            rbRectangle.TabIndex = 0;
            rbRectangle.Text = "矩形";
            rbRectangle.UseVisualStyleBackColor = true;
            // 
            // rbPointer
            // 
            rbPointer.AutoSize = true;
            rbPointer.Checked = true;
            rbPointer.Location = new Point(12, 24);
            rbPointer.Name = "rbPointer";
            rbPointer.Size = new Size(50, 21);
            rbPointer.TabIndex = 0;
            rbPointer.TabStop = true;
            rbPointer.Text = "框选";
            rbPointer.UseVisualStyleBackColor = true;
            // 
            // uc1
            // 
            uc1.ActiveTool = ToolType.Pointer;
            uc1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uc1.BackColor = Color.MintCream;
            uc1.BorderStyle = BorderStyle.FixedSingle;
            uc1.Graphics = null;
            uc1.ID = 1;
            uc1.IsDrawNetRectangle = false;
            uc1.Location = new Point(153, 0);
            uc1.Margin = new Padding(4, 4, 4, 4);
            uc1.MyClient = null;
            uc1.Name = "uc1";
            uc1.NetRectangle = new Rectangle(0, 0, 0, 0);
            uc1.Size = new Size(694, 234);
            uc1.TabIndex = 3;
            uc1.Tools = null;
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(271, 15);
            textBoxServer.Margin = new Padding(4);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(153, 23);
            textBoxServer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(197, 18);
            label1.Name = "label1";
            label1.Size = new Size(67, 17);
            label1.TabIndex = 0;
            label1.Text = "服务器IP：";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(498, 18);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(85, 33);
            buttonOK.TabIndex = 11;
            buttonOK.Text = "登录";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 18);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 12;
            label2.Text = "用户名：";
            // 
            // panelServerIP
            // 
            panelServerIP.Controls.Add(textBoxServer);
            panelServerIP.Controls.Add(labelUserName);
            panelServerIP.Controls.Add(label2);
            panelServerIP.Controls.Add(label1);
            panelServerIP.Location = new Point(19, 8);
            panelServerIP.Name = "panelServerIP";
            panelServerIP.Size = new Size(453, 51);
            panelServerIP.TabIndex = 6;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(65, 18);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(98, 17);
            labelUserName.TabIndex = 12;
            labelUserName.Text = "labelUserName";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(639, 18);
            buttonSave.Margin = new Padding(4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(171, 33);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "将绘图结果导出为.jpg文件";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelStatus.BorderStyle = BorderStyle.FixedSingle;
            labelStatus.Location = new Point(18, 316);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(864, 23);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "labelStatus";
            // 
            // E0706DrawForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(899, 348);
            Controls.Add(labelStatus);
            Controls.Add(buttonSave);
            Controls.Add(buttonOK);
            Controls.Add(panelServerIP);
            Controls.Add(panelDraw);
            Margin = new Padding(4);
            MinimumSize = new Size(915, 380);
            Name = "E0706DrawForm";
            Text = "多机协同绘图系统";
            panelDraw.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelServerIP.ResumeLayout(false);
            panelServerIP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelDraw;
        private Label label1;
        private TextBox textBoxServer;
        private Button buttonOK;
        private GroupBox groupBox1;
        private PanelUC uc1;
        private RadioButton rbImage;
        private RadioButton rbCurve;
        private RadioButton rbArrowCurve;
        private RadioButton rbText;
        private RadioButton rbRectangle;
        private RadioButton rbPointer;
        private RadioButton radioButton1;
        private Label label2;
        private Panel panelServerIP;
        private Label labelUserName;
        private Button buttonSave;
        private Label labelStatus;
    }
}

