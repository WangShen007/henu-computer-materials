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
