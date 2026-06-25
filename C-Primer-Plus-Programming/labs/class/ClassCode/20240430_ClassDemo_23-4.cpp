
//多层/多级继承, 多重继承

#include <iostream>
using namespace std;

class A
{
public:
	int a;
	int d;
	A()  { cout << "A()" << endl; }
	~A() { cout << "~A()" << endl; }
};

class B
{
public:
	int b;
	int d;
	B()  { cout << "B()" << endl; }
	~B() { cout << "~B()" << endl; }
};

class AB : public A, public B
{
public:
	int c;
	int d;
	AB()
	{
	    a = 1;
	    b = 2;
	    c = 3;
	    A::d = 4;
	    B::d = 5;
	    this->d = 6;
	    cout << "AB()" << endl;
    }
	~AB() { cout << "~AB()" << endl; }
};

int main()
{
	cout << "-------------BEGIN---------" << endl;

	AB ab;
	ab.a = 1;
	ab.b = 2;
	ab.c = 3;
	ab.A::d = 4;
	ab.B::d = 5;
	ab.d = 6;

	cout << "-------------END---------" << endl;

	return 0;
}

class X
{
public:
	int x;
	X()  { cout << "X()" << endl; }
	~X() { cout << "~X()" << endl; }
};

class Y : public X
{
public:
	int y;
	Y()  { cout << "Y()" << endl; }
	~Y() { cout << "~Y()" << endl; }
};

class Z : public Y
{
public:
	int z;
	Z()  { cout << "Z()" << endl; }
	~Z() { cout << "~Z()" << endl; }
};

int main1()
{
	cout << "-------------BEGIN---------" << endl;

	Z z;

	cout << "-------------END---------" << endl;

	return 0;
}
