#include <iostream>
#include <fstream>

using namespace std;

void test01()
{
    ofstream output("Exercise13_2.txt");
    char x[27] = "abcdefghijklmnopqrstuvwxyz";
    for (int i = 0; i < 26; i++)
    {
        output << x[i] << " ";
    }
    output.close();
}

int test02()
{
    ifstream input("Exercise13_2.txt");
    int sum = 0;
    char ch;
    while(input>>ch)
    {
        cout<<ch<<" ";
        sum++;
    }
    input.close();
    return sum;
}

int main()
{
    test01();
    cout<<test02()<<endl;
    return 0;
}