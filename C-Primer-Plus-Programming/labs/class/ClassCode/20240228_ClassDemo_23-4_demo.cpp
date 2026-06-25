//2024年3月28日17:47:29 需要整理做笔记


/*
C++有而C没有的函数方面的几个特征：引用参数，默认值参数，重载函数

1,引用：是对一个已有变量起一个别名(第二个名字),不是新变量，不用分配内存
        对引用的所有操作等价于对原始变量直接操作(读写操作) 
        
2,函数的传参方式
   C中函数有两种传参方式：按值传递, 按指针/地址传递 
   C++中函数有三种传参方式：按值传递, 按指针/地址传递, 按引用传递 
   
3,默认值参数：在函数定义时，可以给全部或部分形参设置默认值(缺省值)
   在函数调用时，如果有对应实参，则用实参调用，否则用默认值调用 
   
4,函数重载：对于两个或多个同名函数，
   如果形参列表不同(形参的数量、类型、顺序至少一项不同，和形参名和返回类型都无关)，则构成重载
   在函数调用时，根据实参列表在形参列表中进行查找和匹配，完全匹配则调用 
*/


#include <iostream>
using namespace std;

void show(int a)
{
	cout << "In show(int): a = " << a << endl;
}

void show(double a)
{
	cout << "In show(double): a = " << a << endl;
}

void show(int a, double b)
{
	cout << "In show(int,double): a = " << a << " , b = " << b << endl;
}

void show(double a, int b)
{
	cout << "In show(double,int): a = " << a << " , b = " << b << endl;
}

int main()
{
	show(1);
	show(2.2);
	show(1, 2.2);
	show(1.1, 2);
	return 0;
}

void add(int a = 0, int b = 0)
{
	cout << "In add(): a = " << a << " , b = " << b << endl;
}

int main3()
{
	int x = 3, y = 4;
	add(1,2);
	add(x,y);
	add(5);
	add();
	return 0;
}

void test1(int a)//按值传递
{
} 

void test2(int *a)//按指针/地址传递
{
} 

void test3(int &a)//按引用传递，引用参数不能初始化 
{
} 

int main2()
{
	int b = 1;
	test1(b);//按值传递
	int *p = &b;
	test2(&b);//按指针/地址传递
	test2(p);//按指针/地址传递
	test3(b);//按引用传递
	return 0;
}

int main1()
{
	int a = 12;
	cout << "a = " << a << " , &a = " << &a << " , sizeof(a) = " << sizeof(a) << " bytes" << endl;
	
	int b = 23;
	cout << "b = " << b << " , &b = " << &b << " , sizeof(b) = " << sizeof(b) << " bytes" << endl;
	
	int &r = a;//定义一个引用r(reference),是变量a的别名,不是新变量，不用分配内存 
	cout << "r = " << r << " , &r = " << &r << " , sizeof(r) = " << sizeof(r) << " bytes" << endl;
	
	//int &r2;//error:定义引用时必须初始化，必须指明是哪一个已有变量的引用 
	return 0;
}


