#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    cout << "Enter the side: " ;
    double side;
    cin>>side;
    cout<<"The area of the hexagon is "<<3.0 * sqrt(3) * pow(side,2) / 2 ;
}
