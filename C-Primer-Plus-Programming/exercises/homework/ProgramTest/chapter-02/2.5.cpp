#include <iostream>

using namespace std;

int main()
{
    cout << "Enter the subtotal and a gratuity rate: ";
    double money,rate;
    cin>>money>>rate;
    cout<<"The gratuity is $"<<money * rate / 100.0<<" and total is $"<<money * rate / 100.0 + money;
}
