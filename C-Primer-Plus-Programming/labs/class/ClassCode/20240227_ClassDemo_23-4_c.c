/**/
#include <stdio.h> //standard input output, for scanf(), printf(), ...


int main()
{
	int year, month, day;
	printf("Enter a date(year-month-day): ");
	scanf("%d-%d-%d", &year, &month, &day);//三种默认分隔符: 空格, 制表符(Tab键), 换行符(回车键) 
	printf("The date is %d-%d-%d.\n", year, month, day);
	return 0;
}

int main4()
{
	int a, b;
	printf("Enter two integers: ");
	scanf("%d %d", &a, &b);//三种默认分隔符: 空格, 制表符(Tab键), 换行符(回车键) 
	printf("a = %d, b = %d\n", a, b);
	return 0;
}

int main3()
{
	int a;
	printf("Enter an integer: ");
	scanf("%d", &a);
	printf("a = %d\n", a);
	return 0;
}

int main2()
{
	printf("Hello world!\n");
	printf("Hello world!\nHello world!\n");
	return 0;
}

int main1()
{
	//printf("Hello world!\n");
	//int i;
	for(int i = 1; i <= 5; i++)
	{
		printf("Hello world!\n");
	}
	return 0;
} 

/*#include <iostream> //input output stream, for cin, cout, endl, ...
using namespace std;

int main()
{
	cout << "Hello world!" << endl;
	return 0;
}
*/
