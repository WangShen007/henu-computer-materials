# Lab 07 题目

《机器学习与数据挖掘》深度学习

## 实验题目

卷积神经网络

## 实验目的

掌握卷积神经网络用于多分类的工作流程

## 实验环境（硬件和软件）

Anaconda/Jupyter notebook/Pycharm

## 实验内容

CIFAR-10和CIFAR-100是来自于80 million张小型图片的数据集，图片收集者是Alex Krizhevsky, Vinod Nair, and Geoffrey Hinton。暂时先不管CIFAR-100数据集，以下是CIFAR-10数据集介绍：

Keras中，可以用load_data()进行加载，与MNIST数据集加载方式类似，具体加载示例如下：

**实验要求：** 参考本周PPT讲解内容，用卷积神经网络实现GoogleNet和ResNet进行上述图像数据集分类任务。只需搭建一个Inception块和ResNet块。迭代次数设置在5-10即可。
