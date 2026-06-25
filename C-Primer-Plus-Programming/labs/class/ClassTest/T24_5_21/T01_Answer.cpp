#include <bits/stdc++.h>
#include <fstream>
using namespace std;

int main() {
    ifstream in("encrypt.txt");
    ofstream out("output.txt");
    string key;
    cin >> key;
    vector<int> vis(26, 0);
    string Hash;
    for(int i = 0; i < (int)key.size(); i++) {
        if (vis[key[i] - 'a'] == 0) Hash.push_back(key[i]);
        vis[key[i] - 'a'] = 1;
    }
    for (int i = 25; i >= 0; i--) {
        if (vis[i] == 0) Hash.push_back(i + 'a');
    }
    string ans;
    getline(in, ans);
    in.close();
    for (int i = 0; i < (int)ans.size(); i++) {
        if (ans[i] >= 'a' && ans[i] <= 'z') {
            out << Hash[ans[i] - 'a'];
        } else {
            out << ans[i];
        }
    }
    out.close();
    return 0;
}
