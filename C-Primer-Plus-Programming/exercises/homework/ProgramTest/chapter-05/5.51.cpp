#include <iostream>
#include <string>
#include <cctype>
using namespace std;
/*
978013213080
978013213079
97801320
*/
int main()
{
    cout<<"Enter the first 12 digits of an ISBN-13 as a string: ";
    string isbn12;
    cin>>isbn12;
    bool isisbn = true;
    for(int i = 0;i <12;i++)
    {
        if(!isdigit(isbn12.at(i)) || isbn12.size() != 12)
        {
            isisbn = false;
            break;
        }
    }
    if(isisbn)
    {
        int sum = 0;
        for(int i = 0;i < 12;i++)
        {
            int d = isbn12.at(i) - '0';
            if(i % 2 == 0)
            {
                sum += 1 * d;
            }
            else
            {
                sum += 3 * d;
            }
        }
        int d13 = 10 - sum % 10;
        if(d13 == 10)
        {
            d13 = 0;
        }
        cout<<"The ISBN-13 number is "<<isbn12<<d13<<endl;
    }

    else
    {
        cout<<isbn12<<" is an invalid input"<<endl;
    }
}
