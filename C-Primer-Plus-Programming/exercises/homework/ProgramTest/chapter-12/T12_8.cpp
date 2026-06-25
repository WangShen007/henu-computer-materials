#include <iostream>

using namespace std;

template <typename T>

class vector
{
public:
    T *m_data;
    int m_size;
    vector();
    vector(int size);
    vector(int size, const T &val);
    ~vector();
    int size() const;
    void push_back(const T &x);
    void pop_back();
    T at(int index) const;
    void clear();
    bool empty() const;
    void swap(vector<T> &v);
};

template <typename T>
vector<T>::vector()
{
    m_data = NULL;
    m_size = 0;
}

template <typename T>
vector<T>::vector(int size)
{
    m_data = new T[size];
    m_size = size;
}

template <typename T>
vector<T>::vector(int size, const T &val)
{
    m_data = new T[size];
    m_size = size;
    for (int i = 0; i < size; i++)
    {
        m_data[i] = val;
    }
}

template <typename T>
vector<T>::~vector()
{
    delete[] m_data;
}

template <typename T>
int vector<T>::size() const
{
    if(m_data == NULL)
    {
        return 0;
    }
    return m_size;
}

template <typename T>
void vector<T>::push_back(const T &x)
{
    T *temp = new T[m_size + 1];
    for (int i = 0; i < m_size; i++)
    {
        temp[i] = m_data[i];
    }
    temp[m_size] = x;
    delete[] m_data;
    m_data = temp;
    m_size++;
}

template <typename T>
void vector<T>::pop_back()
{
    if (m_size == 0)
    {
        return;
    }
    T *temp = new T[m_size - 1];
    for (int i = 0; i < m_size - 1; i++)
    {
        temp[i] = m_data[i];
    }
    delete[] m_data;
    m_data = temp;
    m_size--;
}

template <typename T>
T vector<T>::at(int index) const
{
    if (index < 0 || index >= m_size)
    {
        return 0;
    }
    return m_data[index];
}

template <typename T>
void vector<T>::clear()
{
    delete[] m_data;
    m_data = NULL;
    m_size = 0;
}

template <typename T>
bool vector<T>::empty() const
{
    if (m_size == 0)
    {
        return true;
    }
    return false;
}

template <typename T>
void vector<T>::swap(vector<T> &v)
{
    T *temp_data = m_data;
    int temp_size = m_size;
    m_data = v.m_data;
    m_size = v.m_size;
    v.m_data = temp_data;
    v.m_size = temp_size;
}

int main()
{
    vector<int> v1;
    cout << v1.size() << endl;
    v1.push_back(1);
    v1.push_back(2);
    v1.push_back(3);
    cout << v1.size() << endl;
    cout << v1.at(0) << endl;
    cout << v1.at(1) << endl;
    cout << v1.at(2) << endl;
    v1.pop_back();
    cout << v1.size() << endl;
    cout << v1.at(0) << endl;
    cout << v1.at(1) << endl;
    v1.clear();
    cout << v1.size() << endl;
    cout << v1.empty() << endl;
    vector<int> v2(3, 4);
    cout << v2.size() << endl;
    cout << v2.at(0) << endl;
    cout << v2.at(1) << endl;
    cout << v2.at(2) << endl;
    v1.swap(v2);
    cout << v1.size() << endl;
    cout << v1.at(0) << endl;
    cout << v1.at(1) << endl;
    cout << v1.at(2) << endl;
    cout << v2.size() << endl;
    cout << v2.at(0) << endl;
    cout << v2.at(1) << endl;
    cout << v2.at(2) << endl;
    return 0;
}



