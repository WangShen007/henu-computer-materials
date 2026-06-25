namespace ServerConsoleExamples.ch07.E06
{
    internal class E0706Main
    {
        public E0706Main()
        {
            Console.Title = "多机协同绘图系统服务端";
            CC.Server = new E0706TcpServer();
            Console.WriteLine("已启动服务端监听，按<Esc>键保存本次制作信息并退出监听！");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                //保存本次制作信息
                CC.SerializeObject(CC.MyGraphicsList, CC.BackupFileName);
                Console.WriteLine("本次制作信息已序列化保存。");

                E0706TcpServer.SendToAllUser("ServerExit");
                Thread.Sleep(1000);
                CC.Server.MyListener.Stop();
                Console.WriteLine(" 服务器退出制作!");
            }
        }
    }
}
