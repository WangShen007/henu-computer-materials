#include <iostream>

using namespace std;

int main()
{
    int sum = 0;
    for(int i = 100;i <= 200;i++)
    {
        if((i % 5 == 0 || i % 6 ==0) && !(i % 5 == 0 && i % 6 ==0))
        {
            cout<<i<<" ";
            sum++;
        }

        if(sum == 10)
        {
            cout<<endl;
            sum = 0;
        }
    }
}
