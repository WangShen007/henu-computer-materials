//2024年3月28日17:57:10 需要整理做笔记

/*
Ch9 & Ch10: 变量作用域, 静态成员 
*/

#include <iostream>
#include <string> // for string class
using namespace std;

class Cat
{
public:
	string name;
	int weight;
	
	static int count;//静态成员变量(类内声明) 
	static int totalWeight;//静态成员变量(类内声明)
	
	static void showTotal();//静态成员函数(类内声明)
	
	Cat()//无参构造函数 
	{
		name = "NONAME";
		weight = 1;
		
		count++;
		totalWeight += weight;
		cout << "The cat " << name << " is created. weight = " << weight << endl;
	}
	
	Cat(string catName, int catWeight)//有参构造函数 
	{
		name = catName;
		weight = catWeight;
		
		count++;
		totalWeight += weight;
		cout << "The cat " << name << " is created. weight = " << weight << endl;
	}
	
	~Cat()//析构函数 
	{
		count--;
		totalWeight -= weight;
		cout << "The cat " << name << " is released." << endl;
	}
};

int Cat::count = 0;//静态成员变量(类外定义) 
int Cat::totalWeight = 0;//静态成员变量(类外定义)

void Cat::showTotal()//静态成员函数(类外定义)
{
	cout << "Cats: count = " << count << " , totalWeight = " << totalWeight << endl;
}

int main()
{
	Cat c1;
	Cat::showTotal();
	
	cout << "---------------" << endl;
	
	Cat c2("Tom", 3);
	Cat::showTotal();
	
	cout << "---------------" << endl;
	
	Cat catList[3];
	Cat::showTotal();
	
	cout << "---------------" << endl;
	
	Cat *pCat = new Cat("Jerry", 5);
	Cat::showTotal();
	
	delete pCat;
	Cat::showTotal();
	
	cout << "---------------" << endl;
	
	pCat = new Cat[4];
	Cat::showTotal();
	
	delete[] pCat;
	Cat::showTotal();
	
	cout << "-----END------" << endl;
	return 0;
}

class Demo
{
public:
	
	void test2()
	{
		a = 2;
	}
	
	int a;//成员变量a作用域: 整个Demo类的类内 
	
	static int b;//静态成员变量(类内声明) //静态成员变量b作用域: 整个Demo类的类内
	
	static void show()//静态成员函数(类内定义),只能访问静态成员(变量/函数)
	{
		cout << "b = " << b << endl;
	}
	
	void test1()
	{
		a = 1;
	}
	
	void test3();
};

int Demo::b = 0;//静态成员变量(类外定义)

void Demo::test3()
{
	a = 2;
}

int main2()
{
	Demo d1;
	d1.a = 1;
	d1.test1();
	cout << sizeof(d1) << endl;
	
	Demo d2;
	d2.a = 2;
	d2.test1();
	cout << sizeof(d2) << endl;
	
	cout << "d1.a = " << d1.a << " , d2.a = " << d2.a << endl;
	
	cout << "-----------" << endl;
	
	cout << "d1.b = " << d1.b << " , d2.b = " << d2.b << endl;
	
	d1.b = 2;
	cout << "d1.b = " << d1.b << " , d2.b = " << d2.b << endl;
	
	d2.b = 3;
	cout << "d1.b = " << d1.b << " , d2.b = " << d2.b << endl;
	
	cout << "-----------" << endl;
	
	cout << "&d1 = " << &d1 << " , &d2 = " << &d2 << endl;
	cout << "&(d1.a) = " << &(d1.a) << " , &(d2.a) = " << &(d2.a) << endl;
	cout << "&(d1.b) = " << &(d1.b) << " , &(d2.b) = " << &(d2.b) << endl;
	
	cout << "-----------" << endl;
	
	d1.b = 4;
	cout << d1.b << " , " << d2.b << " , " << Demo::b << endl;
	
	d2.b = 5;
	cout << d1.b << " , " << d2.b << " , " << Demo::b << endl;
	
	Demo::b = 6;
	cout << d1.b << " , " << d2.b << " , " << Demo::b << endl;
	
	cout << "-----------" << endl;
	
	d1.show();
	d2.show();
	Demo::show();
	
	return 0;
}

int c = 0;//全局变量c作用域: 从定义位置到当前文件尾部结束(Line 174-204) 

void test1(int x)//局部变量x作用域: 从定义位置到当前语句块尾部结束(Line 176-182) 
{
	x = 2;
	int y; y = 2;//局部变量y作用域: 从定义位置到当前语句块尾部结束(Line 179-182)
	y = 3;
	c = 1;
}

void test2();

int main1()
{
	c = 2;
	int a;//局部变量a作用域: 从定义位置到当前语句块尾部结束(Line 189-198)
	a = 1;
	for(int i = 0 ; i < 2; i++)//局部变量i作用域: 从定义位置到当前语句块尾部结束(Line 191-194)
	{
		cout << i << endl;
	}
	test1(1);
	test2();
	return 0;
}

void test2()
{
	c = 3;
}

