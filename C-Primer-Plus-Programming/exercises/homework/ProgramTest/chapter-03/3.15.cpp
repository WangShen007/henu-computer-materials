#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    int answer = rand() % 3;
    string answername,guessname;

    cout<<"scissor (0), rock (1), paper (2): ";
    int guess;
    cin>>guess;


    switch(answer)
    {
        case 0 :
            answername = "scissor";
            break;
        case 1 :
            answername = "rock";
            break;
        case 2 :
            answername = "paper";
            break;
    }
    cout<<"The computer is "<<answername<<". ";


    switch(guess)
    {
        case 0 :
            guessname = "scissor";
            break;
        case 1 :
            guessname = "rock";
            break;
        case 2 :
            guessname = "paper";
            break;
    }

    if(guess == answer)
        cout<<"You are "<<answername<<" too. It is a draw";
    else if ((answer == 0 && guess == 1) ||
             (answer == 1 && guess == 2) ||
             (answer == 2 && guess == 0))
        cout<<"You are "<<guessname<<". You won";
    else
        cout<<"You are "<<guessname<<". You lose";
}
