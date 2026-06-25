
#include <iostream> //input output stream, for cin, cout, endl, ...
using namespace std;

#include <stdio.h> //standard input output, for scanf(), printf(), ...
//#include <cstdio>

int main()
{
	int year, month, day;
	printf("Enter a date(year-month-day): ");
	scanf("%d-%d-%d", &year, &month, &day);//三种默认分隔符: 空格, 制表符(Tab键), 换行符(回车键) 
	printf("The date is %d-%d-%d.\n", year, month, day);	
	
	cout << "---------" << endl;
	
	char c1, c2;
	cout << "Enter a date(year-month-day): ";
	cin >> year >> c1 >> month >> c2 >> day;
	if(c1 != '-' || c2 != '-')
	{
		cout << "Invalid input." << endl;
	}
	else
	{
		cout << "The date is " << year << c1 << month << c2 << day << endl;
	}	
	
	return 0;
}

int main4()
{
	int a, b;
	printf("Enter two integers: ");
	scanf("%d %d", &a, &b);//三种默认分隔符: 空格, 制表符(Tab键), 换行符(回车键) 
	printf("a = %d, b = %d\n", a, b);	
	
	cout << "---------" << endl;
	
	cout << "Enter two integers: ";
	cin >> a >> b;//三种默认分隔符: 空格, 制表符(Tab键), 换行符(回车键) 
	cout << "a = " << a << ", b = " << b << endl;
	
	return 0;
}

int main3()
{
	int a;
	printf("Enter an integer: ");
	scanf("%d", &a);
	printf("a = %d\n", a);
	
	cout << "---------" << endl;
	
	cout << "Enter an integer: ";
	cin >> a;
	cout << "a = " << a << "\n";
	//cout << "a = " << a << '\n';
	//cout << "a = " << a << endl;
	
	return 0;
}

int main2()
{
	printf("Hello world!\n");
	printf("Hello world!\nHello world!\n");
	
	cout << "---------" << endl;
	cout << "Hello world!" << endl;
	cout << "Hello world!" << endl << "Hello world!" << endl;
	return 0;
}

int main1()
{
	//cout << "Hello world!" << endl;
	for(int i = 1; i <= 5; i++)
	{
		cout << "Hello world!" << endl;
	}
	return 0;
}
/*
#include <stdio.h> //standard input output, for scanf(), printf(), ...
int main()
{
	printf("Hello world!\n");
	return 0;
} 
*/
