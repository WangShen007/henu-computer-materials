#include <iostream>
#include <string>
#include <cctype>
using namespace std;
//Programming is fun
int main()
{
    cout<<"Enter a string: ";
    string x;
    getline(cin,x);

    int vowelsum = 0;
    int consonantsum = 0;
    for(int i = 0;i < x.length();i++)
    {
        if(isalpha(x.at(i)))//(x.at(i) >= 'A' && x.at(i) <= 'Z') || (x.at(i) >= 'a' && x.at(i) <= 'z')
        {
            if(x.at(i) == 'a' || x.at(i) == 'A' || x.at(i) == 'e' || x.at(i) == 'E' || x.at(i) == 'i' || x.at(i) == 'I' || x.at(i) == 'o' || x.at(i) == 'O' || x.at(i) == 'u' || x.at(i) == 'U')
        {
            vowelsum++;
        }
        else
        {
            consonantsum++;
        }
        }
    }
    cout<<"The number of vowels is "<<vowelsum<<endl;
    cout<<"The number of consonants is "<<consonantsum<<endl;
}
