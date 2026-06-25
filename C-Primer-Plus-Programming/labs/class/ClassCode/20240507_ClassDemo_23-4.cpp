
/*
Ch13: 文件输入输出 

cin:  console input,  控制台输入/标准输入/键盘输入
cout: console output, 控制台输出/标准输出/屏幕输出
*/

#include <iostream> //input output stream, for cin, cout, ...
#include <fstream>  //file stream, for ifstream, ofstream
#include <string>   //for string class
using namespace std;

int main()
{
	//open the file
	char fileName[200] = "a.txt";
	
	ifstream fin;
	fin.open(fileName);
	
	if(fin.fail())
	//if(!fin)
	{
		cout << "Failed to open the file: " << fileName << endl;
		return 0;
	}
	
	//read/write the file
	
	/*逐字符读取 
	char c;
	//while(fin >> c)//不包含分隔符(空格/制表符/换行符) 
	while(fin.get(c))//包含分隔符(空格/制表符/换行符)
	{
		cout << c; 
	}
	*/
	
	/*逐段/单词读取
	//char str[200] = "";
	string str = "";
	while(fin >> str)
	{
		cout << str << endl;
	}
	*/
	
	/*逐行读取
	char str[200] = "";
	while(fin.getline(str, 200))
	{
		cout << str << endl;
	}
	*/
	string str = "";
	while(getline(fin, str))
	{
		cout << str << endl;
	}
	
	
	//close the file
	fin.close();
	
	return 0;
}

int main3()
{
	//open the file 
	char fileName[200] = "a.txt";
	
	//ifstream fin;
	//fin.open(fileName);
	//fin.open(fileName, ios::in);
	
	ifstream fin(fileName);
	//ifstream fin(fileName, ios::in);
	
	//read/write the file
	
	//int a, b;
	//fin >> a >> b;
	
	//cout << "a = " << a << " , b = " << b << endl;
	
	int a, sum = 0;
	while( fin >> a )
	{
		sum += a;
		//cout << a << endl;
	}
	cout << "sum = " << sum << endl;
	
	//close the file
	fin.close();
	
	return 0;
}

int main2()
{
	/*
	cout << "e:\demo\a.txt" << endl;
	cout << "e:\\demo\\a.txt" << endl;
	cout << "e:/demo\\a.txt" << endl;
	cout << "e:\\demo/a.txt" << endl;
	cout << "e:/demo/a.txt" << endl;
	return 0;
	*/
	
	//open the file
	
	char fileName[200] = "a.txt";//相对路径 
	//char fileName[200] = "E:\\demo\\a.txt";//绝对路径
	//char fileName[200] = "E:/demo\\a.txt";//绝对路径
	//char fileName[200] = "E:\\demo/a.txt";//绝对路径
	//char fileName[200] = "E:/demo/a.txt";//绝对路径 
	//char fileName[200] = "E:/demo/test/a.txt";//绝对路径 
	
	ofstream fout;
	//fout.open(fileName);
	fout.open(fileName, ios::app);
	
	//if(fout.fail())
	if(!fout)
	{
		cout << "Failed to open the file: " << fileName << endl;
		return 0;
	}
	
	//ofstream fout;
	//fout.open("a.txt");//默认是截断/覆盖写入模式 
	//fout.open("a.txt", ios::out);//output,截断/覆盖写入模式
	//fout.open("a.txt", ios::trunc);//truncate,截断/覆盖写入模式
	//fout.open("a.txt", ios::app);//append,追加/附加写入模式
	
	//ofstream fout("a.txt");
	//ofstream fout("a.txt", ios::app);
	
	//read/write the file
	fout << "Hello world!" << endl;
	
	//close the file
	fout.close();
	
	return 0;
}

int main1()
{
	int a;
	cin >> a;
	cout << "a = " << a << endl;
	return 0;
} 
