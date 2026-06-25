#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    int line,color;
    string linename[13]={"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
    string colorname[4]={"Clubs","Diamonds","Heart","Spades"};
    line = rand() % 13;
    color = rand() % 4;
    cout<<"The card you picked is "<<linename[line]<<" of "<<colorname[color];
}
