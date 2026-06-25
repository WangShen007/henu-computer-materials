#include <iostream>
using namespace std;

const int numProvinces = 34; // 中国有34个省级行政区

string provincesAndCapitals[numProvinces][2] = {
    {"北京市", "北京"},
    {"上海市", "上海"},
    {"天津市", "天津"},
    {"重庆市", "重庆"},
    {"黑龙江省", "哈尔滨"},
    {"吉林省", "长春"},
    {"辽宁省", "沈阳"},
    {"内蒙古", "呼和浩特"},
    {"河北省", "石家庄"},
    {"新疆", "乌鲁木齐"},
    {"甘肃省", "兰州"},
    {"青海省", "西宁"},
    {"陕西省", "西安"},
    {"宁夏", "银川"},
    {"河南省", "郑州"},
    {"山东省", "济南"},
    {"山西省", "太原"},
    {"安徽省", "合肥"},
    {"湖北省", "武汉"},
    {"湖南省", "长沙"},
    {"江苏省", "南京"},
    {"四川省", "成都"},
    {"贵州省", "贵阳"},
    {"云南省", "昆明"},
    {"广西省", "南宁"},
    {"西藏", "拉萨"},
    {"浙江省", "杭州"},
    {"江西省", "南昌"},
    {"广东省", "广州"},
    {"福建省", "福州"},
    {"台湾省", "台北"},
    {"海南省", "海口"},
    {"香港", "香港"},
    {"澳门", "澳门"}
};

int main() 
{
    string province;
    cout<<"请输入一个省份的名称：";
    cin>>province;
    for (int i = 0; i < numProvinces; i++) 
    {
        if (province == provincesAndCapitals[i][0]) 
        {
            cout<<"该省的首府是"<<provincesAndCapitals[i][1]<<endl;
            return 0;
        }
    }
    cout<<"对不起，我不知道"<<province<<"的首府是哪里。"<<endl;
    return 0;    
}






/*
// Define the number of states
const int numStates = 50;

// Define the array to hold the state and capital names
string statesAndCapitals[numStates][2];

// Function to populate the array
void populateArray() {
    // For each state
    for (int i = 0; i < numStates; i++) {
        cout << "Enter the name of state " << (i+1) << ": ";
        cin >> statesAndCapitals[i][0];
        cout << "Enter the capital of state " << (i+1) << ": ";
        cin >> statesAndCapitals[i][1];
    }
}

// Function to display the array
void displayArray() {
    // For each state
    for (int i = 0; i < numStates; i++) {
        cout << "State " << (i+1) << ": " << statesAndCapitals[i][0] 
             << ", Capital: " << statesAndCapitals[i][1] << endl;
    }
}

int main() {
    populateArray();
    displayArray();
    return 0;
}
*/