#include <iostream>

using namespace std;

int main()
{
    cout<<"Pattern A"<<endl;
    for(int i = 0;i < 6;i++)
    {
        for(int j = 1;j <= i + 1;j++)
        {
            cout<<j<<" ";
        }
        cout<<endl;
    }

    cout<<endl;

    cout<<"Pattern B"<<endl;
    for(int i = 0;i < 6;i++)
    {
        for(int j = 6;j >= i + 1;j--)
        {
            cout<<7 - j<<" ";
        }
        cout<<endl;
    }

    cout<<endl;

    cout<<"Pattern C"<<endl;
    for(int i = 0;i < 6;i++)
    {
        for(int j = i + 1;j > 0;j--)
        {
            cout<<j<<" ";
        }
        cout<<endl;
    }

    cout<<endl;

    cout<<"Pattern D"<<endl;
    for(int i = 0;i < 6;i++)
    {
        for(int j = 6 - i;j > 0;j--)
        {
            cout<<j<<" ";
        }
        cout<<endl;
    }
}
