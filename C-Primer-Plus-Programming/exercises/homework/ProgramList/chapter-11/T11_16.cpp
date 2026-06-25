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
