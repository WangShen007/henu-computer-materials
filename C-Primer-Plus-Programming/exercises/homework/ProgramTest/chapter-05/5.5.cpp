#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    cout<<left<<setw(12)<<"Kilograms"<<setw(12)<<"Pounds"<<"|        "<<setw(12)<<"Pounds"<<setw(12)<<"Kilograms"<<endl;
    int kilograms = 0;
    const double POUNDS_PER_KILOGRAMS = 2.2;
    int pounds2 = 15;
//    double pounds = kilograms * POUNDS_PER_KILOGRAMS;
    for(int i = 1; i < 201; i += 2)
    {
        kilograms = i;
        double pounds = kilograms * POUNDS_PER_KILOGRAMS;
        pounds2 += 5;
        double kilograms2 = pounds2 / POUNDS_PER_KILOGRAMS;
        cout<<left<<setw(12)<<kilograms<<fixed<<setprecision(1)<<setw(12)<<pounds
        <<"|        "<<setw(12)<<pounds2<<setw(12)<<fixed<<setprecision(2)<<kilograms2<<endl;
    }
}


















/*
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

*/

/*
#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    cout<<left<<setw(12)<<"Miles"<<setw(12)<<"Kilometers"<<endl;
//    int miles = 0;
    const double KILOMETERS_PER_MILES = 1.609;
//    double kilometers = miles * KILOMETERS_PER_MILES;
    for(int i = 1; i < 11; i += 1)
    {
        int miles = i;
        double kilometers = miles * KILOMETERS_PER_MILES;
        cout<<left<<setw(12)<<miles<<setw(12)<<kilometers<<endl;
    }
}

*/
