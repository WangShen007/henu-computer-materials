/*
Question:

任务描述
本关任务：设计一个矩形类、一个圆形类和一个图形基类，计算并输出相应图形面积。

相关知识
为了完成本关任务，你需要掌握纯虚函数和抽象类的使用。

纯虚函数
有时在类中将某一成员声明为虚函数，并不是因为基类本身的要求，而是因为派生类的需求，在基类中预留一个函数名，具体功能留给派生类区定义。这种情况下就可以将这个纯虚函数声明为纯虚函数。即纯虚函数的作用是在基类中为其派生类保留一个函数的名字，以便派生类对它进行定义。

纯虚函数就是在声明虚函数时被初始化为0的函数，但它只有名字，不具备函数功能，不能被调用，其一般形式是：

virtual 函数类型 函数名（参数列表） = 0
纯虚函数没有函数体。最后的“=0”只是一种形式，告诉编译系统，它是一个纯虚函数，留在派生类中定义，并没有实际意义。

纯虚函数只有在派生类中定义了之后才能被调用。如果在一个类中声明了纯虚函数，而在派生类中没有对该函数定义，则该虚函数在派生类中仍然为纯虚函数。

例如：

class Base
{
    public:
        virtual void Func() = 0;     // 声明一个纯虚函数
};
抽象类
含有纯虚函数的类就成为抽象类。抽象类只是一种基本的数据类型，用户需要在这个基础上根据自己的需要定义处各种功能的派生类。

抽象类的作用就是为一个类族提供一个公共接口。抽象类不能定义对象，但是可以定义指向抽象类的指针变量，通过这个指针变量可以实现多态。

例如：

class Base
{
    public:
        virtual void Func() = 0;     // 声明一个纯虚函数
};
class D1 : public Base {}     // 什么也不做
class D2 : public Base
{
    public:
        void Func() override;     // 重写纯虚函数
};
void D2::Func() {  ……  }
int main()
{
    Base b = Base();     // 错误，Base 类是抽象类，不能定义对象。
    Base *ptr1 = new D1();     // 错误，D1 没有重写 Base 类的 Func 函数，所以也是抽象类。
    Base *ptr2 = new D2();     //正确
}
编程要求
在右侧编辑器中的Begin-End之间补充代码，设计图像基类、矩形类和圆形类三个类，函数成员变量据情况自己拟定，其他要求如下：

图形类（ shape ）

纯虚函数：void PrintArea()，用于输出当前图形的面积。
矩形类（ Rectangle ）

继承 Shape 类，并且重写 PrintArea 函数，输出矩形的面积，输出格式为：矩形面积 = width*height。

带参构造函数：Rectangle(float w,float h)，这两个参数分别赋值给成员变量的宽、高。

圆形类（ Circle ）

继承 Shape 类，并且重写 PrintArea 函数，输出圆形的面积，输出格式为：圆形面积 = radio * radio * 3.14。

带参构造函数：Circle(float r)，参数 r 代表圆的半径。

测试说明
平台会对你编写的代码进行测试，比对你输出的数值与实际正确数值，只有所有数据全部计算正确才能通过测试：

测试输入：10 2.5
预期输出：

矩形面积 = 20
圆形面积 = 314
测试输入：2 2.5
预期输出：

矩形面积 = 4
圆形面积 = 12.56
*/


/*User.h*/

#include <iostream>
using namespace std;

/********* Begin *********/

class Shape {
public:
    virtual void PrintArea() = 0;  // 纯虚函数，输出图形面积
    virtual ~Shape() {}  // 虚析构函数
};

class Rectangle : public Shape {
private:
    float width;
    float height;
public:
    Rectangle(float w, float h) : width(w), height(h) {}  // 带参构造函数
    void PrintArea() override {  // 重写纯虚函数，输出矩形面积
        cout << "矩形面积 = " << width * height << endl;
    }
};

class Circle : public Shape {
private:
    float radius;
public:
    Circle(float r) : radius(r) {}  // 带参构造函数
    void PrintArea() override {  // 重写纯虚函数，输出圆形面积
        cout << "圆形面积 = " << radius * radius * 3.14 << endl;
    }
};

/********* End *********/


/*run.cpp*/

/*
#include "usr.h"

int main()
{
	int i,j;
	cin >> i >> j;
    Shape *ptr = new Rectangle(i,j);
    ptr->PrintArea();
    delete ptr;

    ptr = new Circle(i);
    ptr->PrintArea();
    delete ptr;
}
*/