#include <iostream>

using namespace std;

int main()
{
    cout << "Enter the numbers of minutes: " ;
    int minutes;
    cin>>minutes;
    cout<<minutes<<" is approximately "<<minutes / (365 * 24 * 60)<<" years and "<<(minutes % (365 * 24 * 60)) / (24 * 60)<<" days";
}
