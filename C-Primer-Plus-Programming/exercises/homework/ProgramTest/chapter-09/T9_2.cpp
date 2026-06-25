#include <iostream>
using namespace std;

#ifndef FAN_H
#define FAN_H

class Fan
{
public:
    int speed;
    bool on;
    double radius;
    Fan();
    int getSpeed();
    bool getOn();
    double getRadius();
    void setSpeed(int newSpeed);
    void turnOn();
    void turnOff();
    void setRadius(double newRadius);
};

#endif // FAN_H

Fan::Fan()
{
    speed = 1;
    on = false;
    radius = 5;
}

int Fan::getSpeed()
{
    return speed;
}

bool Fan::getOn()
{
    return on;
}

double Fan::getRadius()
{
    return radius;
}

void Fan::setSpeed(int newSpeed)
{
    speed = newSpeed;
}
void Fan::turnOn()
{
    on = true;
}

void Fan::turnOff()
{
    on = false;
}

void Fan::setRadius(double newRadius)
{
    radius = newRadius;
}



int main()
{
    Fan fan1;
    Fan fan2;

    fan1.turnOn();
    fan1.setSpeed(3);
    fan1.setRadius(10);
    fan2.turnOff();
    fan2.setSpeed(2);
    fan2.setRadius(5);
    cout<<"Fan1: "<<fan1.getOn()<<"   "<<fan1.getRadius()<<"   "<<fan1.getSpeed()<<endl;
    cout<<"Fan2: "<<fan2.getOn()<<"   "<<fan2.getRadius()<<"   "<<fan2.getSpeed()<<endl;

    return 0;
}

