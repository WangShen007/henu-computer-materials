#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    int number1 = rand() % 100;
    int number2 = rand() % 100;

    if(number1 < number2)
    {
        int temp = number1;
        number1 = number2;
        number2 = temp;
    }

    cout<<"What is "<<number1<<" - "<<number2<<"? ";
    int answer;
    cin>>answer;

    if(number1 - number2 == answer)
        cout<<"You are correct!";
    else
        cout<<"Your answer is wrong. "<<number1<<" - "<<number2<<" should be "<<(number1 - number2)<<endl;

    return 0;
}
