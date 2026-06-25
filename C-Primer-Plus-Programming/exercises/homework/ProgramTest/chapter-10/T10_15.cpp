#include <iostream>
#include <ctime>
using namespace std;

string words[] = {"elysia", "kisara"};

void deleteWord(string words[], int index,int y)
{
    string s[y-1];
    for(int i = 0;i < y;i++)
    {
        if(i < index)
        {
            s[i] = words[i];
        }
        else if(i > index)
        {
            s[i-1] = words[i];
        }
    }
    for(int i = 0;i < y-1;i++)
    {
        words[i] = s[i];
    }
    words[y-1] = "";
}


class GuessWords
{
private:
    string word;
    int length;
    string guessed;
    int WrongTimes = 0;
public:
    GuessWords()
    {
        WrongTimes = 0;
        int x = rand() % (sizeof(words) / sizeof(words[0]));
        word = words[x];
        int y = sizeof(words) / sizeof(words[0]);
        deleteWord(words,x,y);
        length = word.length();
        for(int i = 0;i < length;i++)
        {
            guessed += "*";
        }
    }
    
    void guess(char c)
    {
        if(word.find(c) == string::npos)
        {
            cout << c << " is not in the word" << endl;
            WrongTimes++;
        }
        if(guessed.find(c) != string::npos)
        {
            cout << c << " is already in the word" << endl;
        }
        for(int i = 0;i < length;i++)
        {
            if(word[i] == c)
            {
                guessed[i] = c;
            }
        }
    }
    
    string getWord()
    {
        return word;
    }

    string getGuessed()
    {
        return guessed;
    }

    int getWrongTimes()
    {
        return WrongTimes;
    }

    void setWrongTimes(int WrongTimes)
    {
        this->WrongTimes = WrongTimes;
    }

};

/*void guessguess()
{
    GuessWords game;
    while(game.getGuessed().find('*') != string::npos)
    {
        char c;
        cout << "(Guess) Enter a letter in word " << game.getGuessed() << " > ";
        cin >> c;
        game.guess(c);
    }
    cout<<"The word is "<<game.getWord()<<". You missed "<<game.getWrongTimes();
    cout<<(game.getWrongTimes() > 1) ? " times" : " time";
    cout<<endl;
    cout<<endl;

    cout<<"Do you want to guess another word? Enter y or n > ";
}*/

void playGame() {
    GuessWords game;
    if(game.getWord() == "")
    {
        cout<<"No words to guess! Program terminated!"<<endl;
        exit(0);
    }
    else
    {
        while(game.getGuessed().find('*') != string::npos) {
        char c;
        cout << "(Guess) Enter a letter in word " << game.getGuessed() << " > ";
        cin >> c;
        game.guess(c);
    }
    cout << "The word is " << game.getWord() << ". You missed " << game.getWrongTimes();
    cout << ((game.getWrongTimes() > 1) ? " times" : " time");
    cout << endl << endl;

    /*if(sizeof(words) / sizeof(words[0]) == 0) {
        cout << "No more words to guess!" << endl;
        cout << "Do you want to guess another word? Enter y or n > ";
        return;
    }*/

    cout << "Do you want to guess another word? Enter y or n > ";
    }
}

int main()
{
    srand(time(0));
    /*GuessWords game;
    //string gue = game.getGuessed();
    //cout<<gue<<endl;
    while(game.getGuessed().find('*') != string::npos)
    {
        char c;
        cout << "(Guess) Enter a letter in word " << game.getGuessed() << " > ";
        cin >> c;
        game.guess(c);
    }
    cout<<"The word is "<<game.getWord()<<". You missed "<<game.getWrongTimes();
    cout<<((game.getWrongTimes() > 1) ? " times" : " time");
    cout<<endl;
    //cout<<endl;
    //guessguess();
    cout<<"Do you want to guess another word? Enter y or n > ";*/
    /*playGame();
    char c;
    cin>>c;*/
    char c;
    do{
        playGame();
        cin >> c;
    }while(c == 'y');
    return 0;

    /*if(c == 'y')
    {
    GuessWords game;
    while(game.getGuessed().find('*') != string::npos)
    {
        char c;
        cout << "(Guess) Enter a letter in word " << game.getGuessed() << " > ";
        cin >> c;
        game.guess(c);
    }
    cout<<"The word is "<<game.getWord()<<". You missed "<<game.getWrongTimes();
    cout<<(game.getWrongTimes() > 1) ? " times" : " time";
    cout<<endl;
    cout<<endl;

    cout<<"Do you want to guess another word? Enter y or n > ";
    }
    else
    {
        cout<<"Goodbye!";
    }*/


}