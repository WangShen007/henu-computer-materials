#include <iostream>

using namespace std;
//1 2 3 4 5 6 7 8 9 10
int main()
{
    int len = 10;
    int num[len];
    for(int i = 0;i < len;i++)
    {
        cin>>num[i];
    }
    for(int i = 9;i >= 0;i--)
    {
        cout<<num[i]<<" ";
    }
}
