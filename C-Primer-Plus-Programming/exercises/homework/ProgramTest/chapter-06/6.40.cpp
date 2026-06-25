#include <iostream>
#include <string>
#include <cctype>
using namespace std;
//2->16

char decimalToHex(int x)
{
    if(x >= 0 && x <= 9)
    {
        char xx = x + '0';
        return xx;
    }
    else if(x >= 10 && x <= 15)
    {
        char name;
        switch(x)
        {
        case 10 :
            name = 'a';
            break;
        case 11 :
            name = 'b';
            break;
        case 12 :
            name = 'c';
            break;
        case 13 :
            name = 'd';
            break;
        case 14 :
            name = 'e';
            break;
        case 15 :
            name = 'f';
            break;
        }
        name = toupper(name);
        return name;
    }
    else
    {
        return '*';
    }
}

string Dec2Hex(int value)
{
    string hex;
    while(value != 0)
    {
        char x = decimalToHex(value % 16);
        hex = x + hex;
        value /= 16;
    }
    return hex;
}



int main()
{
   cout<<"Enter a decimal number: ";
   int decNumber;
   cin>>decNumber;
   string hex = Dec2Hex(decNumber);
   cout<<hex<<endl;
}


/*
#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout << "Enter a decimal value (0 to 15): " ;
    int x;
    cin>>x;
    if(x >= 0 && x <= 9)
    {
        cout<<"The hex value is "<<x;
    }
    else if(x >= 10 && x <= 15)
    {
        cout<<"The hex value is ";
        char name;
        switch(x)
        {
        case 10 :
            name = 'a';
            break;
        case 11 :
            name = 'b';
            break;
        case 12 :
            name = 'c';
            break;
        case 13 :
            name = 'd';
            break;
        case 14 :
            name = 'e';
            break;
        case 15 :
            name = 'f';
            break;
        }
        name = toupper(name);
        cout<<name;
    }
    else
    {
        cout<<x<<" is an invalid input";
    }
}



#include <iostream>
using namespace std;

long long n, x;
string s;
char c;

int main(){

		条件：
			n是一个不超过18位的正整数。
		注意：
			int最多表达到 2^31 - 1，10位整数。
			long long 最多表达到 2^63 - 1，19位整数。

		思路：
			逆序存储到字符串时要注意：
			整数 0 ~ 9，转换为字符 '0' ~ '9'，x + '0'
			整数 10 ~ 15，转换为字符 'A' ~ 'F'，x + 'A' - 10 或 x + 55

	cin >> n;

	while(n != 0){
		x = n % 16;
//		cout << x << endl;
		if(x < 10){
			c = x + '0';
		}else{
			c = x + 'A' - 10;
		}

		s = c + s;

		n = n / 16;
	}

//	cout << s;

	if(s == ""){
		cout << 0;
	}else{
		cout << s;
	}
}


#include <iostream>
using namespace std;

long long n, x;
string s;
string t = "0123456789ABCDEF";

int main(){

		条件：
			n是一个不超过18位的正整数。
		注意：
			int最多表达到 2^31 - 1，10位整数。
			long long 最多表达到 2^63 - 1，19位整数。

		思路：
			逆序存储到字符串时要注意：
			整数 0 ~ 9，转换为字符 '0' ~ '9'，x + '0'
			整数 10 ~ 15，转换为字符 'A' ~ 'F'，x + 'A' - 10 或 x + 55

	cin >> n;

	while(n != 0){
		x = n % 16;
		// 将 n % 16 转换为字符逆序存入 s
		s = t[x] + s;
		n = n / 16;
	}

	if(s == ""){
		cout << 0;
	}else{
		cout << s;
	}
}

*/
