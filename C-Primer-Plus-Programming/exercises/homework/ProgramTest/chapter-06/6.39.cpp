#include <iostream>
#include <cctype>
#include <string>

using namespace std;

//char decimalToHex(int x)
//{
//    if(x >= 0 && x <= 9)
//    {
//        char xx = x + '0';
//        return xx;
//    }
//    else if(x >= 10 && x <= 15)
//    {
//        char name;
//        switch(x)
//        {
//        case 10 :
//            name = 'a';
//            break;
//        case 11 :
//            name = 'b';
//            break;
//        case 12 :
//            name = 'c';
//            break;
//        case 13 :
//            name = 'd';
//            break;
//        case 14 :
//            name = 'e';
//            break;
//        case 15 :
//            name = 'f';
//            break;
//        }
//        name = toupper(name);
//        return name;
//    }
//    else
//    {
//        return '*';
//    }
//}

int bin2Dec(const string& binaryString)
{
    int length = binaryString.length();
    int decimalDigit = 0;
    for(int i = 0;i < length;i++)
    {
        int number = binaryString.at(i) - '0';
        decimalDigit *= 2;
        decimalDigit += number;
    }
    return decimalDigit;
}

int main()
{
    cout<<"Enter a binary number: ";
    string binaryNumber;
    cin>>binaryNumber;
    int dec = bin2Dec(binaryNumber);
    cout<<dec<<endl;
}
