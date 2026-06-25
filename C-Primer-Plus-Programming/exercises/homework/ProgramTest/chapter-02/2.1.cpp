#include <iostream>

using namespace std;

int main()
{
   cout<<"Enter a degree in Celsius: ";
   double c;
   cin>>c;
   double f;
   f = (9.0 / 5) * c + 32;
   cout<<c<<" Celsius is "<<f<<" Fahrenheit";
}
