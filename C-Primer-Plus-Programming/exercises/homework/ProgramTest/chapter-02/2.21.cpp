#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    cout << "Enter the driving distance: " ;
    double distance,milesPerGallon,pricePerGallon;
    cin>>distance;
    cout<<"Enter miles per gallon: ";
    cin>>milesPerGallon;
    cout<<"Enter price per gallon: ";
    cin>>pricePerGallon;
    double cost = distance / milesPerGallon * pricePerGallon;
    cost = floor(cost * 100.0) / 100.0;
    cout<<"The cost of driving is $"<<cost<<endl;
    return 0;
}
