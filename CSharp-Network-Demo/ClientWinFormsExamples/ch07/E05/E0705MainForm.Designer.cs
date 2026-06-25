namespace ClientWinFormsExamples.ch07.E05
{
    partial class E0705MainForm
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
            MyGraphicsList myGraphicsList1 = new MyGraphicsList();
            label1 = new Label();
            groupBox1 = new GroupBox();
            radioButtonArrowCurve = new RadioButton();
            radioButtonHandle = new RadioButton();
            radioButtonCurve = new RadioButton();
            myuc1 = new MyUC();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(668, 17);
            label1.Name = "label1";
            label1.Size = new Size(134, 257);
            label1.TabIndex = 5;
            label1.Text = "提示：单击按钮选择要绘制的图形，然后按住鼠标左键拖动鼠标绘制，鼠标右击停止绘制。停止绘制后，移动鼠标到绘制的矩形上，观察鼠标指针形状变化，拖动它观察结果。";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonArrowCurve);
            groupBox1.Controls.Add(radioButtonHandle);
            groupBox1.Controls.Add(radioButtonCurve);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(107, 165);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "绘制类型";
            // 
            // radioButtonArrowCurve
            // 
            radioButtonArrowCurve.AutoSize = true;
            radioButtonArrowCurve.Location = new Point(15, 111);
            radioButtonArrowCurve.Name = "radioButtonArrowCurve";
            radioButtonArrowCurve.Size = new Size(74, 21);
            radioButtonArrowCurve.TabIndex = 0;
            radioButtonArrowCurve.Text = "箭头曲线";
            radioButtonArrowCurve.UseVisualStyleBackColor = true;
            // 
            // radioButtonHandle
            // 
            radioButtonHandle.AutoSize = true;
            radioButtonHandle.Checked = true;
            radioButtonHandle.Location = new Point(15, 35);
            radioButtonHandle.Name = "radioButtonHandle";
            radioButtonHandle.Size = new Size(50, 21);
            radioButtonHandle.TabIndex = 0;
            radioButtonHandle.TabStop = true;
            radioButtonHandle.Text = "句柄";
            radioButtonHandle.UseVisualStyleBackColor = true;
            // 
            // radioButtonCurve
            // 
            radioButtonCurve.AutoSize = true;
            radioButtonCurve.Location = new Point(15, 72);
            radioButtonCurve.Name = "radioButtonCurve";
            radioButtonCurve.Size = new Size(50, 21);
            radioButtonCurve.TabIndex = 0;
            radioButtonCurve.Text = "曲线";
            radioButtonCurve.UseVisualStyleBackColor = true;
            // 
            // myuc1
            // 
            myuc1.ActiveTool = MyToolType.Pointer;
            myuc1.BackColor = Color.SeaShell;
            myuc1.Graphics = myGraphicsList1;
            myuc1.IsDrawNetRectangle = false;
            myuc1.Location = new Point(142, 12);
            myuc1.Name = "myuc1";
            myuc1.NetRectangle = new Rectangle(0, 0, 0, 0);
            myuc1.Size = new Size(499, 262);
            myuc1.TabIndex = 9;
            myuc1.Tools = null;
            // 
            // E0705Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 286);
            Controls.Add(myuc1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "E0705Main";
            Text = "例9-2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButtonArrowCurve;
        private RadioButton radioButtonCurve;
        private RadioButton radioButtonHandle;
        private MyUC myuc1;
    }
}