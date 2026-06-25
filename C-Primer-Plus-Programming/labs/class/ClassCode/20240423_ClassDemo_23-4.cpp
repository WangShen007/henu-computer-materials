#include <iostream>
#include <vector>
using namespace std;

class MyVector
{
public:
	MyVector();
	MyVector(int size);
	MyVector(int size, int value);
	MyVector(MyVector &v);
	~MyVector();
	
	int size();
	bool setItem(int i, int value);
	int getItem(int i);
	
	int& operator[](int i);
	MyVector& operator=(MyVector &v);
	
private:
	int length;
	int *data;
};

void ShowVector(MyVector &v);

int main()
{
	cout << "---------------------------BEGIN------" << endl;
	
	MyVector v1;//无参构造
	ShowVector(v1);
	
	MyVector v2(2);//有参构造
	ShowVector(v2);
	
	MyVector v3(3,4);//有参构造 
	ShowVector(v3);
	
	MyVector v4(v3);//拷贝构造
	ShowVector(v4);
	
	cout << "---------------------------line1------" << endl;
	
	v3[0] = 1;//运算符'[]'重载
	//v3.operator[](0) = 1;
	ShowVector(v3);
	ShowVector(v4);
	
	cout << "---------------------------line2------" << endl;
	
	v4[0] = 2;//运算符'[]'重载
	ShowVector(v3);
	ShowVector(v4);
	
	cout << "---------------------------line3------" << endl;
	
	v1 = v3;//运算符'='重载
	ShowVector(v1);
	ShowVector(v3);
	
	cout << "---------------------------line4------" << endl;
		
	v1[0] = 5;//运算符'[]'重载
	ShowVector(v1);
	ShowVector(v3);
	
	cout << "---------------------------line5------" << endl;
	
	v3[0] = 6;//运算符'[]'重载
	ShowVector(v1);
	ShowVector(v3);
	
	cout << "---------------------------line6------" << endl;
	
	MyVector v5(v3);//拷贝构造
	
	cout << "---------------------------line7------" << endl;
	
	MyVector v6;//无参构造 
	v6 = v3;//运算符'='重载 
	
	cout << "---------------------------line8------" << endl;
	
	MyVector v7 = v3;//拷贝构造 
		
	cout << "---------------------------END--------" << endl;
	
	return 0;
} 

void ShowVector(MyVector &v)
{
	int size = v.size();
	cout << "The vector has " << size << " items: ";
	for(int i = 0; i < size; i++)
	{
		//cout << v[i] << " ";
		cout << v.getItem(i) << " ";
	}
	cout << endl;
}

MyVector::MyVector()
{
	length = 0;
	data = NULL;
	cout << "MyVector(): length = " << length << " , data = " << data << endl;
}

MyVector::MyVector(int size)
{
	length = size;
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = 0; //*(data+i) = 0;
	}
	cout << "MyVector(int): length = " << length << " , data = " << data << endl;
}

MyVector::MyVector(int size, int value)
{
	length = size;
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = value; //*(data+i) = value;
	}
	cout << "MyVector(int,int): length = " << length << " , data = " << data << endl;
}

MyVector::MyVector(MyVector &v)
{
	length = v.size();
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = v.getItem(i);//v[i];
	}
	cout << "MyVector(MyVector): length = " << length << " , data = " << data << endl;
}

MyVector::~MyVector()
{
	//cout << "~MyVector()" << endl;
	cout << "~MyVector(): length = " << length << " , data = " << data << endl;
	if(data != NULL)
	{
		delete[] data;
	    data = NULL;
	}	
	length = 0;
}

int MyVector::size()
{
	return length;
}

bool MyVector::setItem(int i, int value)
{
	if(i < 0 || i > length - 1)
	{
		return false;
	}
	data[i] = value;
	return true;
}

int MyVector::getItem(int i)
{
	if(i < 0 || i > length - 1)
	{
		return -1;
	}
	return data[i];
}

int& MyVector::operator[](int i)
{
	return data[i];
}

MyVector& MyVector::operator=(MyVector &v)
{
	if(data != NULL)
	{
		delete[] data;
		data = NULL;
	}
	length = v.size();
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = v[i];// v.getItem(i);//v[i];
	}
	cout << "operator=(MyVector): length = " << length << " , data = " << data << endl;
	return *this;
}

/////////////////////////////////////////////////////////////

void ShowVector(vector<int> &v)
{
	int size = v.size();
	cout << "The vector has " << size << " items: ";
	for(int i = 0; i < size; i++)
	{
		cout << v[i] << " ";
	}
	cout << endl;
}

int main1()
{
	vector<int> v1;
	ShowVector(v1);
	
	vector<int> v2(2);
	ShowVector(v2);
	
	vector<int> v3(3,4);
	ShowVector(v3);
	
	vector<int> v4(v3);
	ShowVector(v4);
	
	cout << "---------------------" << endl;
	
	v3[0] = 1;
	v3.operator[](0) = 1;
	ShowVector(v3);
	ShowVector(v4);
	
	cout << "---------------------" << endl;
	
	v4[0] = 2;
	v4.operator[](0) = 2;
	ShowVector(v3);
	ShowVector(v4);
	
	cout << "---------------------" << endl;
	
	v1 = v3;
	ShowVector(v1);
	ShowVector(v3);
	
	cout << "---------------------" << endl;
	
	v1[0] = 5;
	ShowVector(v1);
	ShowVector(v3);
	
	cout << "---------------------" << endl;
	
	v3[0] = 6;
	ShowVector(v1);
	ShowVector(v3);
	
	return 0;
} 
