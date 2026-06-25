#include <iostream>
#include <cmath>

using namespace std;

class Complex
{
    public:
        Complex()
        {
            real = 0;
            imaginary = 0;
        }
        Complex(double a)
        {
            real = a;
            imaginary = 0;
        }
        Complex(double a, double b)
        {
            real = a;
            imaginary = b;
        }
        double getReal() const
        {
            return real;
        }
        double getImaginary() const
        {
            return imaginary;
        }
        double abs() const
        {
            return sqrt(real * real + imaginary * imaginary);
        }
        Complex add(const Complex& secondComplex) const
        {
            double newReal = real + secondComplex.getReal();
            double newImaginary = imaginary + secondComplex.getImaginary();
            return Complex(newReal, newImaginary);
        }
        Complex subtract(const Complex& secondComplex) const
        {
            double newReal = real - secondComplex.getReal();
            double newImaginary = imaginary - secondComplex.getImaginary();
            return Complex(newReal, newImaginary);
        }
        Complex multiply(const Complex &secondComplex) const
        {
            double newReal = real * secondComplex.getReal() - imaginary * secondComplex.getImaginary();
            double newImaginary = real * secondComplex.getImaginary() + imaginary * secondComplex.getReal();
            return Complex(newReal, newImaginary);
        }
        Complex divide(const Complex &secondComplex) const
        {
            double newReal = (real * secondComplex.getReal() + imaginary * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            double newImaginary = (imaginary * secondComplex.getReal() - real * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            return Complex(newReal, newImaginary);
        }
        Complex operator+(const Complex &secondComplex)
        {
            double newReal = real + secondComplex.getReal();
            double newImaginary = imaginary + secondComplex.getImaginary();
            Complex a(newReal, newImaginary);
            return a;
        }
        Complex operator-(const Complex &secondComplex)
        {
            double newReal = real - secondComplex.getReal();
            double newImaginary = imaginary - secondComplex.getImaginary();
            Complex a(newReal, newImaginary);
            return a;
        }
        Complex operator*(const Complex &secondComplex)
        {
            double newReal = real * secondComplex.getReal() - imaginary * secondComplex.getImaginary();
            double newImaginary = real * secondComplex.getImaginary() + imaginary * secondComplex.getReal();
            Complex a(newReal, newImaginary);
            return a;
        }
        Complex operator/(const Complex &secondComplex)
        {
            double newReal = (real * secondComplex.getReal() + imaginary * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            double newImaginary = (imaginary * secondComplex.getReal() - real * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            Complex a(newReal, newImaginary);
            return a;
        }
        Complex& operator+=(const Complex &secondComplex)
        {
            double newReal = real + secondComplex.getReal();
            double newImaginary = imaginary + secondComplex.getImaginary();
            real = newReal;
            imaginary = newImaginary;
            return *this;
        }
        Complex& operator-=(const Complex &secondComplex)
        {
            double newReal = real - secondComplex.getReal();
            double newImaginary = imaginary - secondComplex.getImaginary();
            real = newReal;
            imaginary = newImaginary;
            return *this;
        }
        Complex& operator*=(const Complex &secondComplex)
        {
            double newReal = real * secondComplex.getReal() - imaginary * secondComplex.getImaginary();
            double newImaginary = real * secondComplex.getImaginary() + imaginary * secondComplex.getReal();
            real = newReal;
            imaginary = newImaginary;
            return *this;
        }
        Complex& operator/=(const Complex &secondComplex)
        {
            double newReal = (real * secondComplex.getReal() + imaginary * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            double newImaginary = (imaginary * secondComplex.getReal() - real * secondComplex.getImaginary()) / (secondComplex.getReal() * secondComplex.getReal() + secondComplex.getImaginary() * secondComplex.getImaginary());
            real = newReal;
            imaginary = newImaginary;
            return *this;
        }
        Complex& operator++()
        {
            real++;
            return *this;
        }
        Complex& operator--()
        {
            real--;
            return *this;
        }
        Complex operator++(int dummy)
        {
            Complex temp(real, imaginary);
            real++;
            return temp;
        }
        Complex operator--(int dummy)
        {
            Complex temp(real, imaginary);
            real--;
            return temp;
        }
        friend istream& operator>>(istream &in, Complex &c)
        {
            in>>c.real>>c.imaginary;
            return in;
        }
        friend ostream& operator<<(ostream &out, const Complex &c)
        {
            out<<c.real<<" + "<<c.imaginary<<"i";
            return out;
        }
        double operator[](int index)
        {
            if(index == 0)
                return real;
            else if(index == 1)
                return imaginary;
            else
                return 0;
        }

    private:
        double real;
        double imaginary;
};

Complex operator+(const Complex &c1, const Complex &c2)
{
    return c1.add(c2);
}

Complex operator-(const Complex &c1, const Complex &c2)
{
    return c1.subtract(c2);
}

Complex operator*(const Complex &c1, const Complex &c2)
{
    return c1.multiply(c2);
}

Complex operator/(const Complex &c1, const Complex &c2)
{
    return c1.divide(c2);
}

int main()
{
    cout<<"Enter the first complex number: ";
    Complex c1;
    cin>>c1;
    cout<<"Enter the second complex number: ";
    Complex c2;
    cin>>c2;
    cout<<"("<<c1<<") + ("<<c2<<") = "<<c1 + c2<<endl;
    cout<<"("<<c1<<") - ("<<c2<<") = "<<c1 - c2<<endl;
    cout<<"("<<c1<<") * ("<<c2<<") = "<<c1 * c2<<endl;
    cout<<"("<<c1<<") / ("<<c2<<") = "<<c1 / c2<<endl;
    cout<<"|"<<c1<<"| = "<<c1.abs()<<endl;
}