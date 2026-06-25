#include <iostream>

using namespace std;

int main()
{
    cout << "Enter an integer: " ;
    int x;
    cin>>x;

    int y = x;
    for(int i = 2;i <= y;i++)
    {
        while(y % i == 0)
        {
            cout<<i<<" ";
            y = y / i;
        }
    }
}
