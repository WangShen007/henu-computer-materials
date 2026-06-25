#include <iostream>

using namespace std;

int getPentagonalNumber( int n )
{
    cout<<n * (3 * n - 1) / 2.0;
    //return n * (2 * n - 1) / 2;
}

int main()
{
    int sum = 0;
    for(int i = 1;i <=100;i++)
    {
        getPentagonalNumber(i);
        cout<<" ";
        sum++;
        if(sum == 10)
        {
            cout<<endl;
            sum = 0;
        }
    }
    return 0;
}
