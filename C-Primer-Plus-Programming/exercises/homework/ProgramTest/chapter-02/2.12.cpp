#include <iostream>

using namespace std;

int main()
{
    cout << "Enter speed and acceleration: " ;
    double v,a;
    cin>>v>>a;
    cout<<"The minimum runway length for this airplane is "<<v * v / (2 * a)<<endl;
    return 0;
}
