#include <iostream>

using namespace std;

int main()
{
    cout << "Enter balance and interest rate (e.g., 3 for 3%): ";
    double balance,rate,interest;
    cin>>balance>>rate;
    cout<<"The interest is "<<balance * (rate / 1200.0);
    return 0;
}
