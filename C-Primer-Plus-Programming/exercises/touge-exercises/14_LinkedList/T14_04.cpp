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
#include <iostream>
using namespace std;
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
本关与上一关类似，实现与 LinkedList 有关的运算符重载。不过，非成员函数形式的运算符重载，均会被声明为 LinkedList 类的友元函数。

相关知识
在上一关中，如果要实现与 LinkedList 类相关的非成员函数形式的运算符重载，其实现过程中必然会调用 LinkedList 中的 public 成员函数。以流输出运算符重载为例，其实现过程必然为如下两种之一：

ostream& operator << (ostream&os,const LinkedList&rhs){
    for(int i=0;i<rhs.getSize();++i){
        os<<rhs.at(i)<<" ";
    }
    return os;
}
或者

ostream& operator << (ostream&os,const LinkedList&rhs){
    for(int i=0;i<rhs.getSize();++i){
        os<<rhs[i]<<" ";
    }
    return os;
}
但很遗憾，这两种实现方式有着同样的问题——效率问题。仔细考查 at 函数即可知道，调用 at(i) 函数就会循环 i 次。假设链表一共包含 n 个数据，那么流输出运算符循环的次数为：

1+2+...+n=
2
1
​
 n(n+1)

而很明显，我们期望的循环次数应该就是 n。使用算法中的术语描述，就是：流输出运算符的时间复杂度应该是 O(n)，但是此处这个实现却是 O(n
2
 ) 。这是一个质的下降，是不能忍受的。其他非成员函数形式的运算符重载，也有类似问题，包括加号运算符和关系运算符。
因此，我们需要重新设计 LinkedList 类，使得这些运算符都只需要循环 n 次即可解决问题。
其中一种方法就是将这些运算符重载均声明为友元函数，这样就可以在这些函数中直接操作链表的指针，从而达到目的。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
本关一共 5 个文件。其中，LinkedList.h 是头文件，包含了 LinkedList 类的定义，其中包括以成员函数形式重载的运算符（简单赋值运算符，加号赋值运算符，方括号运算符）。LinkedListOp.h 是头文件，包含了以非成员函数形式重载的与 LinkedList 类有关的运算符（加号运算符，关系运算符，流输出运算符）。
LinkedList.cpp 和 LinkedListOp.cpp 是实现文件，用户需要自行实现其中的内容。
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
    //友元函数声明
    friend const LinkedList operator + (const LinkedList&lhs,const LinkedList&rhs);
    friend bool operator == (const LinkedList&lhs,const LinkedList&rhs);
    friend bool operator < (const LinkedList&lhs,const LinkedList&rhs);
    friend ostream& operator << (ostream&os,const LinkedList&rhs);
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

/*
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