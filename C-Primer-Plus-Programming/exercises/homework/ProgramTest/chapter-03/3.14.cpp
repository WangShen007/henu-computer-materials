#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

int main()
{
    srand(time(0));
    int lottery = rand() % 1000;

    cout<<"Enter your lottery pick (two digits): ";
    int guess;
    cin>>guess;

    int lotteryDigit1 = lottery / 100;
    int temp1 = lottery % 100;
    int lotteryDigit2 = lottery / 10;
    int lotteryDigit3 = lottery % 10;

    int guessDigit1 = guess / 100;
    int temp2 = guess % 100;
    int guessDigit2 = guess / 10;
    int guessDigit3 = guess % 10;

    cout<<"The lottery number is "<<lottery<<endl;

    if (guess == lottery)
        cout<<"Exact match: you win $10,000"<<endl;
    else if ((guessDigit2 == lotteryDigit1 && guessDigit1 == lotteryDigit2 && guessDigit3 == lotteryDigit3) || //213
             (guessDigit2 == lotteryDigit1 && guessDigit3 == lotteryDigit2 && guessDigit1 == lotteryDigit3) || //231
             (guessDigit3 == lotteryDigit1 && guessDigit2 == lotteryDigit2 && guessDigit1 == lotteryDigit3) || //321
             (guessDigit3 == lotteryDigit1 && guessDigit1 == lotteryDigit2 && guessDigit2 == lotteryDigit3) || //312
             (guessDigit1 == lotteryDigit1 && guessDigit3 == lotteryDigit2 && guessDigit2 == lotteryDigit3)  ) //132
        cout<<"Match all digits: you win $3,000"<<endl;
    else if ((guessDigit1 == lotteryDigit1 && guessDigit3 == lotteryDigit2 && guessDigit2 == lotteryDigit3) || //132
             (guessDigit3 == lotteryDigit1 && guessDigit2 == lotteryDigit2 && guessDigit1 == lotteryDigit3) || //321
             (guessDigit2 == lotteryDigit1 && guessDigit1 == lotteryDigit2 && guessDigit3 == lotteryDigit3)  ) //213
        cout<<"Match one digit: you win $1,000"<<endl;
    else
        cout<<"Sorry, no match or match 2"<<endl;

    return 0;
}
