#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    for(int i = 1;i <= 8;i++)
    {
        for(int j = 0; j < 4 * (8 - i);j++)
        {
            cout<<" ";
        }

        for(int j = 0;j < i;j++)
        {
            cout<<setw(4)<<pow(2,j);
        }

        for(int j = i - 1;j > 0;j--)
        {
            cout<<setw(4)<<pow(2,j - 1);
        }

        for(int j = 0; j < 4 * (8 - i);j++)
        {
            cout<<" ";
        }

        cout<<endl;

    }
}
