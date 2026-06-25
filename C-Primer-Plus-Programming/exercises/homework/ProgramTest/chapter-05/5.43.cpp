#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter the number of seconds: ";
    int numberOfSeconds;
    cin>>numberOfSeconds;

    for(int i = 1;i < numberOfSeconds;i++)
    {
        cout<<numberOfSeconds - i<<" seconds remaining"<<endl;
    }
    cout<<"Stopped"<<endl;
}
