
#include <iostream>
using namespace std;

#define PI 3.1415926

class Shape
{
public:
	Shape();
	~Shape();
	void   setPerimeter(double p);
	double getPerimeter();
	void   setArea(double a);
	double getArea();
	virtual void show();
	
private:
	double perimeter;
	double area;
};

class Circle : public Shape
{
public:
	Circle();
	~Circle();
	void   setRadius(double r);
	double getRaiuds();
	void   show();
	
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
	void   show();
	
private:
	double length;
};

void Show(Shape *pShape)
{
	pShape->show();//(*pShape).show();
}

void Show(Shape &rShape)
{
	rShape.show();
}

int main()
{
	cout << "-------------------------BEGIN--------" << endl;
	
	Shape s;
	//s.perimeter = 1;//error
	s.setPerimeter(1);
	s.setArea(2);
	cout << "s.perimeter = " << s.getPerimeter() << " , s.area = " << s.getArea() << endl;
	
	cout << "-------------------------line1--------" << endl;
	
	Circle c;
	//c.perimeter = 1;//error
	c.setPerimeter(1);
	c.setArea(2);
	cout << "c.perimeter = " << c.getPerimeter() << " , c.area = " << c.getArea() << endl;
	
	cout << "-------------------------line2--------" << endl;
	
	//c.radius = 1;//error
	c.setRadius(1);
	cout << "c.perimeter = " << c.getPerimeter() << " , c.area = " << c.getArea() << endl;
	
	cout << "-------------------------line3--------" << endl;
	
	Square sq;
	sq.setPerimeter(1);
	sq.setArea(2);
	cout << "sq.perimeter = " << sq.getPerimeter() << " , sq.area = " << sq.getArea() << endl;
	
	cout << "-------------------------line4--------" << endl;
	
	sq.setLength(1);
	cout << "sq.perimeter = " << sq.getPerimeter() << " , sq.area = " << sq.getArea() << endl;
	
	cout << "-------------------------line5--------" << endl;
	
	s.show();
	c.show();
	sq.show();
	
	cout << "-------------------------line6--------" << endl;
	
	Shape *pShape;
	
	pShape = &s;
	pShape->show();//(*pShape).show();
	
	pShape = &c;
	pShape->show();
	
	pShape = &sq;
	pShape->show();
	
	cout << "-------------------------line7--------" << endl;
	
	Show(&s);
	Show(&c);
	Show(&sq);
	
	cout << "-------------------------line8--------" << endl;
	
	Show(s);
	Show(c);
	Show(sq);
	
	cout << "-------------------------END----------" << endl;
	
	return 0;
}

Shape::Shape()
{
	perimeter = area = 0;
	cout << "Shape(): perimeter = " << perimeter << " , area = " << area << endl;
}

Shape::~Shape()
{
	cout << "~Shape(): perimeter = " << perimeter << " , area = " << area << endl;
}

void Shape::setPerimeter(double p)
{
	perimeter = p;
}

double Shape::getPerimeter()
{
	return perimeter;
}

void Shape::setArea(double a)
{
	area = a;
}

double Shape::getArea()
{
	return area;
}

void Shape::show()
{
	cout << "Shape::show(): I'm a shape." << endl;
}


Circle::Circle()
{
	radius = 0;
	cout << "Circle(): radius = " << radius << " , perimeter = " << getPerimeter() 
	     << " , area = " << getArea() << endl;
}

Circle::~Circle()
{
	cout << "~Circle(): radius = " << radius << " , perimeter = " << getPerimeter() 
	     << " , area = " << getArea() << endl;
}

void Circle::setRadius(double r)
{
	radius = r;
	//perimeter = 2 * PI * radius;//error
	//area = PI * radius * radius;//error
	setPerimeter(2 * PI * radius);
	setArea(PI * radius * radius);
}

double Circle::getRaiuds()
{
	return radius;
}

void Circle::show()
{
	cout << "Circle::show(): I'm a circle." << endl;
}


Square::Square()
{
	length = 0;
	cout << "Square(): length = " << length << " , perimeter = " << getPerimeter() 
	     << " , area = " << getArea() << endl;
}

Square::~Square()
{
	cout << "~Square(): length = " << length << " , perimeter = " << getPerimeter() 
	     << " , area = " << getArea() << endl;
}

void Square::setLength(double len)
{
	length = len;
	setPerimeter(4 * length);
	setArea(length * length);
}

double Square::getLength()
{
	return length;
}

void Square::show()
{
	cout << "Square::show(): I'm a square." << endl;
}


