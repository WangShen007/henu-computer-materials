//difficult to understand
#include <iostream>
#include <string>
using namespace std;

class Course
{
public:
  Course(const string& courseName, int capacity);
  ~Course();
  string getCourseName() const;
  void addStudent(const string& name);
  void dropStudent(const string& name);
  string* getStudents() const;
  int getNumberOfStudents() const;
  void clear();
  Course(const Course& course);

private:
  string courseName;
  string* students;
  int numberOfStudents;
  int capacity;
};

Course::Course(const string& courseName, int capacity)
{
  numberOfStudents = 0;
  this->courseName = courseName;
  this->capacity = capacity;
  students = new string[capacity];
}

Course::~Course()
{
  delete [] students;
}

string Course::getCourseName() const
{
  return courseName;
}

void Course::addStudent(const string& name)
{
  if(numberOfStudents == capacity)
  {
    string* temp = new string[capacity * 2];
    for(int i = 0; i < capacity; i++)
    {
      temp[i] = students[i];
    }
    delete [] students;
    students = temp;
    capacity *= 2;
  }
  students[numberOfStudents] = name;
  numberOfStudents++;
}

void Course::dropStudent(const string& name)
{
  //drop student
  for(int i = 0; i < numberOfStudents; i++)
  {
    if(students[i] == name)
    {
      for(int j = i; j < numberOfStudents - 1; j++)
      {
        students[j] = students[j + 1];
      }
      numberOfStudents--;
      break;
    }
  }
}

string* Course::getStudents() const
{
  return students;
}

int Course::getNumberOfStudents() const
{
  return numberOfStudents;
}

void Course::clear()
{
  delete [] students;
  students = new string[capacity];
  numberOfStudents = 0;
}

Course::Course(const Course& course)
{
  courseName = course.courseName;
  capacity = course.capacity;
  numberOfStudents = course.numberOfStudents;
  students = new string[capacity];
  for(int i = 0; i < numberOfStudents; i++)
  {
    students[i] = course.students[i];
  }
}

int main()
{
  Course course1("CSC101", 10);
  course1.addStudent("Peter Jones");
  course1.addStudent("Brian Smith");

  Course course2 = course1;
  course2.addStudent("Anne Kennedy");

  cout << "Students in course1: ";
  string* students = course1.getStudents();
  for(int i = 0; i < course1.getNumberOfStudents(); i++)
  {
    cout << students[i] << ", ";
  }

  cout << endl << "Students in course2: ";
  students = course2.getStudents();
  for(int i = 0; i < course2.getNumberOfStudents(); i++)
  {
    cout << students[i] << ", ";
  }

  return 0;
}

/*
#Program List : T11_16

#ifndef COURSE_H
#define COURSE_H
#include <string>
using namespace std;

class Course
{
public:
  Course(const string& courseName, int capacity);
  ~Course();
  string getCourseName() const;
  void addStudent(const string& name);
  void dropStudent(const string& name);
  string* getStudents() const;
  int getNumberOfStudents() const;

private:
  string courseName;
  string* students;
  int numberOfStudents;
  int capacity;
};

#endif


#include <iostream>
//#include "Course.h"
using namespace std;

Course::Course(const string& courseName, int capacity)
{
  numberOfStudents = 0;
  this->courseName = courseName;
  this->capacity = capacity;
  students = new string[capacity];
}

Course::~Course()
{
  delete [] students;
}

string Course::getCourseName() const
{
  return courseName;
}

void Course::addStudent(const string& name)
{
  students[numberOfStudents] = name;
  numberOfStudents++;
}

void Course::dropStudent(const string& name)
{
  // Left as an exercise
}

string* Course::getStudents() const
{
  return students;
}

int Course::getNumberOfStudents() const
{
  return numberOfStudents;
}

*/