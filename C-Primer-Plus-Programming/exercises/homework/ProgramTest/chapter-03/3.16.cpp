#include <iostream>

using namespace std;

int main()
{
    const double EPISON = 1e-16;
    cout<<"Please input three sides of the triangle: ";
    double a,b,c;
    cin>>a>>b>>c;
    if(a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0)
        cout<<a + b + c<<endl;
    else
        cout<<"Wrong"<<endl;
}
