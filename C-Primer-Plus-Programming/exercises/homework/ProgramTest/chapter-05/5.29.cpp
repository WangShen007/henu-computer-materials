#include <iostream>

using namespace std;

int main()
{
    int sum = 0;
    for(int i = 2001;i <= 2100;i++)
    {
        if((i % 4 == 0 && i % 100 != 0)||(i % 400 == 0))
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
    cout<<endl;
}
