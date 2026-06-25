/*
Ch14: 运算符重载
*/

#include <iostream>
#include <vector>
using namespace std;

class MyVector
{
public:
	MyVector();
	MyVector(int size);
	MyVector(int size, int value);
	~MyVector();

	int size();

	bool setItem(int i, int value);
	int  getItem(int i);

	int& operator[](int i);

private:
	int length;
	int *data;
};

void ShowVector(MyVector &v);

int main()
{
	MyVector v1;
	MyVector v2(2);
	MyVector v3(3,4);

	ShowVector(v1);
	ShowVector(v2);
	ShowVector(v3);

	v3[0] = 1;
	v3[1] = 2;
	v3[2] = 3;
	cout << v3[0] << " " << v3[1] << " " << v3[2] << endl;

	v3.operator[](0) = 1;
	v3.operator[](1) = 2;
	v3.operator[](2) = 3;
	cout << v3.operator[](0) << " " << v3.operator[](1) << " " << v3.operator[](2) << endl;

	return 0;
}

void ShowVector(MyVector &v)
{
	int size = v.size();
	cout << "The vector has " << size << " items: ";
	for(int i = 0; i < size; i++)
	{
		cout << v[i] << " ";
		//cout << v.getItem(i) << " ";
	}
	cout << endl;
}

MyVector::MyVector()
{
	length = 0;
	data = NULL;
}

MyVector::MyVector(int size)
{
	length = size;
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = 0;
	}
}

MyVector::MyVector(int size, int value)
{
	length = size;
	data = new int[length];
	for(int i = 0; i < length; i++)
	{
		data[i] = value;
	}
}

MyVector::~MyVector()
{
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

/////////////////////////////////////////////////////////////////////

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
	vector<int> v2(2);
	vector<int> v3(3,4);

	ShowVector(v1);
	ShowVector(v2);
	ShowVector(v3);

	v3[0] = 1;
	v3[1] = 2;
	v3[2] = 3;
	cout << v3[0] << " " << v3[1] << " " << v3[2] << endl;

	v3.operator[](0) = 1;
	v3.operator[](1) = 2;
	v3.operator[](2) = 3;
	cout << v3.operator[](0) << " " << v3.operator[](1) << " " << v3.operator[](2) << endl;

	return 0;
}
