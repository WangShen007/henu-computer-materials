#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    cout<<left<<setw(12)<<"Kilograms"<<setw(12)<<"Pounds"<<endl;
    int kilograms = 0;
    const double POUNDS_PER_KILOGRAMS = 2.2;
    double pounds = kilograms * POUNDS_PER_KILOGRAMS;
    for(int i = 1; i < 201; i += 2)
    {
        kilograms = i;
        pounds = kilograms * POUNDS_PER_KILOGRAMS;
        cout<<left<<setw(12)<<kilograms<<setw(12)<<pounds<<endl;
    }
}
