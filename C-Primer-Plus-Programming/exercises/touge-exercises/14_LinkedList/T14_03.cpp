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



/*LinkedListOp.cpp*/
#include "LinkedListOp.h"
const LinkedList operator + (const LinkedList&lhs,const LinkedList&rhs){
    LinkedList res=lhs;
    res+=rhs;
    return res;
}

bool operator == (const LinkedList&lhs,const LinkedList&rhs){
    if(lhs.getSize()!=rhs.getSize()){
        return false;
    }
    for(int i=0;i<lhs.getSize();i++){
        if(lhs[i]!=rhs[i]){
            return false;
        }
    }
    return true;
}

bool operator != (const LinkedList&lhs,const LinkedList&rhs){
    return !(lhs==rhs);
}

bool operator < (const LinkedList&lhs,const LinkedList&rhs){
    for(int i=0;i<lhs.getSize()&&i<rhs.getSize();i++){
        if(lhs[i]<rhs[i]){
            return true;
        }else if(lhs[i]>rhs[i]){
            return false;
        }
    }
    return lhs.getSize()<rhs.getSize();
}

bool operator <= (const LinkedList&lhs,const LinkedList&rhs){
    return lhs<rhs||lhs==rhs;
}

bool operator > (const LinkedList&lhs,const LinkedList&rhs){
    return !(lhs<=rhs);
}

bool operator >= (const LinkedList&lhs,const LinkedList&rhs){
    return !(lhs<rhs);
}

ostream& operator << (ostream&os,const LinkedList&rhs){
    for(int i=0;i<rhs.getSize();i++){
        os<<rhs[i]<<' ';
    }
    return os;
}







/*
任务描述
为 LinkedList 类做相关的运算符重载，包括：2 个赋值运算符（简单赋值与加号赋值）、1 个算术运算符（加号）、6 个关系运算符、1 个流输出运算符和 2 个方括号运算符（const 版本与非 const 版本）。
加号运算完成连接操作，而关系运算按照字典序比较。

相关知识
方括号运算符必须返回引用，因为如果不返回引用，该重载的方括号就不能像 C++ 内置的方括号一样使用。不返回引用，如下代码逻辑上就不能成功运行。

LinkedList a;
a[2] = 8;
此处方括号可以重载 2 个版本，const 版本与非 const 版本，分别是：

int& operator [] (int pos);
const int& operator [] (int pos)const;
另外，考虑到开发的效率，必须使用函数复用来解决运算符重载。也就是有一些运算符重载可以使用已有的另外的运算符重载来实现。典型的如先重载等于号运算符，再使用等于号来实现不等于号。
注意，上述 2 个方括号运算符重载也可以使用函数复用。与 ArrayList 相比，这里的方括号运算符采用函数复用具有一定的现实意义。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
本关一共 5 个文件。其中，LinkedList.h 是头文件，包含了 LinkedList 类的定义，其中包括以成员函数形式重载的运算符（简单赋值运算符，加号赋值运算符，方括号运算符）。LinkedListOp.h 是头文件，包含了以非成员函数形式重载的与 LinkedList 类有关的运算符（加号运算符，关系运算符，流输出运算符）。
LinkedList.cpp 和 LinkedListOp.cpp 是实现文件，用户需要自行实现其中的内容。
main.cpp 是运行文件。
LinkedList.h 的内容如下：

#ifndef _LINKEDLIST_H_
#define _LINKEDLIST_H_
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
main.cpp 的内容如下：

#include <iostream>
#include "LinkedList.h"
#include "LinkedListOp.h"
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