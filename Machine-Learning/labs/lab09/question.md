# Lab 09 题目

《机器学习与数据挖掘》实验七

## 实验题目

实现拉普拉斯修正的朴素贝叶斯分类器

## 实验目的

掌握朴素贝叶斯分类器的原理及应用

实验环境（硬件和软件） Anaconda/Jupyter notebook/Pycharm

## 实验内容

编码实现拉普拉斯修正的朴素贝叶斯分类器，基于给定的训练数据，对测试样本进行判别。

**要求**

一、已经给定部分代码，补充完整的代码，需要补充代码的地方已经用红色字体标注，包括：

1. #补充计算条件概率的代码；
2. #补充预测代码；
二、将补充完整的代码提交，并提交实验结果；（也可以自己重写这部分的代码提交）

```python
import numpy as np
def loaddata():
X = np.array([[1,'S'],[1,'M'],[1,'M'],[1,'S'],
```

[1, 'S'], [2, 'S'], [2, 'M'], [2, 'M'],

[2, 'L'], [2, 'L'], [3, 'L'], [3, 'M'],

[3, 'M'], [3, 'L'], [3, 'L']])

```python
y = np.array([-1,-1,1,1,-1,-1,-1,1,1,1,1,1,1,1,-1])
return X, y
def Train(trainset,train_labels):
m = trainset.shape[0]
n = trainset.shape[1]
prior_probability = {}# 先验概率 key是类别值，value是类别的概率值
conditional_probability ={}# 条件概率 key的构造：类别，特征,特征值
#类别的可能取值
labels = set(train_labels)
# 计算先验概率(此时没有除以总数据量m)
for label in labels:
prior_probability[label] = len(train_labels[train_labels == label])+1
#计算条件概率
#补充计算条件概率的代码；
# 最终的先验概率(此时除以总数据量m)
for label in labels:
prior_probability[label] = prior_probability[label]/ (m+len(labels))
return prior_probability,conditional_probability_final,labels
def predict(data):
result={}
for label in train_labels_set:
temp=1.0
#补充预测代码；
print('result=',result)
#排序返回标签值
return sorted(result.items(), key=lambda x: x[1],reverse=True)[0][0]
X,y = loaddata()
prior_probability,conditional_probability,train_labels_set = Train(X,y)
r_label = predict([2,'S'])
print(' r_label =', r_label)
```
