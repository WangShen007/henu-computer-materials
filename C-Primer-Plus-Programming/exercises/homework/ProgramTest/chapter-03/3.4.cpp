#include <iostream>

using namespace std;

int main()
{
    cout << "Enter the temperature: ";
    double temperature;
    cin>>temperature;
    if(temperature < 30)
        cout<<"too cold";
    else if(temperature > 100)
        cout<<"too hot";
    else
        cout<<"just right";
}
