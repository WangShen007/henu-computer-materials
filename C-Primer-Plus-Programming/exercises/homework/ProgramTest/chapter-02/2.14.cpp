#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout << "Enter weight in pounds: " ;
    double m,l;
    cin>>m;
    cout<<"Enter height in inches: ";
    cin>>l;
    double BMI;
    BMI = m * 0.45359237 / pow((l * 0.0254),2);
    cout<<"BMI is "<<BMI;
    return 0;
}
