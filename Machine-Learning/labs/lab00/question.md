# Lab 00 题目

## 来源文档 1: 实验操作教程

现在假定你已经按我们发的机器学习环境安装教程，安装好了anaconda和配置好了虚拟环境，就可以按照下面步骤进行实验了。

1. 新建一个文件夹，命名为“实验一”，然后将数据集data1.txt拷贝到该文件夹下，如下图：
2. 在该文件夹下输入cmd，打开命令输入窗口，如下图：
3. 在命令窗口输入：activate myjiqixuexi（这个是我建立的虚拟环境）；
4. 再次输入jupyter notebook，可自动打开jupyter notebook（浏览器网页形式），如下图：
5. 新建一个jupyter代码编辑窗口，流程如下：
6. 在方框里写代码，如下：
7. 点击运行按钮，如果出现：ModuleNotFoundError: No module named ***的错误，表明缺少相应的工具包，需要安装；
8. 再次用WIN+R快捷键打开一个命令窗口，然后输入activate myjiqixuexi进入当前的虚拟环境“myjiqixuexi”，输入pip install numpy，在当前的虚拟环境安装所需的工具包numpy。后续所有类似的问题都可以这样解决。
7. 安装后，再次运行代码，就没有错误了，如下图：
8. 关闭窗口后，我们的代码文件自动保存在该文件夹下，后续可随时打开，如下图所示。

## 来源文档 2: 机器学习环境安装教程

Jupyter notebook安装教程

解压“Anaconda”压缩包到本地文件夹

管理员方式运行“Anaconda3-2021.11-Windows-x86_64”

文件安装流程

在D盘中创建一个新文件夹作为路径（不带中文），并选择。

进一步继续点击完成安装

Jupyter的安装

win+R打开cmd，输入conda create --name mytest（mytest为自己自定义的名字）python=3.9.7

弹出提示后输入y，enter进行下一步

下载完成后如图所示

输入conda activate mytest（mytest为你自己的命名，此处仅为示例）

输入后路径前出现括号前缀，继续输入pip install jupyter==1.0.0

进入下载进程

安装完成后输入pip list，查看是否安装成功。

安装成功后，关闭命令窗口。然后使用快捷键Win+R，输入cmd，重新打开命令窗口。再输入conda activate mytest，进入刚创建的虚拟环境，输入jupyter notebook。

自动打开浏览器界面，或者选择结果中的网址并复制到浏览器打开即可。
