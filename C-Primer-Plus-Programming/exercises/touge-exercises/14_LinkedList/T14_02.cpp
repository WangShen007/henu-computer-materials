/********** BEGIN **********/
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


/********** END **********/
















/*
任务描述
为 LinkedList 类实现增、删、查、改 4 种功能函数，同时为了显示输出，再实现一个 disp 函数，将数组内容输出到显示器。用户仍然要自行实现上一关中的构造函数与析构函数。

void insert(int pos,int value);
insert 函数在 pos 位置（从 0 开始编号）插入一个值为 value 的元素；

void remove(int pos);
remove 函数将 pos 位置上的元素删除；

int at(int pos)const;
at 函数返回 pos 位置上元素的值；

void modify(int pos,int newValue);
modify 函数将 pos 位置上的元素值修改为 newValue；

void disp()const;
disp函数将所保存的数据输出到屏幕，输出为一行，每个数据后面接一个空格。

通过观察可以，增、删、查、改都需要实现一个共同的功能，即：找到对应节点的指针。因此，再增加一个辅助函数：

Node *advance(int pos)const
返回指定位置的指针。
同时，由于这个函数是用于实现内部功能，所以将其设置为 private。

相关知识
对于增、删操作而言，都需要找到待操作节点的前一个节点。因此，如果是普通单链表，就有一个问题：头节点没有前一个节点。因此对头结点做增、删需要特殊的操作。
因此，这里建议使用带空头节点的链表。这样一来，所有合法位置上的增、删操作就可以保持一致了。
删除节点，一定要记住释放相应的内存。

编程要求
根据提示，在右侧编辑器的Begin-End区域内补充代码。

测试说明
该项目一共有3个文件，main.cpp、LinkedList.h 和 LinkedList.cpp。其中 main.cpp 是测试文件，LinkedList.h 包含 LinkedList 类的定义和成员函数声明。用户仅能修改 LinkedList.cpp 中的内容，在其中实现 LinkedList 的成员函数。

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
};
#endif // _LINKEDLIST_H_
main.cpp 的内容如下：

#include <iostream>
#include "LinkedList.h"
using namespace std;
int main(){
    int n,x;
    LinkedList a;
    cin>>n;
    for(int i=0;i<n;++i){
        cin>>x;
        a.insert(a.getSize(),x);
    }
    a.disp();
    for(int i=0;i<3&&a.getSize()!=0;++i){
        a.remove(0);
    }
    a.disp();
    for(int i=0;i<a.getSize();i+=2){
        a.modify(i,a.at(i)*10);
    }
    a.disp();
    return 0;
}
*/