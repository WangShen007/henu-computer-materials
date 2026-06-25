/*
Question:
任务描述
本关任务：设计三个复读机类并实现一个普通函数。

相关知识
为了完成本关任务，你需要掌握虚析构函数的使用。

多态性的体现
C++ 允许将一个对象的指针赋值给它的父类指针变量。而当通过父类指针调用一个虚函数时，则会调用子类中最后被重写的那个版本，这样对于同一段通过指针调用某个虚函数的代码，就会因为实际指向的对象不同，而调用不同函数，这就是所谓的多态性。

同理，通过引用调用一个虚函数，也会有这样的效果。

例如：

class Base
{
    public:
        virtual void Cal(int a,int b);
};
void Base::Cal(int a, int b)
{
    cout << a * b << endl;     // 默认是乘法
}
class Add : public Base
{
    public:
        void Cal(int a,int b) override;
};
void Add::Cal(int a,int b)
{
    cout << a + b << endl;     // 实现一个加法
}
class Sub : public Base
{
    public:
        void Cal(int a,int b) override;
};
void Sub::Cal(int a,int b)
{
    cout << a - b << endl;     //实现一个减法
}
//普通函数
void call(Base *ptr)
{
    ptr->Cal(10,10);     // 通过指针调用虚函数
}
int main()
{
    Add ad;
    call(&ad);
    Sub sb;
    call(&sb);
}
输出结果为：

20
0
可以看到，连续两次调用 call 函数，调用的效果有所不同。第一次调用的是对象是 Add，因此实现的是加法，即10+10=20；而第二次的调用对象是 Sub，实现的则是减法，即10-10=0。

虽然 C++ 也允许将子类对象直接赋值给父类变量，但是这样做会导致子类被切割成父类对象，丢失了子类的成分，这时调用虚函数，也就不会调用到被子类的重写的版本了。

例如：

 类的定义同上
void call(Base b)     // 这里不使用指针
{
    b.Cal(10,10);
}
int main()
{
    Add ad;
    call(ad);     // Add 子类赋值给 Base 父类变量
    Sub sb;
    call(sb);     // Sub 子类赋值给 Base 父类变量
}
输出结果为：

100
100
如果子类对象赋值给父类变量，则使用该变量时只能访问子类的父类部分（因为子类含有父类的部分，所以不会有问题）。因此无论哪个对象在调用 Call 函数时都是调用的父类的成员函数，所以输出结果都为100，即10*10=100。

虚析构函数
如果一个父类的析构函数没有声明成虚函数，那么使用 delete 运算符销毁一个父类指针所指的子类对象时，就只会调用父类的析构函数，子类的析构函数则不会被调用，这样就可能导致子类动态分配的资源无法及时回收，造成资源泄露。

例如：

class Base
{
    public:
        ~Base();     // 析构函数不是虚函数
};
Base::~Base()
{
    cout << "父类析构函数" << endl;
}
class D : public Base
{
    public:
        int *Ptr;
        D();
        ~D();
};
D::D():Ptr(new int){}     // 动态分配一块 int 类型大小的空间
D::~D()
{
    delete Ptr;     // 回收 Ptr 所指空间
    cout << "子类析构函数" << endl;
}
int main()
{
    Base *ptr = new D();
    delete ptr;     // 由于只会调用 Base 类的析构函数，导致 D 类中 Ptr 所指的那块空间没有被释放，造成内存泄露。
}
输出结果为：父类析构函数

如果将析构函数声明为虚函数，调用它时除了调用子类重写的那个版本，还会沿着继承链向上（父类方向）依次调用父类的析构函数。

对于上面那个例子，如果将 Base 类的析构函数声明成虚函数，即virtual ~Base()，那么最后得到的输出结果就是：

子类析构函数
父类析构函数
即也就是依次调用了 D 类、Base 类的析构函数。所以，在一般情况下析构函数建议声明成虚函数。

编程要求
在右侧编辑器中的Begin-End之间补充代码，设计三个复读机类和一个普通函数，具体要求如下：

复读机类（ Repeater ）

它有一个成员函数 Play，在这里它什么也不做。它还有一个析构函数，它被调用时会输出一行砰！。
正向复读机类（ ForRepeater ）

继承 Repeater 类并重写 Play 函数，输出没想到你也是一个复读机且在析构函数中输出正·复读机 炸了。
反向复读机类（ RevRepeater ）

继承 Repeater 类也重写 Play 函数，输出机读复个一是也你到想没且在析构函数中输出机读复·反 炸了。
普通函数：Repeater* CreateRepeater(int type)，函数根据 type 的值，动态创建不同的复读机对象，并返回它的指针。其中当type = 0，创建 ForRepeater 对象；type = 1，创建 RevRepeater 对象；其他则返回 0。

测试说明
平台会对你编写的代码进行测试，比对你输出的数值与实际正确数值，只有所有数据全部计算正确才能通过测试：

测试输入：0

预期输出：

没想到你也是一个复读机
正·复读机 炸了
砰！
*/

/*Use.h*/
#include <iostream>
using namespace std;

/********* Begin *********/
class Repeater
{
    //复读机基类的声明
public:
    virtual void Play() {}  // 虚函数 Play，不做任何事
    virtual ~Repeater()     // 虚析构函数
    {
        cout << "砰！" << endl;
    }
};

class ForRepeater : public Repeater
{
    //正向复读机的声明
public:
    void Play() override
    {
        cout << "没想到你也是一个复读机" << endl;
    }
    ~ForRepeater() override
    {
        cout << "正·复读机 炸了" << endl;
    }
};

class RevRepeater : public Repeater
{
    //反向复读机的声明
public:
    void Play() override
    {
        cout << "机读复个一是也你到想没" << endl;
    }
    ~RevRepeater() override
    {
        cout << "机读复·反 炸了" << endl;
    }
};

//普通函数
Repeater* CreateRepeater(int type)
{
    //根据type创建指定的复读机
    if (type == 0)
    {
        return new ForRepeater();
    }
    else if (type == 1)
    {
        return new RevRepeater();
    }
    else
    {
        return nullptr;
    }
}


/*Run.cpp*/
/*
#include "usr.h"

int main()
{
	int i;
	cin >> i;
    Repeater *ptr = CreateRepeater(i);
    ptr->Play();
    delete ptr;
}
*/