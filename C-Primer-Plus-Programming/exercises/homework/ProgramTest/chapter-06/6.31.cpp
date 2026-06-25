#include <iostream>
#include <algorithm>
using namespace std;

void sortt(double& num1, double& num2, double& num3)
{
    double a[3] = {num1, num2, num3};
    sort(a,a + 3);
    num1 = a[0];
    num2 = a[1];
    num3 = a[2];
}

int main()
{
    cout<<"Enter three number: ";
    double a,b,c;
    cin>>a>>b>>c;
    sortt(a,b,c);
    cout<<a<<" "<<b<<" "<<c;
}
