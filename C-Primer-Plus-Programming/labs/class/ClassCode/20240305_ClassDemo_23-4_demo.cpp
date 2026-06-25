//2024年3月28日17:50:00 需要整理做笔记


/*
C++和C的区别之一：结构struct类型方面
相同：C和C++都有结构类型struct，结构类型中都有成员变量(member variable)
不同：
1, 关于定义结构变量时的关键字struct，C中必须有，C++中可有可无 
2, 关于结构类型中的成员函数，C中没有，C++中可有可无
3, 空结构(没有任何成员的结构类型)的内存大小，C中为0字节，C++中为1字节 

除此之外，其他特征都相同：
   成员操作符(".", "->"), 结构数组, 结构指针, 函数中结构参数传递 
*/

#include <stdio.h>

struct Point
{
	int x, y;//成员变量 
	void show()//成员函数 
	{
		printf("The point is (%d,%d).\n", x, y);
	}
};

struct EmptyStruct//空结构(没有任何成员的结构类型)
{
};

struct Student
{
	char ID[20];
	char name[50];
	int age;
	int score;
	void show()
	{
		printf("My score is %d.\n", score);
	}
};


//void show1(struct Point a)//按值传递 
void show1(Point a)//按值传递 
{
	printf("(%d,%d)\n", a.x, a.y);
}

void show2(Point *a)//按指针传递 
{
	printf("(%d,%d) , (%d,%d)\n", (*a).x, (*a).y, a->x, a->y);
}

void show3(Point &a)//按引用传递 
{
	printf("(%d,%d)\n", a.x, a.y);
}

int main()
{
	int a;//整型变量 
	a = 1;
	printf("a = %d , &a = 0x%x , sizeof(a) = %d bytes\n", a, &a, sizeof(a));
	
	printf("------------------\n");
	
	//struct Point p1, p2;//结构变量
	Point p1, p2;//结构变量//C++中定义结构变量时关键字struct可有可无 
	p1.x = 1;//成员操作符(点操作符)".", 通过点操作符来访问结构变量的成员(包括成员变量和成员函数) 
	p1.y = 2;
	p2.x = 3;
	p2.y = 4;
	//x = 1;//error:成员变量不能独立存在，必须依附于某一个具体的结构变量
	printf("p1 = (%d,%d) , &p1 = 0x%x , sizeof(p1) = %d bytes\n", p1.x, p1.y, &p1, sizeof(p1));
	printf("p2 = (%d,%d) , &p2 = 0x%x , sizeof(p2) = %d bytes\n", p2.x, p2.y, &p2, sizeof(p2));
	
	p1.show();
	p2.show();
	
	Student s1, s2;
	s1.score = 88;
	s2.score = 99;
	s1.show();
	s2.show();
	
	struct EmptyStruct es;//空结构(没有任何成员的结构类型)
	printf("&es = 0x%x , sizeof(es) = %d bytes\n", &es, sizeof(es));
	
	printf("The size of EmptyStruct in C++ language is %d bytes.\n", sizeof(struct EmptyStruct));
	
	struct Point ptArray[3];//结构数组
	ptArray[0].x = 1;
	ptArray[0].y = 2;
	ptArray[1].x = 3;
	ptArray[1].y = 4;
	ptArray[2].x = 5;
	ptArray[2].y = 6;	
	printf("The point array is: ");
	for(int i = 0; i <= 2; i++)
	{
		printf("(%d,%d) ", ptArray[i].x, ptArray[i].y);
	}
	printf("\n");
	
	struct Point *sp;//结构指针
	sp = &p1;
	(*sp).x = 3;//成员操作符(点操作符)".", 通过点操作符来访问结构指针所指向的结构变量的成员变量 
	(*sp).y = 4;
	printf("p1 = (%d,%d) , p1 = (%d,%d)\n", p1.x, p1.y, (*sp).x, (*sp).y);
	
	sp = &p2;
	sp->x = 5;//成员操作符(箭头操作符)".", 通过箭头操作符来访问结构指针所指向的结构变量的成员变量 
	sp->y = 6;
	printf("p2 = (%d,%d) , p2 = (%d,%d)\n", p2.x, p2.y, sp->x, sp->y);
	
	show1(p1);//按值传递
	show2(&p1);//按指针传递
	show3(p1);//按引用传递
	
	
	return 0;
} 
