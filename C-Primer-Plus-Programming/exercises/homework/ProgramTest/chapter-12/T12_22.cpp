#include <iostream>
#include <vector>

using namespace std;

bool isConsecutiveFour(const vector<int>& values) {
    int count = 1;
    for (int i = 0; i < values.size() - 1; i++) {
        if (values[i] == values[i + 1]) {
            count++;
            if (count == 4) {
                return true;
            }
        } else {
            count = 1;
        }
    }
    return false;
}

int main() {
    //vector<int> values = {1, 2, 3, 4, 5, 5, 5, 5, 6, 7, 8, 9};
    vector<int> values;
    int n;
    cout<<"Enter the number of elements in the list: ";
    cin>>n;
    cout<<"Enter the elements of the list: ";
    for(int i=0;i<n;i++){
        int x;
        cin>>x;
        values.push_back(x);
    }
    cout << "The list has consecutive four numbers: " << (isConsecutiveFour(values) ? "true" : "false") << endl;
    return 0;
}