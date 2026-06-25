#include <iostream>
#include <cmath>

using namespace std;

class QuadraticEquation
{
    public:
    double a, b, c;
    QuadraticEquation(double a, double b, double c)
    {
        this->a = a;
        this->b = b;
        this->c = c;
        /*this指针是隐含每一个非静态成员函数内的一种指针，this指针不需要定义，直接使用即可。

        this指针的用途：

        当形参和成员变量同名时，可用this指针来区分
        在类的非静态成员函数中返回对象本身，可使用return *this*/
    }
    
    double getA()
    {
        return a;
    }

    double getB()
    {
        return b;
    }

    double getC()
    {
        return c;
    }

    double getDiscriminant()
    {
        return b * b - 4 * a * c;
    }

    double getRoot1()
    {
        return (-b + sqrt(getDiscriminant())) / (2 * a);
    }

    double getRoot2()
    {
        return (-b - sqrt(getDiscriminant())) / (2 * a);
    }
    
};

int main()
{
    double a, b, c;
    cout << "Please input a, b, c: ";
    cin >> a >> b >> c;
    QuadraticEquation qe(a, b, c);
    if (qe.getDiscriminant() < 0)
    {
        cout << "The equation has no real roots." << endl;
    }
    else if (qe.getDiscriminant() == 0)
    {
        cout << "The equation has one root: " << qe.getRoot1() << endl;
    }
    else
    {
        cout << "The equation has two roots: " << qe.getRoot1() << " and " << qe.getRoot2() << endl;
    }

}

