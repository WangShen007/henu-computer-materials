#include <iostream>
using namespace std;
using std::ostream;
class List{
protected:
    int size;
public:
    //兼具默认构造函数和功能构造函数
    List(int s=0):size(s){}
    //拷贝构造函数
    List(const List&rhs):size(rhs.size){}
    /*以下为虚函数*/
    //作为继承的基类的析构函数一定要是虚的
    virtual ~List(){}
    //普通的非虚函数
    int getSize()const{return size;}
    /*以下为纯虚函数，即没有实现*/
    virtual void insert(int pos,int value)=0;
    virtual void remove(int pos)=0;
    virtual int at(int pos)const=0;
    virtual void modify(int pos,int newValue)=0;
    /*你的工作在这里：此处设计disp函数*/
    virtual void disp(ostream&os) const
    {
        for(int i = 0;i < size;i++)
        {
            os << at(i) << " ";
        }
        os << std::endl;
    }
};

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

private:
    void setCapacity(int newCapa);
};

ArrayList::ArrayList():List(0),data(NULL),capacity(0){}

ArrayList::ArrayList(const ArrayList&rhs):List(rhs.size),data(NULL),capacity(0)
{
    setCapacity(rhs.capacity);
    for(int i = 0;i < size;i++)
    {
        data[i] = rhs.data[i];
    }
}

ArrayList::ArrayList(int const a[],int n):List(n),data(NULL),capacity(0)
{
    setCapacity(n);
    for(int i = 0;i < size;i++)
    {
        data[i] = a[i];
    }
}

ArrayList::ArrayList(int n,int value):List(n),data(NULL),capacity(0)
{
    setCapacity(n);
    for(int i = 0;i < size;i++)
    {
        data[i] = value;
    }
}

ArrayList::~ArrayList()
{
    delete []data;
}

void ArrayList::insert(int pos,int value)
{
    if(pos < 0 || pos > size)
    {
        return;
    }
    if(size == capacity)
    {
        setCapacity(capacity*2+1);
    }
    for(int i = size;i > pos;i--)
    {
        data[i] = data[i-1];
    }
    data[pos] = value;
    size++;
}

void ArrayList::remove(int pos)
{
    if(pos < 0 || pos >= size)
    {
        return;
    }
    for(int i = pos;i < size-1;i++)
    {
        data[i] = data[i+1];
    }
    size--;
}

int ArrayList::at(int pos)const
{
    if(pos < 0 || pos >= size)
    {
        return -1;
    }
    return data[pos];
}

void ArrayList::modify(int pos,int newValue)
{
    if(pos < 0 || pos >= size)
    {
        return;
    }
    data[pos] = newValue;
}

void ArrayList::setCapacity(int newCapa)
{
    if(newCapa <= capacity)
    {
        return;
    }
    int *newData = new int[newCapa];
    for(int i = 0;i < size;i++)
    {
        newData[i] = data[i];
    }
    delete []data;
    data = newData;
    capacity = newCapa;
}


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

private:
    Node* advance(int pos)const;
};

LinkedList::LinkedList():List(0),head(nullptr){}

LinkedList::LinkedList(const LinkedList&rhs):List(rhs.size),head(nullptr)
{
    Node *p = rhs.head;
    Node *last = nullptr;
    while(p != nullptr)
    {
        Node *newNode = new Node(p->data);
        if(last == nullptr)
        {
            head = newNode;
        }
        else
        {
            last->next = newNode;
        }
        last = newNode;
        p = p->next;
    }
}

LinkedList::LinkedList(int const a[],int n):List(n),head(nullptr)
{
    Node *last = nullptr;
    for(int i = 0;i < n;i++)
    {
        Node *newNode = new Node(a[i]);
        if(last == nullptr)
        {
            head = newNode;
        }
        else
        {
            last->next = newNode;
        }
        last = newNode;
    }
}

LinkedList::LinkedList(int n,int value):List(n),head(nullptr)
{
    Node *last = nullptr;
    for(int i = 0;i < n;i++)
    {
        Node *newNode = new Node(value);
        if(last == nullptr)
        {
            head = newNode;
        }
        else
        {
            last->next = newNode;
        }
        last = newNode;
    }
}

LinkedList::~LinkedList()
{
    Node *p = head;
    while(p != nullptr)
    {
        Node *q = p->next;
        delete p;
        p = q;
    }
}

void LinkedList::insert(int pos,int value)
{
    if(pos < 0 || pos > size)
    {
        return;
    }
    Node *newNode = new Node(value);
    if(pos == 0)
    {
        newNode->next = head;
        head = newNode;
    }
    else
    {
        Node *p = advance(pos-1);
        newNode->next = p->next;
        p->next = newNode;
    }
    size++;
}

void LinkedList::remove(int pos)
{
    if(pos < 0 || pos >= size)
    {
        return;
    }
    if(pos == 0)
    {
        Node *p = head;
        head = head->next;
        delete p;
    }
    else
    {
        Node *p = advance(pos-1);
        Node *q = p->next;
        p->next = q->next;
        delete q;
    }
    size--;
}

int LinkedList::at(int pos)const
{
    if(pos < 0 || pos >= size)
    {
        return -1;
    }
    Node *p = advance(pos);
    return p->data;
}

void LinkedList::modify(int pos,int newValue)
{
    if(pos < 0 || pos >= size)
    {
        return;
    }
    Node *p = advance(pos);
    p->data = newValue;
}

void LinkedList::disp(ostream&os)const
{
    Node *p = head;
    while(p != nullptr)
    {
        os << p->data << " ";
        p = p->next;
    }
    os << std::endl;
}

LinkedList::Node* LinkedList::advance(int pos)const
{
    Node *p = head;
    for(int i = 0;i < pos;i++)
    {
        p = p->next;
    }
    return p;
}

/*
任务描述
建立一个继承体系，List 是基类，ArrayList 和 LinkedList 是其派生类。并且编写实现下述函数并达到如下效果。

ostream& operator << (ostream&os, const List&rhs);
做一个流输出运算符重载，其第二个参数是List的常引用类型。我们知道子类的对象天生可以作为父类类型使用，因此

ArrayList a;
LinkedList b;
operator << (cout,a);
operator << (cout,b);
这上面的调用显然都是合法的。但是现在要求实现如下效果：第 3 行的函数执行的是适合 ArrayList 输出的代码，而第 4 行执行的是适合 LinkedList 输出的代码。即，虽然调用的函数一样，但需要根据当时的实参类型选择合适的实现。相当于对非成员函数做到动态绑定。

相关知识
前面说过，虚函数可以实现动态绑定。也就是：

class List{
public:
virtual void disp(ostream&os)const;
};
class ArrayList : public List{
public:
    void disp(ostream&os)const{这里是ArrayList的实现}
}
class LinkedList : public List{
public:
    void disp(ostream&os)const{这里是LinkedList的实现}
}
List *p = new ArrayList;
p->disp(cout);//此时调用的是ArrayList的disp函数
delete p;
p = new LinkedList;
p->disp(cout);//此时调用的是LinkedList的disp函数
delete p;
如果是非成员函数，能不能实现类似效果呢？即

ostream& operator << (ostream&os, const List&rhs);
ostream& operator <<  (ostream&os, const ArrayList&rhs);
ostream& operator <<  (ostream&os, const LinkedList&rhs);
List *p = new ArrayList;
cout<<*p<<endl;//此时希望调用的是operator<<(ostream,ArrayList&)
delete p;
p = new LinkedList;
cout<<*p<<endl;//此时希望调用的是operator<<(ostream,LinkedList&)
delete p;
遗憾的是，非成员函数不具备这样的功能。对于上述流输出运算符调用而言，它的实参会被看作是 List 类型，因此只会调用上文中的第一个重载函数。而不会根据 p 实际指向的类型动态调用其他流输出重载函数。
如何令非成员函数也体现出动态绑定的特性呢？答案是通过成员函数，而不是通过函数重载。例如，可以这样实现流输出运算符重载：

ostream& operator << (ostream&os,const List&rhs){
    rhs.disp(os);
    return os;
}
*************************************************
*这里不再需要实现
* ostream& operator <<  (ostream&os, const List&rhs);
*和
* ostream& operator <<  (ostream&os, const List&rhs);
*等函数
****************************************************
编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
本关共有 8 个文件。其中 List.h 定义了 List 类及其成员函数。ListOp.h 和 ListOp.cpp 定义了与 List 相关的运算符重载。ArrayList.h 和 ArrayList.cpp 定义了 ArrayList 类及其成员函数。LinkedList.h 和 LinkedList.cpp 定义了 LinkedList 类及其成员函数。main.cpp 定义了主函数。
用户的任务是编写 List.h、ArrayList.cpp 和 LinkedList.cpp 文件，以使得 main.cpp 正确运行。
List.h 内容如下：

#ifndef _LIST_H_
#define _LIST_H_
#include <iostream>
using std::ostream;
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
    //普通的非虚函数
    int getSize()const{return size;}
    以下为纯虚函数，即没有实现
    virtual void insert(int pos,int value)=0;
    virtual void remove(int pos)=0;
    virtual int at(int pos)const=0;
    virtual void modify(int pos,int newValue)=0;
    你的工作在这里：此处设计disp函数

};
#endif // _LIST_H_
ListOp.h 内容如下：

#include "List.h"
//流输出运算符重载声明
ostream operator << (ostream& os,const List& rhs);
ListOp.cpp 内容如下：

#include "List.h"
#include <iostream>
using std::ostream;
ostream& operator << (ostream&os, const List&rhs){
    rhs.disp(os);
    return os;
}
ArrayList.h 的内容如下：

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

private:
    void setCapacity(int newCapa);
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

private:
    Node* advance(int pos)const;
};
#endif // _LINKEDLIST_H_
main.cpp 内容如下：

#include "List.h"
#include "ArrayList.h"
#include "LinkedList.h"
using namespace std;
int A[1000];
int main(){
    List *p = new ArrayList;
    int n;
    cin>>n;
    for(int i=0;i<n;++i){
        cin>>A[i];
        p->insert(p->getSize(),A[i]);
    }
    cout<<*p<<endl;
    for(int i=0;i<3&&p->getSize()!=0;++i){
        p->remove(0);
    }
    cout<<*p<<endl;
    for(int i=0;i<p->getSize();i+=2){
        p->modify(i,p->at(i)*10);
    }
    cout<<*p<<endl;
    delete p;
    p = new LinkedList;
    for(int i=0;i<n;++i){
        p->insert(p->getSize(),A[i]);
    }
    cout<<*p<<endl;
    for(int i=0;i<3&&p->getSize()!=0;++i){
        p->remove(0);
    }
    cout<<*p<<endl;
    for(int i=0;i<p->getSize();i+=2){
        p->modify(i,p->at(i)*10);
    }
    cout<<*p<<endl;
    delete p;
    return 0;
}
*/