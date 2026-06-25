#include <iostream>
#include <cmath>
#define PI acos(-1)
using namespace std;
//39.55, -116.25
//41.5, 87.37
int main()
{
    cout << "Enter point 1 (latitude and longitude) in degrees:"<<endl;
    double x1,x2,y1,y2;
    cin>>x1>>y1;
    cout << "Enter point 2 (latitude and longitude) in degrees:"<<endl;
    cin>>x2>>y2;
    const double r = 6378.1;
    double o = PI / 180;
    double d = r * acos(sin(x1 * o) * sin(x2 * o) + cos(x1 * o) * cos(x2 * o) * cos(abs(y1 - y2) * o));
    cout<<"The distance between the two points is "<<d<<" km";
    return 0;
}
/*
#include <iostream>
#include <cmath>

// 定义 PI
const double PI = 3.14159265358979323846;

// 将度转换为弧度
double degreesToRadians(double degrees) {
    return (degrees * PI / 180.0);
}

// 计算两个坐标点之间的距离
double calculateDistance(double lat1, double long1, double lat2, double long2) {
    // 地球半径 (公里)
    double earthRadiusKm = 6378.1;

    // 将纬度和经度从度转换为弧度
    lat1 = degreesToRadians(lat1);
    long1 = degreesToRadians(long1);
    lat2 = degreesToRadians(lat2);
    long2 = degreesToRadians(long2);

    // 使用 haversine 公式计算距离
    double dLat = lat2 - lat1;
    double dLon = long2 - long1;

    double a = sin(dLat/2) * sin(dLat/2) +
               cos(lat1) * cos(lat2) *
               sin(dLon/2) * sin(dLon/2);
    double c = 2 * atan2(sqrt(a), sqrt(1-a));
    double distance = earthRadiusKm * c;

    return distance;
}

int main() {
    // 输入两点的纬度和经度
    double lat1, long1, lat2, long2;
    std::cout << "输入点1的纬度和经度（度）: ";
    std::cin >> lat1 >> long1;
    std::cout << "输入点2的纬度和经度（度）: ";
    std::cin >> lat2 >> long2;

    // 计算距离
    double distance = calculateDistance(lat1, long1, lat2, long2);

    // 输出结果
    std::cout << "两点之间的距离是 " << distance << " 公里" << std::endl;

    return 0;
}

*/

/*
您提供的 C++ 程序在计算两点之间距离的基础逻辑上是正确的，但是有一些小问题需要解决：

由于经纬度在 sin 和 cos 函数中应该是以弧度为单位的，您已经正确地将它们从度转换为弧度，但是在计算 cos((y1 - y2) * o) 时，您没有考虑到当 y1 和 y2 之间的差值是负数时，差值的绝对值应该被使用。在地理坐标中，经度可能是负数，这代表西经。负负得正，在计算经度差时，应该使用 y1 和 y2 的绝对差值。

#define PI acos(-1) 这种定义 PI 的方式是有效的，但是使用 const double PI = acos(-1); 或者直接使用 M_PI（如果您的编译器支持）会更标准。

在打印结果时，最好增加一些格式化，以便能更清楚地显示小数点后的位数。例如，您可以使用 std::fixed 和 std::setprecision 来设置精度。

这里是修改后的代码：

#include <iostream>
#include <cmath>
#include <iomanip>  // 用于 std::setprecision

// 使用标准 M_PI 定义，如果编译器不支持，可以自定义
#ifndef M_PI
#define M_PI acos(-1)
#endif

using namespace std;

int main() {
    cout << "Enter point 1 (latitude and longitude) in degrees:" << endl;
    double x1, x2, y1, y2;
    cin >> x1 >> y1;
    cout << "Enter point 2 (latitude and longitude) in degrees:" << endl;
    cin >> x2 >> y2;
    const double r = 6378.1;
    double o = M_PI / 180;
    // 使用 fabs 确保经度差的绝对值
    double d = r * acos(sin(x1 * o) * sin(x2 * o) + cos(x1 * o) * cos(x2 * o) * cos(fabs((y1 - y2) * o)));

    // 设置输出的精度
    cout << fixed << setprecision(6) << "The distance between the two points is " << d << " km" << endl;
    return 0;
}

*/
