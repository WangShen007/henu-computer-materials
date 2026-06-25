#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    cout << "Enter the amount of water in kilograms: " ;
    double M;
    cin>>M;
    cout<<"Enter the initial temperature: ";
    double initialtemperature;
    cin>>initialtemperature;
    cout<<"Enter the final temperature: ";
    double finaltemperature;
    cin>>finaltemperature;
    double Q = M * (finaltemperature - initialtemperature) * 4184;
    //cout.setf(ios::fixed,ios::floatfield);
    cout<<fixed<<setprecision(1)<<"The energy needed is "<<Q<<endl;
    return 0;
}
