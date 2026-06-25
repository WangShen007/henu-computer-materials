#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    int sum1 = 0,sum2 = 0;
    for(int i = 0;i < 1000000;i++)
    {
        int sum = rand() % 2;
        if(sum == 0)
        {
            sum1++;
        }
        else
        {
            sum2++;
        }
    }
    cout<<"The right side: "<<sum1<<endl;
    cout<<"The reverse side: "<<sum2<<endl;
}
