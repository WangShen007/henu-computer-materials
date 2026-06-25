#include <iostream>
#include <cmath>
using namespace std;
//1 2 3 4.5 5.6 6 7 8 9 10
int main()
{
    double a[10];
    double sum = 0;
    cout<<"Enter ten numbers: ";
    for(int i = 0;i < 10;i++)
    {
        cin>>a[i];
        sum += a[i];
    }
    cout<<"The mean is "<<sum / 10.0<<endl;

    double sumx2 = 0;
    for(int i = 0;i < 10;i++)
    {
        sumx2 += pow(a[i],2);
    }

    cout<<"The standard deviation is "<<sqrt((sumx2 - (pow(sum,2) / 10.0)) / (10.0 - 1.0))<<endl;
}
