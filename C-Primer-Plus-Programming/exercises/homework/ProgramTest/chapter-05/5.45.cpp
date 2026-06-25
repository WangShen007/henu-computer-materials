#include <iostream>

using namespace std;

int main()
{
    int sum = 0;
    for(int i = 1;i <= 7;i++)
    {
        for(int j = i + 1;j <= 7;j++)
        {
            int x = i * 10 + j;
            sum++;
            cout<<i<<" "<<j<<endl;
        }
    }
    cout<<"The total number of all combinations is "<<sum<<endl;
}
