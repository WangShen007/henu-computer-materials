//2024年3月28日17:51:43 需要整理做笔记


/*
Ch10 & Ch12: 数组类: array, vector, string

array(定长数组): 
常用操作: 整体赋值, size(), swap(), fill(), ...

vector(变长数组):
常用操作: 整体赋值, size(), push_back(), pop_back(), resize(), ...

string(变长字符数组/字符串): 
常用操作: 整体赋值, size()/length(), substr(), find(), ...
 
*/


#include <iostream>
#include <array>  //for array class
#include <vector> //for vector class
#include <string> //for string class
#include <iomanip> //for input output stream manipulation
using namespace std;

void showString(string &s)
{
	//cout << "The string has " << s.size() << " charactors: " << s << endl;
	cout << "The string has " << s.length() << " charactors: " << s << endl;
}

int main()
{
	string s1;//定义一个字符串,默认长度为0 
	showString(s1);
	
	string s2 = "abc";//定义一个字符串并进行初始化 
	showString(s2);
	
	s1 = s2;//OK: string字符串类可以整体赋值(长度不必相等)
	showString(s1);
	
	cout << "-----------" << endl;
	
	s1 = "abcdefghijklmndddddefg";
	showString(s1);
	cout << s1.substr(3) << endl;//获得从下标3开始一直到最后的子串 
	cout << s1.substr(3,4) << endl;//获得从下标3开始长度为4的子串
	
	cout << "-----------" << endl;
	
	cout << s1.find('d') << endl;//获得从左向右字符'd'第一次出现的下标 
	cout << s1.find("efg") << endl;//获得从左向右字符串"efg"第一次出现的下标
	cout << s1.find("123") << endl;
	cout << s1.npos << endl;//字符串中找不到目标时返回的标识常量 
	cout << (s1.find("abc") == s1.npos ? "Not Found" : "Found" ) << endl;
	cout << (s1.find("123") >= 0 && s1.find("123") < s1.size() ? "Found" : "Not Found" ) << endl;
	
    double pos = s1.find("123");
    cout << fixed;
	cout << pos << endl;
	
	
	return 0;
}


//void showVector(vector<int> a)
void showVector(vector<int> &a)
{
	int len = a.size();
	cout << "The vector has " << len << " elements: ";
	for(int i = 0 ; i < len; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
}

int main4()
{
	vector<int> v;//定义一个整型数组,长度默认为0 
	showVector(v);
	
	v.push_back(1);//尾部添加一个值为1的新元素, 数组长度加1 
	showVector(v);
	
	v.push_back(3);
	showVector(v);
	
	v.push_back(5);
	showVector(v);
	
	cout << "-----------" << endl;
	
	v.pop_back();//尾部删除最后一个元素,数组长度减1 
	showVector(v);
	
	v.pop_back();
	showVector(v);
	
	v.pop_back();
	showVector(v);
	
	cout << "-----------" << endl;
	
	v.resize(5,2);//调整长度为5,删除尾部若干元素,或在尾部添加若干初始值为2的新元素 
	showVector(v);
	
	v.resize(10,3);//调整长度为10,删除尾部若干元素,或在尾部添加若干初始值为3的新元素 
	showVector(v);
	
	v.resize(3,4);//调整长度为3,删除尾部若干元素,或在尾部添加若干初始值为4的新元素 
	showVector(v);
	
	return 0;
}

int main3()
{
	vector<int> a(3);//定义一个长度为3的整型数组,所有元素的初始值都是默认值0 
	showVector(a);
	/*
	a[0] = 1;
	a[1] = 2;
	a[2] = 3;
	cout << "The array is: ";
	for(int i = 0 ; i < a.size(); i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
	*/
	
	cout << "--------" << endl;
	
	vector<int> b(6,1);//定义一个长度为6的整型数组,所有元素的初始值都是指定值1
	showVector(b);
	
	cout << "--------" << endl;
	
	a = b;//OK: vector数组类可以整体赋值(长度不必相等)
	showVector(a);
	showVector(b);	
	
	cout << "--------" << endl;
	
	int n = 3;
	cin >> n;
	//vector<int> c(n);//定义一个长度为变量n的整型数组,所有元素的初始值都是默认值0 
	vector<int> c(n,100);//定义一个长度为变量n的整型数组,所有元素的初始值都是指定值100 
	showVector(c);	
	
	return 0;
} 


void showArray(array<int,3> a)
{
	int len = a.size();
	cout << "The array is: ";
	for(int i = 0 ; i < len; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
}

int main2()
{
	array<int,3> a;//定义一个长度为3的整型数组,所有元素的初始值都是随机值
	showArray(a);
	/*
	//a[0] = 1;
	//a[1] = 2;
	//a[2] = 3;
	cout << "The array is: ";
	for(int i = 0 ; i < a.size(); i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
	*/
	
	cout << "--------" << endl;
	
	a.fill(2); //数组填充(所有元素都等于指定值2) 
	showArray(a);
	
	cout << "--------" << endl;
	
	array<int,3> b = {4,5,6};//定义一个长度为3的整型数组,用指定值给所有元素初始化
	showArray(b);
	
	cout << "--------" << endl;
	
	a.swap(b);//数组互换(长度必须相等) 
	showArray(a);
	showArray(b);	
	
	cout << "--------" << endl;
	
	b.swap(a);
	showArray(a);
	showArray(b);	
	
	cout << "--------" << endl;
	
	a = b;//OK: array数组类可以整体赋值(长度必须相等)
	showArray(a);
	showArray(b);	
	
	cout << "--------" << endl;
	
	int n = 3;
	//cin >> n;
	//array<int,n> c;//error:使用array数组类定义数组时,长度不能为变量 
	//showArr(c, n);
	
	return 0;
} 

void showArr(int *a, int len)
//void showArr(int a[], int len)
{
	cout << "The array is: ";
	for(int i = 0 ; i < len; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
}

int main1()
{
	int a[3];//定义一个长度为3的整型数组,所有元素的初始值都是随机值 
	//a[0] = 1;
	//a[1] = 2;
	//a[2] = 3;
	cout << "The array is: ";
	for(int i = 0 ; i < 3; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
	
	cout << "--------" << endl;
	
	int b[3] = {4,5,6};//定义一个长度为3的整型数组,用指定值给所有元素初始化 
	showArr(b, 3);
	
	cout << "--------" << endl;
	
	//a = b;//error:基本数组不能整体赋值
	
	int n;
	cin >> n;
	int c[n];//定义一个长度为变量n的整型数组,所有元素的初始值都是随机值,不能用'="进行初始化 
	showArr(c, n);
	
	return 0;
} 
