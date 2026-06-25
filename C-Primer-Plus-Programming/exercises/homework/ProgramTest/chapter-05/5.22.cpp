#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int sum = 0;
    for(int i = 2;i <= 1000;i++)
    {
        bool isPrime = true;
        for(int x = 2;x < sqrt(i);x++)
        {
            if(i % x == 0)
            {
                isPrime = false;
            }
        }

        if(isPrime)
        {
            cout<<i<<" ";
            sum++;
        }

        if(sum == 8)
        {
            cout<<endl;
            sum = 0;
        }
    }
}
