/*
2024/5/15
15 - C++ 面向对象 - STL 的应用
本关任务：编写一个能根据键盘操作记录还原实际输入的小程序。

相关知识
本关涉及到的内容如下：

list容器的使用
list容器的使用
list位于头文件<list>，是 STL 提供的一种顺序存储的容器，它不支持通过位置索引访问，但能高效的进行插入、删除元素操作，通常由双向链表实现。

list是一个模板类，使用时需要指定模板参数，而且作为参数的类型需要有无参数的构造函数（如果不使用Allocator）。

它常用的构造函数如下：

list<int> l(); //无参构造函数
list<int> l2(10); //包含10个默认值0元素
list<int> l3(10,123); //包含10个123元素
它的begin，end函数用于获取指向第一个元素的迭代器和指向最后一个元素之后的迭代器。

如果要修改容器内容，可以使用以下函数：

list<int> l;
l.push_back(1); //添加到链尾
l.push_front(2); //添加到链头
l.pop_back(); //删除链尾元素
l.pop_front(); //删除链头元素
l.insert(l.begin(),3); //在指定迭代器之前添加一个元素
l.erase(l.begin()); //删除指定迭代器所指的元素
list的迭代器有一点特别，当对容器进行修改时，只要不是删除了这个迭代器对应的元素，这个迭代器都不会失效。
比如：

list<int> l;
list<int>::iterator it = l.begin();
l.insert(it,10); //执行之后it依然有效，并且现在it不再与l.begin()相等
l.erase(it-1); //执行之后it依然有效
l.erase(it); //现在it无效了
如果要查询list的元素数量，可以使用以下函数：

int size = l.size(); //返回元素个数
bool isem = l.empty(); //容器为空时返回true
list的成员函数不仅仅只有这些，感兴趣的同学可以查阅其他资料进行学习。

编程要求
学员需要读取输入的键盘操作记录，并根据操作记录还原最后的输入结果。

每一次的操作记录为一行字符串，字符串的内容分为以下几类：

大小写字母，数字：代表用户在输入光标左侧输入了一个具体字符，光标保持在新输入字符的Begin-End区域内。
<，>字符：代表用户按下了左键或者右键，作用是输入光标向左或者向右移动一个位置。
[，]字符：代表用户按下了Home键或者End键，作用是移动输入光标到最开始或者最末尾的位置。
每一次操作记录开始的时候都是没有输入的。

注意：输入光标只能在已输入内容的两端和内部移动。

输入将会有多行，每一行代表一次操作记录，每次操作记录产生一行结果，具体见测试说明。

测试说明
测试输入：
aa
a<b

预期输出：
aa
ba

测试输入：
a<ba[c
aa<<b]c

预期输出：
cbaa
baac


*/


#include <iostream>
#include <string>
#include <list>
#include <cctype>
using namespace std;



int main()
{
    string s;
    while(cin>>s)
    {
        list<char> l;
        list<char>::iterator it = l.begin();

        for(int i=0;i<s.size();i++)
        {
            if(isalpha(s[i])||isdigit(s[i]))
            {
                l.insert(it,s[i]);
            }
            else if(s[i]=='<')
            {
                if(it!=l.begin())
                {
                    it--;
                }
            }
            else if(s[i]=='>')
            {
                if(it!=l.end())
                {
                    it++;
                }
            }
            else if(s[i]=='[')
            {
                it = l.begin();
            }
            else if(s[i]==']')
            {
                it = l.end();
            }
        }
        cout<<string(l.begin(),l.end())<<endl;
        l.clear();
    }
}

/*
Sonder9999: list<int> l;
list<int>::iterator it = l.begin();
l.insert(it,10); //执行之后it依然有效，并且现在it不再与l.begin()相等
l.erase(it-1); //执行之后it依然有效
l.erase(it); //现在it无效了

GitHub Copilot: 你的代码片段展示了如何在 C++ 的 `std::list` 中插入和删除元素。这里有一些关于你代码的解释：

list<int> l; // 创建一个空的整数列表
list<int>::iterator it = l.begin(); // 获取列表的开始迭代器
l.insert(it,10); // 在列表开始位置插入一个整数10
```
在这里，`it` 还是有效的，但是它不再指向列表的开始位置，因为我们在它前面插入了一个元素。

```cpp
l.erase(it-1); // 删除迭代器指向的前一个元素
```
这里有一个问题，`std::list` 的迭代器不支持算术运算（如 `it-1`）。如果你想删除 `it` 前面的元素，你需要先将迭代器向前移动，然后再删除。

```cpp
l.erase(it); // 删除迭代器指向的元素
```
在这里，`it` 变得无效，因为我们删除了它指向的元素。在使用已经删除的迭代器之前，你需要重新获取有效的迭代器。

Sonder9999: 如何在 C++ 的 std::list 中删除指定值的元素？

GitHub Copilot: 在 C++ 的 `std::list` 中删除指定值的元素，你可以使用 `std::list::remove` 成员函数。这个函数会删除列表中所有等于指定值的元素。例如，如果你想删除所有值为 'a' 的元素，你可以这样做：

```cpp
list<char> l;
// 假设 l 已经被填充了一些元素
l.remove('a'); // 删除所有值为 'a' 的元素
```

如果你想在列表中删除满足特定条件的元素，你可以使用 `std::list::remove_if` 成员函数。例如，如果你想删除所有小写字母，你可以这样做：

```cpp
list<char> l;
// 假设 l 已经被填充了一些元素
l.remove_if([](char c) { return islower(c); }); // 删除所有小写字母
```

Sonder9999: @workspace /explain 缺少 类模板 "std::__cxx11::list" 的参数列表, 应输入“;”, 未定义标识符 "it", 未定义标识符 "it", 未定义标识符 "it", 未定义标识符 "it", 未定义标识符 "it"

GitHub Copilot: 这个错误是因为在创建 [`std::list`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22external%22%3A%22file%3A%2F%2F%2Fc%253A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%252B%252B%2Farray%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%2B%2B%2Farray%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A42%2C%22character%22%3A10%7D%5D "c:/Users/27341/AppData/Local/Programs/mingw64/lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/array") 的迭代器时，没有指定 [`std::list`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22external%22%3A%22file%3A%2F%2F%2Fc%253A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%252B%252B%2Farray%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%2B%2B%2Farray%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A42%2C%22character%22%3A10%7D%5D "c:/Users/27341/AppData/Local/Programs/mingw64/lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/array") 的类型。在你的代码中，你创建了一个 [`std::list<char>`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22external%22%3A%22file%3A%2F%2F%2Fc%253A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%252B%252B%2Farray%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%2B%2B%2Farray%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A42%2C%22character%22%3A10%7D%5D "c:/Users/27341/AppData/Local/Programs/mingw64/lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/array")，所以迭代器也应该是 [`std::list<char>::iterator`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22external%22%3A%22file%3A%2F%2F%2Fc%253A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%252B%252B%2Farray%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2F27341%2FAppData%2FLocal%2FPrograms%2Fmingw64%2Flib%2Fgcc%2Fx86_64-w64-mingw32%2F8.1.0%2Finclude%2Fc%2B%2B%2Farray%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A42%2C%22character%22%3A10%7D%5D "c:/Users/27341/AppData/Local/Programs/mingw64/lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/array") 类型。以下是修正后的代码：

```cpp
int main()
{
    list<char> l;
    list<char>::iterator it = l.begin(); // 修改这里
    string s;
    while(cin>>s)
    {
        for(int i=0;i<s.size();i++)
        {
            if(isalpha(s[i])||isdigit(s[i]))
            {
                l.insert(it,s[i]);
            }
            else if(s[i]=='<')
            {
                if(it!=l.begin())
                {
                    it--;
                }
            }
            else if(s[i]=='>')
            {
                if(it!=l.end())
                {
                    it++;
                }
            }
            else if(s[i]=='[')
            {
                it = l.begin();
            }
            else if(s[i]==']')
            {
                it = l.end();
            }
        }
        cout<<string(l.begin(),l.end())<<endl;
    }
}
```

这样就可以解决你的问题了。

*/