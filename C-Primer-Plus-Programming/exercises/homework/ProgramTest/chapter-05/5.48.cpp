#include <iostream>
#include <string>
#include <cctype>
using namespace std;
//Programming Is Fun;
int main()
{
    string x;
    cout<<"Enter a string: ";
    getline(cin,x);
    int y = x.size();
    int sum = 0;
    for(int i = 0;i < y;i++)
    {
        if(isupper(x.at(i)))
        {
            sum++;
        }
    }
    cout<<"The number of uppercase letters is "<<sum<<endl;
}
