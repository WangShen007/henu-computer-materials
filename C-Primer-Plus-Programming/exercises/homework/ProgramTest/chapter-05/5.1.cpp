#include <iostream>

using namespace std;
/*
1 2 -1 3 0
*/
int main()
{
    cout<<"Enter an integer, the input ends if it is 0: ";
    int a[100];
    int sum1 = 0,sum2 = 0,sum = 0;
    double x = 0;
    for(int i = 0;i < 100;i++)
    {
        cin>>a[i];
        sum++;
        if(a[i] == 0)
            break;
        if(a[i] > 0)
            sum1++;
        if(a[i] < 0)
            sum2++;
        x += a[i];
    }

    if(sum == 0)
        cout<<"No numbers are entered expect 0";
    else
    {
        cout<<"The number of positives is "<<sum1<<endl;

        cout<<"The number of negatives is "<<sum2<<endl;

        cout<<"The total is "<<sum<<endl;

        cout<<"The average is "<<x / sum<<endl;
    }
}
