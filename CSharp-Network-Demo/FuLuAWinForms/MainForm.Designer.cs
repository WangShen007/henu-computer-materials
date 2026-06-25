namespace FuLuAWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            linkLabel4 = new LinkLabel();
            linkLabel7 = new LinkLabel();
            linkLabel10 = new LinkLabel();
            linkLabel13 = new LinkLabel();
            linkLabel16 = new LinkLabel();
            linkLabel19 = new LinkLabel();
            linkLabel22 = new LinkLabel();
            linkLabel25 = new LinkLabel();
            panel2 = new Panel();
            linkLabel11 = new LinkLabel();
            linkLabel9 = new LinkLabel();
            linkLabel8 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            linkLabel5 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(19, 64);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(221, 28);
            label1.TabIndex = 0;
            label1.Text = "学       号：12345678";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(332, 426);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(16, 202);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(287, 221);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "照片";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Resource1.img0;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(281, 199);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(19, 161);
            label3.Margin = new Padding(10);
            label3.Name = "label3";
            label3.Size = new Size(169, 28);
            label3.TabIndex = 0;
            label3.Text = "座位编号：0101";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(19, 111);
            label2.Margin = new Padding(10);
            label2.Name = "label2";
            label2.Size = new Size(159, 28);
            label2.TabIndex = 0;
            label2.Text = "姓       名：张三";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(16, 18);
            label4.Margin = new Padding(10);
            label4.Name = "label4";
            label4.Size = new Size(266, 28);
            label4.TabIndex = 0;
            label4.Text = "年级班级：2023级计科1班";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(31, 27);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(95, 17);
            linkLabel4.TabIndex = 2;
            linkLabel4.TabStop = true;
            linkLabel4.Tag = "LX02";
            linkLabel4.Text = "练习2  字符显示";
            // 
            // linkLabel7
            // 
            linkLabel7.AutoSize = true;
            linkLabel7.Location = new Point(31, 65);
            linkLabel7.Name = "linkLabel7";
            linkLabel7.Size = new Size(107, 17);
            linkLabel7.TabIndex = 2;
            linkLabel7.TabStop = true;
            linkLabel7.Tag = "LX09";
            linkLabel7.Text = "练习9  属性和方法";
            // 
            // linkLabel10
            // 
            linkLabel10.AutoSize = true;
            linkLabel10.Location = new Point(31, 103);
            linkLabel10.Name = "linkLabel10";
            linkLabel10.Size = new Size(143, 17);
            linkLabel10.TabIndex = 2;
            linkLabel10.TabStop = true;
            linkLabel10.Tag = "LX10";
            linkLabel10.Text = "练习10  类继承-构造函数";
            // 
            // linkLabel13
            // 
            linkLabel13.AutoSize = true;
            linkLabel13.Location = new Point(31, 141);
            linkLabel13.Name = "linkLabel13";
            linkLabel13.Size = new Size(155, 17);
            linkLabel13.TabIndex = 2;
            linkLabel13.TabStop = true;
            linkLabel13.Tag = "LX11";
            linkLabel13.Text = "练习11  类继承-虚拟和重写";
            // 
            // linkLabel16
            // 
            linkLabel16.AutoSize = true;
            linkLabel16.Location = new Point(31, 179);
            linkLabel16.Name = "linkLabel16";
            linkLabel16.Size = new Size(90, 17);
            linkLabel16.TabIndex = 2;
            linkLabel16.TabStop = true;
            linkLabel16.Tag = "LX12";
            linkLabel16.Text = "练习12  随机数";
            // 
            // linkLabel19
            // 
            linkLabel19.AutoSize = true;
            linkLabel19.Location = new Point(31, 217);
            linkLabel19.Name = "linkLabel19";
            linkLabel19.Size = new Size(102, 17);
            linkLabel19.TabIndex = 2;
            linkLabel19.TabStop = true;
            linkLabel19.Tag = "LX13";
            linkLabel19.Text = "练习13  泛型列表";
            // 
            // linkLabel22
            // 
            linkLabel22.AutoSize = true;
            linkLabel22.Location = new Point(31, 255);
            linkLabel22.Name = "linkLabel22";
            linkLabel22.Size = new Size(102, 17);
            linkLabel22.TabIndex = 2;
            linkLabel22.TabStop = true;
            linkLabel22.Tag = "LX14";
            linkLabel22.Text = "练习14  界面交互";
            // 
            // linkLabel25
            // 
            linkLabel25.AutoSize = true;
            linkLabel25.Location = new Point(31, 293);
            linkLabel25.Name = "linkLabel25";
            linkLabel25.Size = new Size(126, 17);
            linkLabel25.TabIndex = 2;
            linkLabel25.TabStop = true;
            linkLabel25.Tag = "LX15";
            linkLabel25.Text = "练习15  文本文件读写";
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Controls.Add(linkLabel11);
            panel2.Controls.Add(linkLabel4);
            panel2.Controls.Add(linkLabel9);
            panel2.Controls.Add(linkLabel8);
            panel2.Controls.Add(linkLabel7);
            panel2.Controls.Add(linkLabel6);
            panel2.Controls.Add(linkLabel25);
            panel2.Controls.Add(linkLabel5);
            panel2.Controls.Add(linkLabel10);
            panel2.Controls.Add(linkLabel3);
            panel2.Controls.Add(linkLabel22);
            panel2.Controls.Add(linkLabel2);
            panel2.Controls.Add(linkLabel13);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(linkLabel19);
            panel2.Controls.Add(linkLabel16);
            panel2.Location = new Point(366, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(491, 428);
            panel2.TabIndex = 3;
            // 
            // linkLabel11
            // 
            linkLabel11.AutoSize = true;
            linkLabel11.Location = new Point(266, 68);
            linkLabel11.Name = "linkLabel11";
            linkLabel11.Size = new Size(95, 17);
            linkLabel11.TabIndex = 2;
            linkLabel11.TabStop = true;
            linkLabel11.Tag = "SY02";
            linkLabel11.Text = "实验2  密码显示";
            // 
            // linkLabel9
            // 
            linkLabel9.AutoSize = true;
            linkLabel9.Location = new Point(266, 116);
            linkLabel9.Name = "linkLabel9";
            linkLabel9.Size = new Size(95, 17);
            linkLabel9.TabIndex = 2;
            linkLabel9.TabStop = true;
            linkLabel9.Tag = "SY05";
            linkLabel9.Text = "实验5  随机抽号";
            // 
            // linkLabel8
            // 
            linkLabel8.AutoSize = true;
            linkLabel8.Location = new Point(31, 369);
            linkLabel8.Name = "linkLabel8";
            linkLabel8.Size = new Size(102, 17);
            linkLabel8.TabIndex = 2;
            linkLabel8.TabStop = true;
            linkLabel8.Tag = "LX18";
            linkLabel8.Text = "练习18  端口连接";
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Location = new Point(266, 164);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(95, 17);
            linkLabel6.TabIndex = 2;
            linkLabel6.TabStop = true;
            linkLabel6.Tag = "SY06";
            linkLabel6.Text = "实验6  限时答题";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(31, 331);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(114, 17);
            linkLabel5.TabIndex = 2;
            linkLabel5.TabStop = true;
            linkLabel5.Tag = "LX17";
            linkLabel5.Text = "练习17  进程和线程";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(266, 212);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(107, 17);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Tag = "SY07";
            linkLabel3.Text = "实验7  数据库操作";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(266, 308);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(131, 17);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Tag = "SY09";
            linkLabel2.Text = "实验9  网络呼叫与应答";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(266, 260);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(95, 17);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Tag = "SY08";
            linkLabel1.Text = "实验8  端口监听";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(269, 26);
            label5.Name = "label5";
            label5.Size = new Size(87, 17);
            label5.TabIndex = 3;
            label5.Text = "实验1：本界面";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 452);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "上机练习和综合实验参考源程序";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel7;
        private LinkLabel linkLabel10;
        private LinkLabel linkLabel13;
        private LinkLabel linkLabel16;
        private LinkLabel linkLabel19;
        private LinkLabel linkLabel22;
        private LinkLabel linkLabel25;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label4;
        private LinkLabel linkLabel11;
        private LinkLabel linkLabel9;
        private LinkLabel linkLabel8;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label5;
    }
}