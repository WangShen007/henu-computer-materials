#include <iostream>
#include <cstdlib>
#include <string>
//4388576018410707
using namespace std;

bool isvalid(const string& cardNumber);
int sumOfDoubleEvenPlace(const string& cardNumber);
int getDigit(int number);
int sumOfOddPlaces(const string& cardNumber);
bool startsWith(const string& cardNumber, const string& substr);

int main()
{
    cout<<"Enter the card number: ";
    string cardnumber;
    cin>>cardnumber;
    if(isvalid(cardnumber))
    {
        cout<<"Yes"<<endl;
    }
    else
    {
        cout<<"No"<<endl;
    }
    return 0;
}

bool isvalid(const string& cardnumber)
{
    if(startsWith(cardnumber, cardnumber.substr(0, 2)))
    {
        if(cardnumber.length() >= 13 && cardnumber.length() <= 16)
        {
            return true;
        }
    }
    return false;
}

int sumOfDoubleEvenPlace(const string& cardNumber)//even place is %2
{
    int length = cardNumber.length();
    int sum = 0;

    //char oddplace[(length + 1) / 2];
    char evenplace[(length + 1) / 2];
    int place = 1;
    for(int i = 0; i < (length + 1) / 2; i++)//length + 1 能有效避免奇数的问题，因为直接使用length的话，例如13 / 2 = 6，会导致奇数少一位，而且+1的话偶数并不会溢出
    {
        evenplace[i] = cardNumber.at(place);
        place += 2;
    }
    int evennumber = atoi(evenplace);
    for(int i = 0; i < (length + 1)  / 2; i++)
    {
//        sum += evennumber % 10;
        int numnum = evennumber % 10;

        numnum = getDigit(numnum * 2);
        sum += numnum;
    }
    return sum;
}

int getDigit(int number)
{
    if(number > 10)
    {
        number = number % 10 + number / 10;
    }
    return number;
}

int sumOfOddPlaces(const string& cardNumber)//1 3 5 7
{
    int length = cardNumber.length();
    int sum = 0;

    //char oddplace[(length + 1) / 2];
    char oddplace[(length + 1) / 2];
    int place = 0;
    for(int i = 0; i < (length + 1) / 2; i++)//length + 1 能有效避免奇数的问题，因为直接使用length的话，例如13 / 2 = 6，会导致奇数少一位，而且+1的话偶数并不会溢出
    {
        oddplace[i] = cardNumber.at(place);
        place += 2;
    }
    int oddnumber = atoi(oddplace);
    for(int i = 0; i < (length + 1)  / 2; i++)
    {
        sum += oddnumber % 10;
    }
    return sum;
}

bool startsWith(const string& cardNumber, const string& substr)
{
    if(substr.at(0) == '4' || substr.at(0) == '5' || substr.at(0) == 6)
    {
        return true;
    }
    else if(substr.at(0) == '3' && substr.at(1) == '7')
    {
        return true;
    }
    else
    {
        return false;
    }
}
