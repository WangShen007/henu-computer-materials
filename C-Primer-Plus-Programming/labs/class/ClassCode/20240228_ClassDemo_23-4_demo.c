#include <stdio.h>


void show(int a)
{
	printf("In show(int)\n");
}

/*error:C语言中没有/不支持重载函数 
void show(double a)
{
	printf("In show(double)\n");
}

void show(int a, double b)
{
	printf("In show(int,double)\n");
}

void show(double a, int b)
{
	printf("In show(double,int)\n");
}
*/

int main()
{
	show(1);
	//show(2.2);
	//show(1, 2.2);
	//show(1.1, 2);
	return 0;
}


//void add(int a = 0, int b = 0)//error:C语言中函数没有默认值参数,不能设置默认值 
void add(int a, int b)
{
	printf("In add(): a = %d , b = %d\n", a, b);
}

int main3()
{
	int x = 3, y = 4;
	add(1,2);
	add(x,y);
	//add(5);
	//add();
	return 0;
}

void test1(int a)//按值传递
{
} 

void test2(int *a)//按指针/地址传递
{
} 

/*
void test3(int &a)//error:C语言中函数没有引用传递 
{
} 
*/

int main2()
{
	int b = 1;
	test1(b);//按值传递
	int *p = &b;
	test2(&b);//按指针/地址传递
	test2(p);//按指针/地址传递
	return 0;
}


int main1()
{
	int a = 12;
	printf("a = %d , &a = %d / 0x%x , sizeof(a) = %d bytes\n", a, &a, &a, sizeof(a));
	
	int b = 23;
	printf("b = %d , &b = %d / 0x%x , sizeof(b) = %d bytes\n", b, &b, &b, sizeof(b));
	
	//int &r = a;//error: C语言中没有引用类型 
	
	return 0;
}
