/*LinkedList.cpp*/
#include "LinkedList.h"
#include <iostream>
using namespace std;


LinkedList::LinkedList(){
    head=nullptr;
    size=0;
}

LinkedList::LinkedList(const LinkedList&rhs){
    head=nullptr;
    size=0;
    Node *p=rhs.head;
    while(p){
        Node *q=new Node(p->data);
        if(head==nullptr){
            head=q;
        }else{
            Node *r=head;
            while(r->next){
                r=r->next;
            }
            r->next=q;
        }
        p=p->next;
        size++;
    }
}

LinkedList::LinkedList(int const a[],int n){
    head=nullptr;
    size=0;
    for(int i=0;i<n;i++){
        Node *q=new Node(a[i]);
        if(head==nullptr){
            head=q;
        }else{
            Node *r=head;
            while(r->next){
                r=r->next;
            }
            r->next=q;
        }
        size++;
    }
}

LinkedList::LinkedList(int n,int value){
    head=nullptr;
    size=0;
    for(int i=0;i<n;i++){
        Node *q=new Node(value);
        if(head==nullptr){
            head=q;
        }else{
            Node *r=head;
            while(r->next){
                r=r->next;
            }
            r->next=q;
        }
        size++;
    }
}

LinkedList::~LinkedList(){
    Node *p=head;
    while(p){
        Node *q=p->next;
        delete p;
        p=q;
    }
}

void LinkedList::insert(int pos,int value){
    if(pos<0||pos>size){
        cout<<"invalid position"<<endl;
        return;
    }
    Node *q=new Node(value);
    if(pos==0){
        q->next=head;
        head=q;
    }else{
        Node *p=advance(pos-1);
        q->next=p->next;
        p->next=q;
    }
    size++;
}

void LinkedList::remove(int pos){
    if(pos<0||pos>=size){
        cout<<"invalid position"<<endl;
        return;
    }
    Node *p;
    if(pos==0){
        p=head;
        head=head->next;
    }else{
        Node *q=advance(pos-1);
        p=q->next;
        q->next=p->next;
    }
    delete p;
    size--;
}

int LinkedList::at(int pos)const{
    if(pos<0||pos>=size){
        cout<<"invalid position"<<endl;
        return -1;
    }
    Node *p=advance(pos);
    return p->data;
}

void LinkedList::modify(int pos,int newValue){
    if(pos<0||pos>=size){
        cout<<"invalid position"<<endl;
        return;
    }
    Node *p=advance(pos);
    p->data=newValue;
}

void LinkedList::disp()const{
    Node *p=head;
    while(p){
        cout<<p->data<<' ';
        p=p->next;
    }
    cout<<endl;
}

LinkedList::Node *LinkedList::advance(int pos)const{
    Node *p=head;
    for(int i=0;i<pos;i++){
        p=p->next;
    }
    return p;
}

LinkedList& LinkedList::operator = (const LinkedList&rhs){
    if(this==&rhs){
        return *this;
    }
    Node *p=head;
    while(p){
        Node *q=p->next;
        delete p;
        p=q;
    }
    head=nullptr;
    size=0;
    p=rhs.head;
    while(p){
        Node *q=new Node(p->data);
        if(head==nullptr){
            head=q;
        }else{
            Node *r=head;
            while(r->next){
                r=r->next;
            }
            r->next=q;
        }
        p=p->next;
        size++;
    }
    return *this;
}

LinkedList& LinkedList::operator += (const LinkedList&rhs){
    Node *p=rhs.head;
    while(p){
        Node *q=new Node(p->data);
        if(head==nullptr){
            head=q;
        }else{
            Node *r=head;
            while(r->next){
                r=r->next;
            }
            r->next=q;
        }
        p=p->next;
        size++;
    }
    return *this;
}

int& LinkedList::operator [] (int pos){
    if(pos<0||pos>=size){
        cout<<"invalid position"<<endl;
        return head->data;
    }
    Node *p=advance(pos);
    return p->data;
}

const int& LinkedList::operator [] (int pos)const{
    if(pos<0||pos>=size){
        cout<<"invalid position"<<endl;
        return head->data;
    }
    Node *p=advance(pos);
    return p->data;
}

int LinkedList::compareTo(const LinkedList& rhs) const {
    Node *currentThis = head;
    Node *currentRhs = rhs.head;
    while (currentThis != nullptr && currentRhs != nullptr) {
        if (currentThis->data < currentRhs->data)
            return -1;
        else if (currentThis->data > currentRhs->data)
            return 1;
        currentThis = currentThis->next;
        currentRhs = currentRhs->next;
    }
    if (currentThis == nullptr && currentRhs == nullptr)
        return 0;
    else if (currentThis == nullptr)
        return -1;
    else
        return 1;
}

// Implement the disp member function
void LinkedList::disp(ostream& os) const {
    Node *current = head;
    while (current != nullptr) {
        os << current->data << " ";
        current = current->next;
    }
}




/*
任务描述
上一关说到由于效率问题，需要使用友元函数来实现函数形式的运算符重载。本关使用另外一种方法来解决 LinkedList 非成员函数形式运算符重载的效率问题。即：首先编写类似功能的成员函数，然后在运算符重载中进行调用。

相关知识
一般而言，倾向于不使用友元函数，因为友元函数会破坏封装性。这样考虑一下，如果某个类，有一大波的友元函数需要声明，那不如直接把这个类的所有成员都声明为 public。
当然，有人会强调类只会对某几个函数声明为友元，因此封装性还是存在的。这是一个“度”的问题。
总之，还是倾向于不使用友元函数。如果必须需要使用友元，可能只能说明该类的成员函数设计的还不够完善。
例如此处，要实现 operator+ 运算符重载，则首先实现一个 opertor+= 的成员函数，然后使用 opeartor+= 去实现 operator+。这个实现在 ArrayList 类中曾经演示过。
要实现关系运算符重载，首先实现一个成员函数：

int compareTo(const LinkedList&rhs);
该函数比较 2 个链表，如果 ∗this<rhs 则返回负数，相等则返回 0，再则返回正数。然后利用该函数实现关系运算符重载
要实现流输出运算符，则首先实现如下成员函数:

void disp(ostream&os)const;
然后在流输出运算符中调用该函数。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
本关一共 5 个文件。其中，LinkedList.h 是头文件，包含了 LinkedList 类的定义，其中包括以成员函数形式重载的运算符（简单赋值运算符，加号赋值运算符，方括号运算符）。LinkedListOp.h 是头文件，包含了以非成员函数形式重载的与 LinkedList 类有关的运算符（加号运算符，关系运算符，流输出运算符）。LinkedListOp.cpp 是非成员函数形式的运算符重载，已经给出了实现。
用户还需实现 LinkedList.cpp 中的内容。
main.cpp 是运行文件。

LinkedList.h 的内容如下：

#ifndef _LINKEDLIST_H_
#define _LINKEDLIST_H_
#include <iostream>
using namespace std;
class LinkedList{
public:
    //这是单链表节点的结构体
    struct Node{
        int data;
        Node *next;
        Node(int a=0,Node *b=nullptr):data(a),next(b){}
    };
private:
    Node *head;//链表的头结点
    int size;  //保存数据的数量，这是一个冗余数据
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
    //无话可说
    int getSize()const{return size;}
    //增删查改
    void insert(int pos,int value);
    void remove(int pos);
    int at(int pos)const;
    void modify(int pos,int newValue);
    void disp()const;
private:
    //辅助函数，返回指定位置的节点的指针
    Node *advance(int pos)const;
public:
    //赋值运算符重载
    LinkedList& operator = (const LinkedList&rhs);
    LinkedList& operator += (const LinkedList&rhs);
    //方括号运算符重载
    int& operator [] (int pos);
    const int& operator [] (int pos)const;
    int compareTo(const LinkedList&rhs)const;
    void disp(ostream&os)const;
};
#endif // _LINKEDLIST_H_
LinkedListOp.h 的内容如下：

#ifndef _LINKEDLISTOP_H_
#define _LINKEDLISTOP_H_
#include "LinkedList.h"
#include <iostream>
//加号运算符重载，加法实现连接功能
const LinkedList operator + (const LinkedList&lhs,const LinkedList&rhs);
//关系运算符重载，按照字典序比较顺序表
bool operator == (const LinkedList&lhs,const LinkedList&rhs);
bool operator != (const LinkedList&lhs,const LinkedList&rhs);
bool operator < (const LinkedList&lhs,const LinkedList&rhs);
bool operator <= (const LinkedList&lhs,const LinkedList&rhs);
bool operator > (const LinkedList&lhs,const LinkedList&rhs);
bool operator >= (const LinkedList&lhs,const LinkedList&rhs);
//流输出运算符重载，所有内容输出一行，每个数据后面接一个空格
using std::ostream;
ostream& operator << (ostream&os,const LinkedList&rhs);
#endif // _LINKEDLISTOP_H_
LinkedListOp.cpp 的内容如下：

#include "LinkedList.h"
//使用成员函数operator+=来实现加号运算符重载
const LinkedList operator + (const LinkedList&lhs,const LinkedList&rhs){
    LinkedList ans(lhs);
    return ans += rhs;
}
//使用成员函数compareTo来实现等于号运算符重载
bool operator == (const LinkedList&lhs,const LinkedList&rhs){
    return 0 == lhs.compareTo(rhs);
}
//其他关系运算符重载还是使用等于号与小于号组合得到
bool operator != (const LinkedList&lhs,const LinkedList&rhs){
    return ! ( lhs == rhs );
}
//使用成员函数compareTo来实现小于号运算符重载
bool operator < (const LinkedList&lhs,const LinkedList&rhs){
    return lhs.compareTo(rhs) < 0;
}
bool operator <= (const LinkedList&lhs,const LinkedList&rhs){
    return ( lhs < rhs ) || ( lhs == rhs );
}
bool operator > (const LinkedList&lhs,const LinkedList&rhs){
    return ! ( lhs <= rhs );
}
bool operator >= (const LinkedList&lhs,const LinkedList&rhs){
    return ! ( lhs < rhs );
}
//使用成员函数disp来实现流输出运算符重载
ostream& operator << (ostream&os,const LinkedList&rhs){
    rhs.disp(os);
    return os;
}
main.cpp 的内容如下：

#include <iostream>
#include "LinkedList.h"
#include <stdio.h>
using namespace std;
int main(){
    int n,m;
    cin>>n>>m;
    LinkedList a(n,0),b(m,0),c;
    for(int i=0;i<n;++i) cin>>a[i];
    for(int i=0;i<m;++i) cin>>b[i];
    c = a += b;
    cout<<(a==b)<<" "<<(a!=b)<<" "<<(a<b)<<" "<<(a<=b)<<" "<<(a>b)<<" "<<(a>=b)<<endl;
    cout<<(a==c)<<" "<<(a!=c)<<" "<<(a<c)<<" "<<(a<=c)<<" "<<(a>c)<<" "<<(a>=c)<<endl;
    cout<<(b==c)<<" "<<(b!=c)<<" "<<(b<c)<<" "<<(b<=c)<<" "<<(b>c)<<" "<<(b>=c)<<endl;
    cout<<a<<endl;
    cout<<b<<endl;
    cout<<c<<endl;
    return 0;
}
*/