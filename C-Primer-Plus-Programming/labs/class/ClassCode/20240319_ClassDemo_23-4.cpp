//2024年3月28日17:54:09 需要整理做笔记


/*
cH11: 动态内存, 拷贝构造函数 
*/

#include <iostream>
#include <vector>
using namespace std;

class MyIntVector
{
public: 
    MyIntVector()//无参构造函数 
    {
    	length = 0;
    	pList = NULL;
	}
    MyIntVector(int n)//有参构造函数 
    {
    	length = n;
    	pList = new int[length];
    	for(int i = 0; i < length; i++)
    	{
    		pList[i] = 0;
		}
	}
    MyIntVector(int n, int value)//有参构造函数
    {
    	length = n;
    	pList = new int[length];
    	for(int i = 0; i < length; i++)
    	{
    		pList[i] = value;
		}
	}
	MyIntVector(const MyIntVector & v)//拷贝构造函数
	{
		length = v.length;
		pList = new int[length];
    	for(int i = 0; i < length; i++)
    	{
    		pList[i] = v.pList[i];
		}
	}
	
    ~MyIntVector()//析构函数 
    {
    	length = 0;
    	if(pList != NULL)
    	{
    	    delete[] pList;
		}
    	pList = NULL;
	}
	
	
public:
	int length;
	int *pList;
};

void showMyVector(MyIntVector &v)
{
	cout << "The vector has " << v.length << " items: "; 
	for(int i = 0; i < v.length; i++)
	{
		cout << v.pList[i] << " ";//cout << *(pList+i) << " ";
	}
	cout << endl;
}

int main()
{
	//cout << NULL << endl;
	
	MyIntVector v1;
	showMyVector(v1);
	
	cout << "-----------" << endl;
	
	MyIntVector v2(3);
	showMyVector(v2);
	
	cout << "------------" << endl;
	
	MyIntVector v3(4,5);
	showMyVector(v3);
	
	cout << "------------" << endl;
	
	MyIntVector v4;
	v4 = v3;//整体赋值 
	showMyVector(v3);
	showMyVector(v4);
	
	cout << "------------" << endl;
	
	v3.pList[0] = 1;
	showMyVector(v3);
	showMyVector(v4);
	
	cout << "------------" << endl;
	
	v4.pList[0] = 2;
	showMyVector(v3);
	showMyVector(v4);
	
	cout << "------------" << endl;
	
	MyIntVector v5(v3);//拷贝构造
	showMyVector(v3);
	showMyVector(v5);
	
	cout << "------------" << endl;	
	
	v3.pList[0] = 8;
	showMyVector(v3);
	showMyVector(v5);
	
	cout << "------------" << endl;	
	
	v5.pList[0] = 9;
	showMyVector(v3);
	showMyVector(v5);
	
	return 0;
}

void showVector(vector<int> &v)
{
	cout << "The vector has " << v.size() << " items: ";
	for(int i = 0; i < v.size(); i++)
	{
		cout << v[i] << " ";
	}
	cout << endl;
}

int main6()
{
	vector<int> v1;
	showVector(v1);
	
	cout << "------------" << endl;
	
	vector<int> v2(3);
	showVector(v2);
	
	cout << "------------" << endl;
	
	vector<int> v3(4,5);
	showVector(v3);
	
	cout << "------------" << endl;
	
	vector<int> v4;
	v4 = v3;
	showVector(v4);
	
	cout << "------------" << endl;
	
	v3[0] = 1;
	showVector(v3);
	showVector(v4);
	
	cout << "------------" << endl;
	
	v4[0] = 8;
	showVector(v3);
	showVector(v4);
	
	return 0;
}

int main5()
{
	int a;
	cout << "&a = " << &a << " , sizeof(a) = " << sizeof(a) << " , a = " << a << endl;
	
	int b = 1;
	cout << "&b = " << &b << " , sizeof(b) = " << sizeof(b) << " , b = " << b << endl;
	
	int *p = &a;
	cout << "&p = " << &p << " , sizeof(p) = " << sizeof(p) << " , p = " << p << " , *p = " << *p << endl;
	
	p = new int;
	//p = new int();
	//p = new int(3);
	cout << "&p = " << &p << " , sizeof(p) = " << sizeof(p) << " , p = " << p << " , *p = " << *p << endl;
		
	delete p;
	
	p = new int[3];
	cout << "&p = " << &p << " , sizeof(p) = " << sizeof(p) << " , p = " << p << " , *p = " << *p << endl;
	
	for(int i = 0; i < 3; i++)
	{
		p[i] = i; //*(p+i) = i;
	}
	for(int i = 0; i < 3; i++)
	{
		cout << p[i] << " "; //cout << *(p+i) << " ";
	}
		
	delete[] p;
	
	return 0;
}

int main4()
{
	int n;
	cout << "Enter n: ";
	cin >> n;
	
	//int arr[n];
	//int *arr = new int[n];
	vector<int> arr(n); 
	
	cout << "Enter " << n << " integers: ";
	for(int i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "The array is: ";	
	for(int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	
	return 0;
} 

int main3()
{
	int n;
	cout << "Enter n: ";
	cin >> n;
	
	//int arr[n];
	int *arr = new int[n];
	
	cout << "Enter " << n << " integers: ";
	for(int i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "The array is: ";	
	for(int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	
	delete[] arr;
	
	return 0;
} 

int main2()
{
	int n;
	cout << "Enter n: ";
	cin >> n;
	
	int arr[n];
	
	cout << "Enter " << n << " integers: ";
	for(int i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "The array is: ";	
	for(int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	
	return 0;
} 

int main1()
{
	int arr[10] = {0};
	int n;
	cout << "Enter n: ";
	cin >> n;
	cout << "Enter " << n << " integers: ";
	for(int i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "The array is: ";	
	for(int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	
	return 0;
} 
