#include <iostream>
#include <algorithm>
using namespace std;
//3 5 2 5 5 5 0
int main()
{
    cout<<"Enter numbers: ";
    int a[100];
    int sum = 0;
    for(int i = 0;i < 100;i++)
    {
        cin>>a[i];
        if(a[i] == 0)
        {
            break;
        }
        sum++;
    }

    sort(a,a + sum,greater<int>());
    cout<<"The largest number is "<<a[0]<<endl;

    int sum2 = 0;
    for(int i = 0;i < sum;i++)
    {
        if(a[i] == a[0])
        {
            sum2++;
        }
//        else
//        {
//            break;
//        }
    }
    cout<<"The occurrence count of the largest number is "<<sum2<<endl;
}

