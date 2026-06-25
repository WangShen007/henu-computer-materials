#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Course
{
public:
    Course(const string &courseName, int capacity);
    string getCourseName() const;
    void addStudent(const string &name);
    void dropStudent(const string &name);
    vector<string> getStudents() const;
    int getNumberOfStudents() const;

private:
    string courseName;
    vector<string> students;
    int capacity;
};

Course::Course(const string &courseName, int capacity)
{
    this->courseName = courseName;
    this->capacity = capacity;
}

string Course::getCourseName() const
{
    return courseName;
}

void Course::addStudent(const string &name)
{
    if (students.size() < capacity)
    {
        students.push_back(name);
    }
    else
    {
        cout << "Course is full" << endl;
    }
}

void Course::dropStudent(const string &name)
{
    for (int i = 0; i < students.size(); i++)
    {
        if (students[i] == name)
        {
            students.erase(students.begin() + i);
            return;
        }
    }
    cout << "Student not found" << endl;
}

vector<string> Course::getStudents() const
{
    return students;
}

int Course::getNumberOfStudents() const
{
    return students.size();
}

int main()
{
    Course course1("Data Structures", 10);
    Course course2("Database Systems", 15);

    course1.addStudent("Peter Jones");
    course1.addStudent("Brian Smith");
    course1.addStudent("Anne Kennedy");

    course2.addStudent("Peter Jones");
    course2.addStudent("Steve Smith");

    cout << "Number of students in course1: " << course1.getNumberOfStudents() << endl;
    vector<string> students = course1.getStudents();
    for (int i = 0; i < students.size(); i++)
    {
        cout << students[i] << ", ";
    }
    cout << endl;

    cout << "Number of students in course2: " << course2.getNumberOfStudents() << endl;
    students = course2.getStudents();
    for (int i = 0; i < students.size(); i++)
    {
        cout << students[i] << ", ";
    }
    cout << endl;

    course1.dropStudent("Brian Smith");

    cout << "Number of students in course1: " << course1.getNumberOfStudents() << endl;
    students = course1.getStudents();
    for (int i = 0; i < students.size(); i++)
    {
        cout << students[i] << ", ";
    }
    cout << endl;

    return 0;
}
