#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    cout<<left<<setw(12)<<"Miles"<<setw(12)<<"Kilometers"<<"|    "<<setw(12)<<"Kilometers"<<setw(12)<<"Miles"<<endl;
//    int miles = 0;
    const double KILOMETERS_PER_MILES = 1.609;
    int kilometerskilometers = 15;
//    double kilometers = miles * KILOMETERS_PER_MILES;
    for(int i = 1; i < 11; i += 1)
    {
        int miles = i;
        kilometerskilometers += 5;
        double milesmiles = kilometerskilometers / KILOMETERS_PER_MILES;
        double kilometers = miles * KILOMETERS_PER_MILES;
        cout<<left<<setw(12)<<miles<<setw(12)<<fixed<<setprecision(3)<<kilometers<<"|    "<<setw(12)<<kilometerskilometers<<setw(12)<<milesmiles<<endl;
    }
}
