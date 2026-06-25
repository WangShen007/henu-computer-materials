/*ArrayList.cpp*/
#include "ArrayList.h"

/****************start from here**********************/

ArrayList::ArrayList(){
    capacity = 0;
    data = nullptr;
}

ArrayList::ArrayList(const ArrayList&rhs){
    size = rhs.size;
    capacity = rhs.capacity;
    data = new int[capacity];
    for(int i=0;i<size;++i){
        data[i] = rhs.data[i];
    }
}

ArrayList::ArrayList(int const a[],int n){
    size = n;
    capacity = n;
    data = new int[capacity];
    for(int i;i<size;++i){
        data[i] = a[i];
    }
}

ArrayList::ArrayList(int n,int value){
    size = n;
    capacity = n;
    data = new int[capacity];
    for(int i=0;i<size;++i){
        data[i] = value;
    }
}

ArrayList::~ArrayList(){
    delete [] data;
}

void ArrayList::insert(int pos,int value){
    if(pos<0||pos>size){
        throw "invalid position";
    }
    if(size==capacity){
        int newCapacity = capacity*2+1;
        int *newData = new int[newCapacity];
        for(int i=0;i<pos;++i){
            newData[i] = data[i];
        }
        newData[pos] = value;
        for(int i=pos;i<size;++i){
            newData[i+1] = data[i];
        }
        delete [] data;
        data = newData;
        capacity = newCapacity;
    }else{
        for(int i=size;i>pos;--i){
            data[i] = data[i-1];
        }
        data[pos] = value;
    }
    ++size;
}

void ArrayList::remove(int pos){
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    for(int i=pos;i<size-1;++i){
        data[i] = data[i+1];
    }
    --size;
}

int ArrayList::at(int pos)const{
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    return data[pos];
}

void ArrayList::modify(int pos,int newValue){
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    data[pos] = newValue;
}



/*LinkedList.cpp*/

#include "LinkedList.h"

/****************start from here**********************/


LinkedList::LinkedList(){
    head = nullptr;
}

LinkedList::LinkedList(const LinkedList&rhs){
    size = rhs.size;
    head = nullptr;
    Node *p = rhs.head;
    Node **q = &head;
    while(p){
        *q = new Node(p->data);
        p = p->next;
        q = &((*q)->next);
    }
}

LinkedList::LinkedList(int const a[],int n){
    size = n;
    head = nullptr;
    Node **p = &head;
    for(int i=0;i<size;++i){
        *p = new Node(a[i]);
        p = &((*p)->next);
    }
}

LinkedList::LinkedList(int n,int value){
    size = n;
    head = nullptr;
    Node **p = &head;
    for(int i=0;i<size;++i){
        *p = new Node(value);
        p = &((*p)->next);
    }
}

LinkedList::~LinkedList(){
    Node *p = head;
    while(p){
        Node *q = p->next;
        delete p;
        p = q;
    }
}

void LinkedList::insert(int pos,int value){
    if(pos<0||pos>size){
        throw "invalid position";
    }
    Node **p = &head;
    for(int i=0;i<pos;++i){
        p = &((*p)->next);
    }
    *p = new Node(value,*p);
    ++size;
}

void LinkedList::remove(int pos){
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    Node **p = &head;
    for(int i=0;i<pos;++i){
        p = &((*p)->next);
    }
    Node *q = *p;
    *p = q->next;
    delete q;
    --size;
}

int LinkedList::at(int pos)const{
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    Node *p = head;
    for(int i=0;i<pos;++i){
        p = p->next;
    }
    return p->data;
}

void LinkedList::modify(int pos,int newValue){
    if(pos<0||pos>=size){
        throw "invalid position";
    }
    Node *p = head;
    for(int i=0;i<pos;++i){
        p = p->next;
    }
    p->data = newValue;
}

void LinkedList::disp(ostream&os)const{
    Node *p = head;
    while(p){
        os<<p->data<<' ';
        p = p->next;
    }
    os<<endl;
}





/*
任务描述
建立一个继承体系。List 是基类，ArrayList 和 LinkedList 是派生类。

List 提供 5 个函数，分别是增删查改显。其中，前 4 个是纯虚函数，第 5 个是虚函数。

用户需在 ArrayList 和 LinkedList 中编写实现相应的实现。

注意一条：在 ArrayList 中无需再实现显示函数。

相关知识
虚函数是 C++ 实现动态绑定的关键。所谓动态绑定，如下：

List *pList;
pList = new ArrayList;
pList->insert(pList->getSize()-1,someValue);//ArrayList做尾插入比较快
delete pList;
pList = new LinkedList;
pList->insert(0,someValue);//LinkedList做头插入比较快
delete pList;
从语法上看，pList 只是一个指向 List 类型的指针。但是，在第 2、3 行代码中，pList 实际上指向了一个 ArrayList 对象。此时通过 pList 调用了 insert 成员函数。那么，此时调用的是 List 类的insert函数还是 ArrayList 类的 insert 函数呢？这取决于是否为虚函数。

如果 insert 成员函数是虚函数，则此时调用的是 ArrayList 的成员函数。如果 insert 成员函数不是虚函数，则此时调用的是 List 的成员函数。

因此，如果将insert函数设置为虚函数，就可以实现这样一种效果。如同上述代码的第 5、6 行所写。通过 pList 指针，既可以调用 ArrayList 的 insert 函数，也可以调用  LinkedList 的 insert 函数。

这样做有什么好处呢？我们来描述这样一种情形。需求是开发一款使用工业摄像头的图像处理程序。于是购买了 A 公司的摄像头产品，并使用其提供的图形采集函数，编程的代码如下：

A a;//A公司的摄像头对象
a.initialize();//初始化
while(1){ //死循环
    a.grab();//采集一帧
    这里作图像处理
}
过了一段时间，因为各种原因，要改用 B 公司的摄像头，当然随B公司也将随产品提供其自身的函数。于是，我们需要修改代码：

B a;//B公司的摄像头对象
a.start();//初始化，为什么B公司的函数名不做成跟A公司一样呢？
while(1){//死循环
    a.process();//采集一帧，这里不对B公司的取名抱任何期望
    这里作图像处理
}
你会发现，如果代码中涉及到的具体的摄像头函数越多，当你改用别家产品的时候，你需要修改的代码就越多。这意味着需要花费更多的人力、物力、时间，而且更容易出错。
可以这样做，仍然是先用 A 公司的，但是设计一个 Camera 基类，然后再派生一个类用于表示 A 公司的摄像头：

class Camera{
public:
    virtual void init();
    virtual void getFrame();
};
class CA : public Camera{
private:
    A a;//A公司的摄像头对象
public:
    void init(){a.initialize();}
    void getFrame(){a.grab();}
}
Camera *pCamera = new CA;
pCamera->init();
while(1){
    pCamera->getFrame();
    这里作图像处理
}
现在需要换产品了，怎么办？可以再添加一个CB类：

class CB : public Camera{
private:
    B a;//B公司的摄像头对象
public:
    void init(){a.start();}
    void getFrame(){a.process();}
};
对于我们的主程序，只需要改动一处即可：

//Camera *pCamera = new CA;
//只需改动这一句即可
Camera *pCamera = new CB;
pCamera->init();
while(1){
    pCamera->getFrame();
    这里作图像处理
}
后面这种编程的写法，与前一种写法相比，是更容易扩展、更容易升级的。当然要想获得这个好处，必须同时做到 2 点：类的编写者必须提供虚函数，类的使用者必须使用基类的指针或者引用。

因此，当你作为类的编写者编写类的时候，特别是编写继承体系时，必须提供合适的虚函数。当你作为类的使用者使用类的时候，必须优先定义基类的指针或者引用，如果没有特殊理由，绝不使用子类的类型。

另外，注意一点：公有继承的基类的析构函数必须是虚的。

所谓纯虚函数。C++ 允许一个类声明一个纯虚函数，即该虚函数未实现，没有函数体。此时，该类是一个抽象类，它一定是作为基类使用的。纯虚函数的作用，就是为其派生类规定函数的原型。这也被称为接口。C++ 中并没有专门描述接口的语法和关键字，C++ 中使用纯虚函数来完成接口的功能(有关接口的内容可以参考第 3 关)。而Java中则将 interface 作为了一个关键字。

顺便提一句，在一个继承体系中，如果基类的某个函数被 virtual 修饰了，其派生类以及派生类的派生类等等都不需要再显式的写出 virtual 关键字，该函数在其所有派生类中均是虚的。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
本关一共 4 个文件，其中List.h提供了 List 类。List 类提供 5 个虚函数，其中有 4 个是纯虚函数，需要用户在子类中实现。ArrayList.h提供了 ArrayList 类，LinkedList.h 提供了 LinkedList 类。这 2 个类都是 List 的派生类。
List.h 内容如下：

#ifndef _LIST_H_
#define _LIST_H_
#include <iostream>
using std::ostream;
using std::endl;
class List{
protected:
    int size;
public:
    //兼具默认构造函数和功能构造函数
    List(int s=0):size(s){}
    //拷贝构造函数
    List(const List&rhs):size(rhs.size){}
    以下为虚函数
    //作为继承的基类的析构函数一定要是虚的
    virtual ~List(){}
    以下为纯虚函数，即没有实现
    virtual void insert(int pos,int value)=0;
    virtual void remove(int pos)=0;
    virtual int at(int pos)const=0;
    virtual void modify(int pos,int newValue)=0;
    以下为普通的虚函数，有实现
    virtual void disp(ostream&os)const{
        for(int i=0,n=getSize();i<n;++i){
            os<<at(i)<<" ";//注意，这里at函数并没有实现
                           //但不妨碍这么写
        }
        os<<endl;
    }
};
#endif // _LIST_H_
ArrayList.h 内容如下：

#ifndef _ARRAYLIST_H_
#define _ARRAYLIST_H_
#include "List.h"
class ArrayList : public List{
private:
    int *data;   //真正保存数据的地方
    int capacity;//容量
public:
    //默认构造函数，构造一个逻辑为空的顺序表
    ArrayList();
    //拷贝构造函数，构造一个逻辑上与参数内容相同的顺序表
    ArrayList(const ArrayList&rhs);
    //原生数组构造函数，构造一个内容与给定数组相同的顺序表
    ArrayList(int const a[],int n);
    //填充构造函数，构造一个内容为n个value的顺序表
    ArrayList(int n,int value);
    //析构函数，一定要自行实现，否则有内存泄漏
    ~ArrayList();
    //子类当中须覆盖并实现父类中的纯虚函数
    void insert(int pos,int value);
    void remove(int pos);
    int at(int pos)const;
    void modify(int pos,int newValue);
    //对于父类中已实现的虚函数，可以选择覆盖或者不覆盖
    //void disp(ostream&os)const;//这个函数可以直接使用父类中的实现
};
#endif // _ARRAYLIST_H_
LinkedList.h 内容如下：

#ifndef _LINKEDLIST_H_
#define _LINKEDLIST_H_
#include "List.h"
class LinkedList : public List{
public:
    //这是单链表节点的结构体
    struct Node{
        int data;
        Node *next;
        Node(int a=0,Node *b=nullptr):data(a),next(b){}
    };
private:
    Node *head;//链表的头结点
public:
    //默认构造函数，构造一个逻辑为空的链表
    LinkedList();
    //拷贝构造函数，构造一个逻辑上与参数内容相同的链表
    LinkedList(const LinkedList&rhs);
    //原生数组构造函数，构造一个内容与给定数组相同的链表
    LinkedList(int const a[],int n);
    //填充构造函数，构造一个内容为n个value的链表
    LinkedList(int n,int value);
    //析构函数，一定要自行实现，否则有内存泄漏
    ~LinkedList();

    //子类当中须覆盖并实现父类中的纯虚函数
    void insert(int pos,int value);
    void remove(int pos);
    int at(int pos)const;
    void modify(int pos,int newValue);
    //对于父类中已实现的虚函数，可以选择覆盖或者不覆盖
    //对于LinkedList子类，必须重新实现disp函数
    void disp(ostream&os)const;
};
#endif // _LINKEDLIST_H_
main.cpp 内容如下：

#include <iostream>
#include "List.h"
#include "ArrayList.h"
#include "LinkedList.h"
using namespace std;
int A[1000];
int main(){
    //所有调用都通过基类的指针实现
    //如无特殊要求，绝不定义派生类类型的变量
    List *p = new ArrayList;
    int n;
    cin>>n;
    for(int i=0;i<n;++i){
        cin>>A[i];
        p->insert(p->getSize(),A[i]);
    }
    p->disp(cout);
    for(int i=0;i<3&&p->getSize()!=0;++i){
        p->remove(0);
    }
    p->disp(cout);
    for(int i=0;i<p->getSize();i+=2){
        p->modify(i,p->at(i)*10);
    }
    p->disp(cout);
    delete p;
    p = new LinkedList;
    for(int i=0;i<n;++i){
        p->insert(p->getSize(),A[i]);
    }
    p->disp(cout);
    for(int i=0;i<3;&&p->getSize()!=0;++i){
        p->remove(0);
    }
    p->disp();
    for(int i=0;i<p->getSize();i+=2){
        p->modify(i,p->at(i)*10);
    }
    p->disp(cout);
    delete p;
    return 0;
}
*/