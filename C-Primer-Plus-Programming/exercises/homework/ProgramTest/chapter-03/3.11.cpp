#include <iostream>

using namespace std;

int main()
{
    double w,money;
    cin>>w;
    if(w > 0 && w<=1)
    {
        money = 3.5;
        cout<<money;
    }
    else if(w > 1 && w <= 3)
    {
        money = 5.5;
        cout<<money;
    }
    else if(w>3&&w<=10)
    {
        money = 8.5;
        cout<<money;
    }
    else if(w>10&&w<=20)
    {
        money = 10.5;
        cout<<money;
    }
    else if(w > 50)
        cout<<"the package cannot be shipped";
}
