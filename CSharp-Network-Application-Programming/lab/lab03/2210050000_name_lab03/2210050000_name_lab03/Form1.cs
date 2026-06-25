namespace _2210050000_name_lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFiletxt_Click(object sender, EventArgs e)
        {
            //File.copy https://learn.microsoft.com/zh-cn/dotnet/api/system.io.file.copy?view=net-8.0
            //openFileDialog https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //path https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path?view=net-8.0
                //此处path的处理以及字符串的处理借鉴上方链接
                string path = openFileDialog.FileName;
                string directory = Path.GetDirectoryName(path); //返回目录名称                 //https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.getdirectoryname?view=net-8.0#system-io-path-getdirectoryname(system-readonlyspan((system-char)))
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(path);//返回文件名,不带txt //https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.getfilenamewithoutextension?view=net-8.0#system-io-path-getfilenamewithoutextension(system-readonlyspan((system-char)))
                
                //包括"."
                string extension = Path.GetExtension(path);//返回扩展名,注意,包括"." https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path.getextension?view=net-8.0#system-io-path-getextension(system-string)
                //包括"."

                string copyPath = Path.Combine(directory, fileNameWithoutExt + "_复制" + extension);

                File.WriteAllText(copyPath, File.ReadAllText(path));
                showFile.Text = File.ReadAllText(path);
                MessageBox.Show("文本文件拷贝成功: " + copyPath);
            }
        }

        private void openFileAll_Click(object sender, EventArgs e)
        {
            //FileStream https://learn.microsoft.com/zh-cn/dotnet/api/system.io.filestream?view=net-8.0
            //FileStream.CopyTo https://learn.microsoft.com/zh-cn/dotnet/api/system.io.stream.copyto?view=net-8.0#system-io-stream-copyto(system-io-stream)
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "所有类型文件 (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string directory = Path.GetDirectoryName(path);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(path);
                string extension = Path.GetExtension(path);
                string copyPath = Path.Combine(directory, fileNameWithoutExt + "_复制" + extension);

                //showFile.Text = File.ReadAllText(path);
                /*FileStream sourceStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                FileStream destinationStream = new FileStream(copyPath, FileMode.Create, FileAccess.Write);
                sourceStream.CopyTo(destinationStream);*/
                using (FileStream sourceStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(copyPath, FileMode.Create, FileAccess.Write))
                {
                    sourceStream.CopyTo(destinationStream);
                }

                MessageBox.Show("通用文件拷贝成功: " + copyPath);
            }
        }
    }
}
