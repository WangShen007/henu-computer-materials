#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

int main()
{
    srand(time(0));
    int lottery = rand() % 100;
    int lotteryDigit1 = lottery / 10;
    int lotteryDigit2 = lottery % 10;
    while(lotteryDigit1 == lotteryDigit2)
    {
        lottery = rand() % 100;
        lotteryDigit1 = lottery / 10;
        lotteryDigit2 = lottery % 10;
    }

    cout<<"Enter your lottery pick (two digits): ";
    int guess;
    cin>>guess;

    int guessDigit1 = guess / 10;
    int guessDigit2 = guess % 10;

    cout<<"The lottery number is "<<lottery<<endl;

    if (guess == lottery)
        cout<<"Exact match: you win $10,000"<<endl;
    else if (guessDigit2 == lotteryDigit1 && guessDigit1 == lotteryDigit2)
        cout<<"Match all digits: you win $3,000"<<endl;
    else if (guessDigit1 == lotteryDigit1 || guessDigit1 == lotteryDigit2 || guessDigit2 == lotteryDigit1 || guessDigit2 == lotteryDigit2)
        cout<<"Match one digit: you win $1,000"<<endl;
    else
        cout<<"Sorry, no match"<<endl;

    return 0;
}
