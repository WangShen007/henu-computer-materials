#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout<<"Enter a hex digit: ";
    char hexDigit;
    cin>>hexDigit;

    hexDigit = toupper(hexDigit);
    if (hexDigit <= 'F' && hexDigit >= 'A')
    {
        int value = 10 + hexDigit - 'A';//10
        int temp = value;
        int a[4];
        int sum = 0;
        cout<<"The binary value is ";
        for(int i = 0;i < value;i++)
        {
            a[i] = temp % 2;
            temp /= 2;
            sum++;
            if(temp == 0)
                break;
        }
        for(int i = sum - 1;i >= 0;i--)
        {
            cout<<a[i];
        }
    }
    else if(isdigit(hexDigit))
    {
        int value = hexDigit - '0';
        int temp = value;
        int a[4];
        int sum = 0;
        cout<<"The binary value is ";
        for(int i = 0;i < 4;i++)
        {
            a[i] = temp % 2;
            temp = temp / 2;
            sum++;
            if(temp == 0)
                break;
        }
        for(int i = sum - 1;i >= 0;i--)
        {
            cout<<a[i];
        }
    }
    else
    {
        cout<<hexDigit<<" is an invalid input"<<endl;
    }
    return 0;
}


















/*十六进制转十进制
#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout<<"Enter a hex digit: ";
    char hexDigit;
    cin>>hexDigit;

    hexDigit = toupper(hexDigit);
    if (hexDigit <= 'F' && hexDigit >= 'A')
    {
        int value = 10 + hexDigit - 'A';
        cout<<"The decimal value for hex digit "<<hexDigit<<" is "<<value<<endl;
    }
    else if(isdigit(hexDigit))
    {
        cout<<"The decimal value for hex digit "<<hexDigit<<" is "<<hexDigit<<endl;
    }
    else
    {
        cout<<hexDigit<<" is an invalid input"<<endl;
    }
    return 0;
}
*/

/*
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

string hexCharToBin(char c) {
    // 根据十六进制的每一位字符返回其对应的四位二进制字符串
    switch(tolower(c)) {
        case '0': return "0000";
        case '1': return "0001";
        case '2': return "0010";
        case '3': return "0011";
        case '4': return "0100";
        case '5': return "0101";
        case '6': return "0110";
        case '7': return "0111";
        case '8': return "1000";
        case '9': return "1001";
        case 'a': return "1010";
        case 'b': return "1011";
        case 'c': return "1100";
        case 'd': return "1101";
        case 'e': return "1110";
        case 'f': return "1111";
        default: return "";
    }
}

string hexToBin(const string& hex) {
    string bin = "";
    for (char c : hex) {
        bin += hexCharToBin(c);
    }
    return bin;
}

int main() {
    string hexStr;
    cout << "请输入一个十六进制数（例如 1A3F）: ";
    cin >> hexStr;

    string binaryStr = hexToBin(hexStr);
    cout << "二进制表示为: " << binaryStr << endl;

    return 0;
}

*/

/*
#include <iostream>
#include <sstream>
#include <bitset>

using namespace std;

int main() {
    string hexStr;
    cout << "请输入一个十六进制数（例如 1A3F）: ";
    cin >> hexStr;

    // 将十六进制数转换为十进制
    stringstream ss;
    ss << hex << hexStr;
    unsigned long hexAsInt;
    ss >> hexAsInt;

    // 将十进制数转换为二进制
    bitset<32> binary(hexAsInt); // 假设十六进制数不超过32位

    cout << "二进制表示为: " << binary.to_string() << endl;

    return 0;
}

*/
