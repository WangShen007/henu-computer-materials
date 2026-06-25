/********** BEGIN **********/
#include "LinkedList.h"

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






/********** End **********/

/*
任务描述
LinkedList 类是一个比较复杂的类，首先需要实现其构造函数。要求用户为 LinkedList 类提供 4 种构造函数。分别是：

默认构造函数
使用该函数构造出的数组对象，逻辑上是空的

拷贝构造函数
使用该函数构造出的输出对象，逻辑上的内容应与参数一模一样

原生输出构造函数
给定一个C++的原生数组，构造出内容一模一样的数组对象

填充构造函数
给定参数 n 与 value，构造出一个数组对象，其内容是 n 个 value。

在构造函数中，涉及到申请内存。凡是与系统资源打交道的代码一定要做异常检测。内存就是一种系统资源，所以一定要坚持申请内存是否成功。不过本任务忽略这一步。

此外，还需要实现析构函数。因为 LinkedList 与 ArrayList 类一样，必须要自行提供析构函数。

相关知识
从数据结构的角度，LinkedList 类就代表链表。要实现链表，首先就需要定义链表节点。因为此处实现的是单链表，所以表示链表节点的结构体定义如下：

struct Node{
    int data;  //仍然假定只保存int类型数据
    Node *next;//指针
    //为该结构体提供一个构造函数
    Node(int a=0,Node*b=nullptr):data(a),next(b){}
};
同时需要注意，这个结构体与链表有关，所以一般定义在链表类的内部，是一个内部结构体。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
该项目一共有3个文件，main.cpp、LinkedList.h 和 LinkedList.cpp。其中 main.cpp 是测试文件，LinkedList.h 包含 LinkedList 类的定义和成员函数声明。用户仅能修改 LinkedList.cpp 中的内容，在其中实现LinkedList的成员函数。
LinkedList.h 的内容如下

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
};
#endif // _LINKEDLIST_H_
main.cpp 的内容如下

#include <iostream>
#include "LinkedList.h"
using namespace std;
int A[] = {100,200,400,800,1600};
int main(){
    LinkedList a,b(A,4);
    LinkedList c(b),d(8,6);
    cout<<a.getSize()<<" "<<b.getSize()<<" "<<c.getSize()<<" "<<d.getSize()<<endl;
    return 0;
}

*/