#include <iostream>

using namespace std;

class Person
{
public:
    string name;
    string address;
    string phone;
    string email;
    virtual string toString() = 0;
};

class Student : public Person
{
public:
    string status; //const;//freshman, sophomore, junior, or senior
    string toString()
    {
        return "Student";
    }
};

class Employee : public Person
{
public:
    string office;
    double salary;
    string dateHired;
    string toString()
    {
        return "Employee";
    }
};

class Faculty : public Employee
{
public:
    string officeHours;
    string rank;
    string toString()
    {
        return "Faculty";
    }
};

class Staff : public Employee
{
public:
    string title;
    string toString()
    {
        return "Staff";
    }
};

int main()
{    
    Person *p = new Student();
    //cout<<p->Person::toString()<<endl;
    cout << p->toString() << endl;
    p = new Employee();
    cout << p->toString() << endl;
    p = new Faculty();
    cout << p->toString() << endl;
    p = new Staff();
    cout << p->toString() << endl;
    return 0;
}