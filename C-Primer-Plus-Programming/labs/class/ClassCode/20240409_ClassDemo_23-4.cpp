
/*
Ch15: 继承中的构造和析构 

定义子类对象时, 先自动调用基类构造函数, 再自动调用子类构造函数(正序构造)
释放子类对象时, 先自动调用子类析构函数, 再自动调用基类析构函数(逆序析构) 

*/

#include <iostream>
using namespace std;

#define PI 3.1415926

class Shape
{
public:
	Shape();
	~Shape();
	void   setArea(double a);
	double getArea();
	void   setPerimeter(double p);
	double getPerimeter();
	
private:
	double area;
	double perimeter;
};

class Circle : public Shape
{
public:
	Circle();
	~Circle();
	void   setRadius(double r);
	double getRadius();
	
private:
	double radius;
};

class Square : public Shape
{
public:
	Square();
	~Square();
	void   setLength(double len);
	double getLength();
	
private:
	double length;
};

int main()
{
	cout << "--------------------BEGIN----------" << endl;
	
	Shape s;
	
	cout << "--------------------flag1----------" << endl;
	
	Circle c;
	
	cout << "--------------------flag2----------" << endl;
	
	Square sq;
	
	cout << "--------------------END------------" << endl;
	
	return 0;
}

int main1()
{
	Shape s;
	s.setArea(1);
	s.setPerimeter(2);
	cout << "s.area = " << s.getArea();
	cout << " , s.perimeter = " << s.getPerimeter() << endl;
	
	cout << "---------------------" << endl;
	
	Circle c;
	c.setArea(1);
	c.setPerimeter(2);
	cout << "c.area = " << c.getArea();
	cout << " , c.perimeter = " << c.getPerimeter() << endl;
	
	cout << "---------------------" << endl;	
	
	c.setRadius(1);
	cout << "c.area = " << c.getArea();
	cout << " , c.perimeter = " << c.getPerimeter() << endl;
	
	return 0;
}

Shape::Shape()
{
	area = perimeter = 0;
	cout << "Shape(): area = " << area << " , perimeter = " << perimeter << endl;
}

Shape::~Shape()
{
	cout << "~Shape(): area = " << area << " , perimeter = " << perimeter << endl;
}

void Shape::setArea(double a)
{
	area = a;
}

double Shape::getArea()
{
	return area;
}

void Shape::setPerimeter(double p)
{
	perimeter = p;
}

double Shape::getPerimeter()
{
	return perimeter;
}

Circle::Circle()
{
	setRadius(1);
	cout << "Circle(): area = " << getArea() << " , perimeter = " << getPerimeter() << endl;
}

Circle::~Circle()
{
	cout << "~Circle(): area = " << getArea() << " , perimeter = " << getPerimeter() << endl;
}

void Circle::setRadius(double r)
{
	radius = r;
	setArea( PI * radius * radius );
	setPerimeter( 2 * PI * radius );	
}

double Circle::getRadius()
{
	return radius;
}

Square::Square()
{
	setLength(1);
	cout << "Square(): area = " << getArea() << " , perimeter = " << getPerimeter() << endl;
}

Square::~Square()
{
	cout << "~Square(): area = " << getArea() << " , perimeter = " << getPerimeter() << endl;
}

void Square::setLength(double len)
{
	length = len;
	setArea( length * length );
	setPerimeter( 4 * length );	
}

double Square::getLength()
{
	return length;
}

