#include <iostream>
#include <iomanip>
using namespace std;
double celsiusToFahrenheit(double celisus)
{
    double fahrenheit = celisus * (9.0 / 5) + 32;
    return fahrenheit;
}

double fahrenheitToCelsius(double fahrenheit)
{
    double celisus = (fahrenheit - 32) * (5.0 / 9);
    return celisus;
}

int main()
{
    cout<<left<<setw(10)<<"Celsius"<<setw(10)<<"Fahrenheit"<<"|"<<"     "<<setw(10)<<"Fahrenheit"<<setw(10)<<"Celsius"<<endl;
    for(int i = 0;i < 10;i++)
    {
        double aCelsius = 40.0 - 1.0 * i;
        double bFahrenheit = 120.0 - 10.0 * i;
        cout<<fixed<<setprecision(1)<<setw(10)<<aCelsius<<setw(10)<<fixed<<setprecision(1)<<celsiusToFahrenheit(aCelsius)<<"|"<<"     "<<setw(10)<<fixed<<setprecision(1)<<bFahrenheit<<setw(10)<<fixed<<setprecision(2)<<fahrenheitToCelsius(bFahrenheit)<<endl;
    }
}







/*
#include <iostream>
#include <iomanip>
using namespace std;
double footToMeter(double foot)
{
    double meter = foot * 0.305;
    return meter;
}

double meterToFoot(double meter)
{
    double foot = meter / 0.305;
    return foot;
}

int main()
{
    cout<<left<<setw(10)<<"Feet"<<setw(10)<<"Meters"<<"|"<<"     "<<setw(10)<<"Meters"<<setw(10)<<"Feet"<<endl;
    for(int i = 0;i < 10;i++)
    {
        double aFeet = i + 1.0;
        double bMeters = 5.0 * i + 20.0;
        cout<<fixed<<setprecision(1)<<setw(10)<<aFeet<<setw(10)<<fixed<<setprecision(3)<<footToMeter(aFeet)<<"|"<<"     "<<setw(10)<<fixed<<setprecision(1)<<bMeters<<setw(10)<<fixed<<setprecision(3)<<meterToFoot(bMeters)<<endl;
    }
}
*/
