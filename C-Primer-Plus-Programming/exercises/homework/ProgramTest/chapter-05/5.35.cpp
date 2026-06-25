#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    for(int x = 2; x <= 10000;x++)
    {
        int y = x;
        int sum = 1;
        for(int i = 2; i < y; i++)
        {
            if(y % i == 0)
            {
                sum += i;
            }
        }

        if(sum == x)
        {
            cout<<x<<endl;
        }
    }
}



/*
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

*/
