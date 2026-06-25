#include <iostream>
//50 24.59 25 11.99
//50 25 25 12.5
using namespace std;

int main()
{
    cout << "Enter weight and price for package 1: ";
    double x1,y1;
    cin>>x1>>y1;

    cout << "Enter weight and price for package 2: ";
    double x2,y2;
    cin>>x2>>y2;

    double z1,z2;
    z1 = y1 / x1;
    z2 = y2 / x2;

    if(z1 == z2)
        cout<<"Two packages have the same price.";
    else if(z1 < z2)
        cout<<"Package 1 has a better price";
    else
        cout<<"Package 2 has a better price";
}
