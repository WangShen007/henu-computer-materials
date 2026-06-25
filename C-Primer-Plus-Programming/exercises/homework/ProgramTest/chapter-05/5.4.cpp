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
