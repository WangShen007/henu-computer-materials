#include <iostream>
#include <string>

using namespace std;
/*
Welcome to C++!
o
*/
int count(const string& s, char a)
{
    int pos = 0;
    int sum = 0;
    while((pos = s.find(a,pos)) != string::npos)
    {
        pos++;
        sum++;
    }
    return sum;
}

int main()
{
    cout<<"Enter a string: ";
    string s;
    getline(cin,s);
    cout<<"Enter a character: ";
    char a;
    cin>>a;
    cout<<a<<" appears in "<<s<<" "<<count(s,a)<<" times"<<endl;
}





/*
1.4查找目标字符串在字符串出现的总次数
核心代码：index=s.find(c,index)，index每次都会更新下一次找到的位置，如果没有找到跳出循环。

string s, c;

int main() {
  while (cin >> s >> c) {
    int index = 0;//用来存储不断更新最新找到的位置
    int sum = 0;//累加出现的次数
    while ((index = s.find(c,index)) != string::npos) {
      cout << "sum: " << sum+1 << " index: " << index <<endl;
      index += c.length();//上一次s中与c完全匹配的字符应跳过，不再比较
      sum++;
    }
    cout << sum << endl;
  }
}
1
2
3
4
5
6
7
8
9
10
11
12
13
14
llllll
ll
sum: 1 index: 0
sum: 2 index: 2
sum: 3 index: 4
3
*/
