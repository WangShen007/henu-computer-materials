#include <iostream>
#include <vector>
#include <string>
#include <ctime>

using namespace std;

int main()
{
    string x[4] = {"Spades", "Hearts", "Clubs", "Diamonds"};
    string y[13] = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
    int times = 0;
    bool a = false;
    bool b = false;
    bool c = false;
    bool d = false;
    srand(time(0));
    vector<int> deck;
    while(a == false || b == false || c == false || d == false)
    {
        int i = rand() % 52;
        if(i % 4 == 1 && a == false)
        {
            a = true;
            deck.push_back(i);
        }
        else if(i % 4 == 2 && b == false)
        {
            b = true;
            deck.push_back(i);
        }
        else if(i % 4 == 3 && c == false)
        {
            c = true;
            deck.push_back(i);
        }
        else if(i % 4 == 0 && d == false)
        {
            d = true;
            deck.push_back(i);
        }
        times++;
    }
    cout << "Number of picks: " << times << endl;
    for(int i = 0; i < deck.size(); i++)
    {
        cout << y[deck[i] % 13] << " of " << x[deck[i] % 4] << endl;
    }
}