/*
Ch15: 多态 

在具有继承关系的多个对象里，
通过基类对象指针或基类对象引用，
来调用同一个同名虚函数，
会根据所指向或所引用的不同对象的类型，
来自动调用不同类里的同名虚函数，
得到不同的执行结果， 
呈现出不同的形态或状态，这称为多态。

函数隐藏：在子类里定义的和基类里非虚成员函数同名的成员函数，会把从基类里继承过来的同名成员函数隐藏掉
函数覆盖：在子类里定义的和基类里的virtual虚函数同名的成员函数，会把从基类里继承过来的同名成员函数覆盖掉

实现多态的两个条件：
1，在基类里用virtual声明为虚函数，在子类里对虚函数进行重定义(重新写虚函数的实现过程);
2，通过基类对象指针或基类对象引用来调用虚函数。 
*/

#include <iostream>
using namespace std;

class Shape
{
public:
	virtual void show()
	{
		cout << "I'm a shape." << endl;
	}
};

class Circle : public Shape
{
public:
	void show()
	{
		cout << "I'm a circle." << endl;
	}
};

class Square : public Shape
{
public:
	void show()
	{
		cout << "I'm a square." << endl;
	}
};

void showShape(Shape *p)
{
	p->show();//(*p).show();
}

void showShape2(Shape &r)
{
	r.show();
}

int main()
{
	cout << "------------------BEGIN---------" << endl;
	
	Shape shape; 
	shape.show();
	
	Circle circle;
	circle.show();
	
	Square square;
	square.show();
	
	cout << "------------------line1---------" << endl;
	
	Shape *pShape;
	pShape = &shape;
	pShape->show();//等价于：(*pShape).show();
	
	Circle *pCircle;
	pCircle = &circle;
	pCircle->show();	
	
	Square *pSquare = NULL;
	pSquare = &square;
	pSquare->show();
	
	cout << "------------------line2---------" << endl;
	
	pShape = &shape;
	pShape->show();	
	
	pShape = &circle;
	pShape->show();
	
	pShape = &square;
	pShape->show();
	
	//pCircle = &shape;//error
	//pSquare = &shape;//error
	
	//pCircle = &square;//error
	//pSquare = &circle;//error
	
	cout << "------------------line3---------" << endl;
	
	pShape = &shape;
	showShape(pShape);	
	
	pShape = &circle;
	showShape(pShape);
	
	pShape = &square;
	showShape(pShape);
	
	cout << "------------------line4---------" << endl;
	
	showShape(&shape);
	showShape(&circle);
	showShape(&square);
	
	cout << "------------------line5---------" << endl;
	
	showShape2(shape);
	showShape2(circle);
	showShape2(square);
	
	cout << "------------------END-----------" << endl;
	
	return 0;
} 
