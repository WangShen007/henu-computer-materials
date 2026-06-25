/*
C++ 2024/5/15
头歌：15 - C++ 面向对象 - STL 的应用

任务描述
本关任务：编写一个能动态管理学生信息的程序。

相关知识
本关涉及的内容如下：

vector容器的使用
容器的迭代器
sort函数的使用
find函数的使用
vector容器的使用
vector位于头文件<vector>，是C++提供的一种顺序存储的容器，能通过位置索引高效的访问容器中的任意元素，可以看做是一个长度能动态变化的数组。

vector类是一个模板类，使用时需要指定模板参数。注意：作为模板参数的类型要有无参数的构造函数（如果不使用Allocator）。

它常用的构造函数如下：

int main()
{
vector<string> v; //无参数版
vector<string> v2(10); //初始容量为10的vector，每个元素为都为string的默认值
vector<string> v3(10,"abc"); //初始容量为10，且每一个元素都为 abc
}
如果要访问或者修改vector的内容可以用如下的函数：

vector<int> v;
v.push_back(10); //将一个元素添加到容器的末尾
v.push_back(20);
cout << v[0] << endl; //访问索引为0的元素，即 10
v.erase(v.begin() + 1); //删除索引为1的元素，begin()函数的含义见下一节
v.insert(v.begin() + 1,30); //在索引为1的元素之前插入一个元素
v.clear(); //删除所有元素
同时，vector还有如下的成员函数用于查询元素数量：

int size = v.size(); //返回元素数量
bool isem = v.empty(); //容器为空则返回true
vector的成员函数不仅仅只有这些，感兴趣的同学可以查阅其他资料进行学习。

容器的迭代器
STL中的容器都提供了 迭代器iterator 成员类型，它就像一个指针，使用它能按照一种 特定的顺序 遍历容器中的所有元素。

一般来说，当你对一个迭代器it进行it++自增操作时，就能进入到下一个元素，进行it--自减操作时，就能回到上一个元素。有些迭代器还支持it+=2，it-=2这样跨多个元素的操作。而对它使用*it取值操作，就能获得当前的元素值。

上一节的begin()函数，返回的其实就是一个指向第一个元素的迭代器，与之对应的还有一个end()函数，它返回一个指向最后一个元素之后不存在的元素的迭代器，有了这两个函数，我们就能访问vector中的所有元素了：

vector<int> v(5,10); //容量为5，元素值都是10
for(vector<int>::iterator it = v.begin();it != v.end();it++)
cout << *it << " ";
得到的结果是：

10 10 10 10 10

此时我们也可以知道，vector的erase，insert函数的参数实际上都是迭代器类型。

注意：在使用迭代器迭代一个容器的过程中，使用修改容器内容的函数可能会使得迭代器无效，因此尽量不要在这个过程中修改容器内容。

sort函数的使用
sort函数位于头文件<algorithm>，它接受两个迭代器参数first和last，代表要排序的范围，为左闭右开，即[first,last)，然后将这个范围里的元素按照升序排列。

它要求迭代器的元素类型重载了此类型对象间比较用的<运算符。

注意：指针也可以看做是一种迭代器，所以对于数组也是可以使用这个函数的。

比如：

vector<int> v;
v.push_back(2);
v.push_back(1);
int vs[]={2,1};
sort(v.begin(),v.end()); //排序vector
sort(vs,vs + 2); //排序数组
两个容器内的元素都是：1 2

find 函数的使用
find函数位于头文件<algorithm>，它接受三个参数，前两个迭代器类型的first，last参数代表范围，左闭右开，第三个value参数代表要查找的内容，因此元素类型必须重载了用于元素和value之间比较的==运算符。

它返回的也是一个迭代器，如果找到了这个元素，则返回指向这个元素的迭代器，如果没有，则返回last参数。

比如：

vector<int> v;
v.push_back(2);
v.push_back(1);
int vs[]={2,1};
find(v.begin(),v.end(),3); //不存在3元素，所以会返回v.end()
find(vs,vs + 2,1); //返回指向数组中 1 元素的指针
注意：find函数在比对元素的时候，==运算符的第二个参数是要找的内容，即参数value。

编程要求
学员需要设计一个学员信息表，并在主函数中读取输入，根据输入的内容作出相应的动作。
输入共有4种，格式如下：

A <姓名> <分数>，向信息表的末尾添加一条记录，内容为<姓名> <分数>，分数均为整数。
注意：如果表中已有同一个人的记录，那就只更新分数。

R <姓名>，删除表中指定姓名的条目，不存在则不做处理。
P，按照<姓名> <分数>的格式打印整个信息表，每条记录占1行。如果表为空，则输出一行[空]。
S，将整个信息表的数据按照分数的降序排序。
注意 ：为了保证排序结果稳定，输入的数据保证不会有两条记录有相同的分数。

每种格式的输入占一行，测试有多行输入。详细见测试说明。

测试说明
测试输入：

A 小明 89
A 小张 91
A 小李 67
P
R 小李
S
P

预期输出：

小明 89
小张 91
小李 67
小张 91
小明 89

开始你的任务吧，祝你成功！
*/

#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

class Student
{
private:
    string name;
    int score;
public:
    Student(string name, int score)
    {
        this->name = name;
        this->score = score;
    }
    string getName()
    {
        return name;
    }
    int getScore()
    {
        return score;
    }
    friend void P(const Student &s);
    friend void R(vector<Student> &v, string name);
    friend void S(vector<Student> &v);
    friend void A(vector<Student> &v);
};
void A(vector<Student> &v)
{
    string name;
    int score;
    cin >> name >> score;
    bool exist = false;
    for(int i = 0; i < v.size(); i++)
    {
        if(v[i].name == name)
        {
            v[i].score = score;
            exist = true;
            return;
        }
    }
    if(!exist)
    {
        Student s(name, score);
        v.push_back(s);
    }
}
void P(const Student &s)
{
    cout << s.name << " " << s.score << endl;
}
void R(vector<Student> &v, string name)
{
    vector<Student> temp;
    for (int i = 0; i < v.size(); i++)
    {
        if (v[i].name != name)
        {
            temp.push_back(v[i]);
        }
    }
    v = temp;
}/*
void R(vector<Student> &v, string name)
{
    for (vector<Student>::iterator it = v.begin(); it != v.end();)
    {
        if (it->name == name)
        {
            it = v.erase(it);
        }
        else
        {
            it++;
        }
    }
}
这段代码定义了一个名为 R 的函数，该函数接受两个参数：一个 Student 类型的向量引用 v 和一个字符串 name。这个函数的主要目的是从向量 v 中移除所有名字为 name 的 Student 对象。
首先，函数创建了一个迭代器 it，并将其初始化为指向向量 v 的开始位置。然后，它进入一个循环，直到迭代器到达向量的末尾。
在每次循环中，函数首先检查当前迭代器指向的 Student 对象的 name 成员是否等于输入的 name。如果等于，那么使用 erase 函数移除这个 Student 对象，并将迭代器更新为指向下一个元素。如果不等于，那么迭代器直接向后移动一位。
注意，当从向量中移除元素时，后面的元素会向前移动来填补空位，因此需要用 erase 函数的返回值来更新迭代器。否则，如果直接对迭代器进行递增操作，可能会跳过一些元素或者访问到无效的内存。
总的来说，这个函数实现了一个过滤功能：移除向量 v 中所有名字为 name 的 Student 对象。
*//*
*//*
容器的迭代器
STL中的容器都提供了 迭代器iterator 成员类型，它就像一个指针，使用它能按照一种 特定的顺序 遍历容器中的所有元素。

一般来说，当你对一个迭代器it进行it++自增操作时，就能进入到下一个元素，进行it--自减操作时，就能回到上一个元素。有些迭代器还支持it+=2，it-=2这样跨多个元素的操作。而对它使用*it取值操作，就能获得当前的元素值。

上一节的begin()函数，返回的其实就是一个指向第一个元素的迭代器，与之对应的还有一个end()函数，它返回一个指向最后一个元素之后不存在的元素的迭代器，有了这两个函数，我们就能访问vector中的所有元素了：

std::vector<int> v = {1, 2, 3, 4, 5};
for(std::vector<int>::iterator it = v.begin(); it != v.end(); ++it)
std::cout << *it << std::endl;

在这个示例中，我们首先创建了一个 std::vector<int>::iterator 类型的迭代器 it，并将其初始化为 v.begin()，即向量 v 的开始位置。然后，我们使用一个 for 循环来遍历向量。在每次迭代中，我们使用 *it 来访问当前元素，然后将迭代器向后移动一位（++it）。当迭代器到达向量的末尾（v.end()）时，循环结束。
注意，v.end() 返回的是一个指向向量末尾的“过去”的迭代器，所以在循环条件中我们使用 it != v.end() 而不是 it < v.end()。


此时我们也可以知道，vector的erase，insert函数的参数实际上都是迭代器类型。

注意：在使用迭代器迭代一个容器的过程中，使用修改容器内容的函数可能会使得迭代器无效，因此尽量不要在这个过程中修改容器内容。
*/
void S(vector<Student> &v)
{
    int *a = new int[v.size()];
    for (int i = 0; i < v.size(); i++)
    {
        a[i] = v[i].score;
    }
    sort(a, a + v.size(),greater<int>());
    vector<Student> temp;
    for (int i = 0; i < v.size(); i++)
    {
        for (int j = 0; j < v.size(); j++)
        {
            if (v[j].score == a[i])
            {
                temp.push_back(v[j]);
                break;
            }
        }
    }
    v = temp;
}
/*
std::sort函数的第三个参数是一个可选的比较函数，用于确定排序的顺序。这个比较函数应该接受两个参数（向量中的元素），并返回一个布尔值，表示第一个参数是否应该排在第二个参数之前。

例如，如果你有一个std::vector<int>，并且你想按照降序进行排序，你可以提供一个比较函数，该函数返回a > b：

std::vector<int> v = {1, 2, 3, 4, 5};
std::sort(v.begin(), v.end(), [](int a, int b) {
    return a > b;
});

在上面的代码中，比较函数是一个lambda表达式，它接受两个整数a和b，并返回a > b。这意味着，如果a大于b，a就会排在b之前，从而实现了降序排序。
同样，如果你有一个Student类型的向量，并且你想按照score的降序进行排序，你可以提供一个比较函数，该函数返回a.score > b.score：

std::vector<Student> v = {...};
std::sort(v.begin(), v.end(), [](const Student &a, const Student &b) {
    return a.score > b.score;
});

在上面的代码中，比较函数是一个lambda表达式，它接受两个Student对象a和b，并返回a.score > b.score。这意味着，如果a的score大于b的score，a就会排在b之前，从而实现了降序排序。

在C++中，lambda表达式是一种创建匿名函数对象的方式。它可以用于创建简洁的内联函数，或者在需要函数对象的地方，如STL算法。

lambda表达式的基本形式如下：

[capture](parameters) -> return_type { function_body }

- capture 是捕获列表。它定义了哪些外部变量可以在lambda表达式中使用，以及它们是如何捕获的（通过值或引用）。
- parameters 是参数列表。它定义了lambda函数的参数。
- return_type 是返回类型。它是可选的，如果省略，编译器会自动推断返回类型。
- function_body 是函数体。它定义了lambda函数的行为。

例如，以下是一个lambda表达式，它接受两个整数并返回它们的和：

auto add = [](int a, int b) { return a + b; };

你可以像调用普通函数一样调用lambda函数：

int sum = add(1, 2); // sum is 3
*//*
在C++中，你可以通过重载比较运算符来改变对象的排序行为，这样你就可以直接使用std::sort函数对Student对象进行排序，而不需要创建一个临时的分数数组。这种方法更简洁，也更符合C++的风格。

首先，你需要在Student类中重载<运算符。以下是一个示例：
class Student {
public:
    string name;
    int score;

    bool operator<(const Student& other) const {
        return score < other.score;
    }
};

在上面的代码中，我们重载了<运算符，使其比较两个Student对象的score。

然后，你可以直接使用std::sort函数对Student对象进行排序：
void S(vector<Student> &v)
{
    std::sort(v.begin(), v.end());
}

在上面的代码中，std::sort函数会使用我们重载的<运算符来比较Student对象。

注意，这会按照score的升序对v进行排序。如果你想按照score的降序排序，你可以改变<运算符的实现，或者提供一个自定义的比较函数给std::sort。例如：

void S(vector<Student> &v)
{
    std::sort(v.begin(), v.end(), [](const Student &a, const Student &b) {
        return a.score > b.score;
    });
}

在上面的代码中，我们提供了一个lambda表达式作为std::sort函数的比较函数，它接受两个Student对象，并返回一个布尔值，表示a的score是否大于b的score。这样，std::sort函数就会按照score的降序对v进行排序。
*/

int main()
{
    vector<Student> v;
    string x;
    while (cin >> x)
    {
        if (x == "A")
        {
            A(v);
        }
        else if (x == "P")
        {
            if(v.size() == 0)
            {
                cout << "[空]" << endl;
            }
            else
            {
                for (int i = 0; i < v.size(); i++)
                {
                    P(v[i]);
                }
            }
        }
        else if (x == "R")
        {
            string name;
            cin >> name;
            R(v, name);
        }
        else if (x == "S")
        {
            S(v);
        }
    }
}
