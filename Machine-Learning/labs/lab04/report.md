# Lab 04 实验报告

> 实验题目：编程实现基于信息增益进行划分选择的决策树算法

计算机与信息工程学院实验报告

## 实验题目

编程实现基于信息增益进行划分选择的决策树算法

## 实验目的

掌握构建决策树的基本流程

## 实验环境

Anaconda/Jupyter notebook

## 实验内容

（实验具体要求）

一、已经给定部分代码，补充完整的代码，需要补充代码的地方已经用红色字体标注，包括：

1. 在第（2）部分；
```python
#补充计算信息熵的代码
```

2. 在第（3）部分；
```python
#补充按给定特征和特征值划分好的数据集的代码
```

3. 在第（4）部分：
```python
#补充计算条件熵的代码
```

4. 在第（6）部分：
```python
#遍历uniqueVals中的每个值，生成相应的分支
```

二、将补充完整的第（2）（3）（4）（6）部分的代码提交，并提交实验结果；（也可以自己重写这四部分的代码提交）

## 实验步骤

**第二部分**

```python
# （2）计算数据集的熵；
def entropy(dataSet):
#数据集条数
m = len(dataSet)
#保存所有的类别及属于该类别的样本数
labelCounts = {}
for featVec in dataSet:
currentLabel = featVec[-1]
if currentLabel not in labelCounts.keys():
labelCounts[currentLabel] = 0
labelCounts[currentLabel] += 1
#保存熵值
e = 0.0
# 补充计算信息熵的代码
for key in labelCounts:
prob = float(labelCounts[key]) / m
if prob > 0:
e -= prob * log(prob, 2)
return e
```

**第三部分**

```python
# （3）划分数据集；
def splitDataSet(dataSet, axis, value):
#补充按给定特征和特征值划分好的数据集的代码
# axis对应的是特征的索引;
retDataSet = []
#遍历数据集
for featVec in dataSet:
if featVec[axis] == value:
reducedFeatVec = featVec[:axis]
reducedFeatVec.extend(featVec[axis+1:])
retDataSet.append(reducedFeatVec)
return retDataSet
```

**第四部分**

```python
# （4）选择最优特征；
def chooseBestFeature(dataSet):
n = len(dataSet[0]) - 1
#计数整个数据集的熵
baseEntropy = entropy(dataSet)
bestInfoGain = 0.0; bestFeature = -1
#遍历每个特征
for i in range(n):
#获取当前特征i的所有可能取值
featList = [example[i] for example in dataSet]
uniqueVals = set(featList)
newEntropy = 0.0
#遍历特征i的每一个可能的取值
for value in uniqueVals:
#按特征i的value值进行数据集的划分
subDataSet = splitDataSet(dataSet, i, value)
#补充计算条件熵的代码
prob = len(subDataSet) / float(len(dataSet))
newEntropy += prob * entropy(subDataSet)
#计算信息增益
infoGain = baseEntropy - newEntropy
#保存当前最大的信息增益及对应的特征
if (infoGain > bestInfoGain):
bestInfoGain = infoGain
bestFeature = i
return bestFeature
```

**第六部分**

```python
# （6）递归训练一棵树；
def trainTree(dataSet,feature_name):
classList = [example[-1] for example in dataSet]
#所有类别都一致
if classList.count(classList[0]) == len(classList):
return classList[0]
#数据集中没有特征
if len(dataSet[0]) == 1:
return classVote(classList)
#选择最优划分特征
bestFeat = chooseBestFeature(dataSet)
bestFeatName = feature_name[bestFeat]
myTree = {bestFeatName:{}}
featValues = [example[bestFeat] for example in dataSet]
uniqueVals = set(featValues)
#遍历uniqueVals中的每个值，生成相应的分支
for value in uniqueVals:
sub_feature_name = feature_name[:]
# 生成在dataSet中bestFeat取值为value的子集；
sub_dataset = splitDataSet(dataSet, bestFeat, value)
myTree[bestFeatName][value] = trainTree(sub_dataset, sub_feature_name)
return myTree
```

**实验数据记录**

**{'a4'：** {0: {'a2': {0: 'yes', 1: {'a1': {0: 'yes', 1: {'a3': {0: 'yes', 1: 'no'}}}}, 2: 'no'}}, 1: {'a5': {0: 'no', 1: 'yes'}}, 2: 'no'}}

## 问题讨论

**关于根节点的选择：** 为什么是 a4？

实验结果显示，树的根节点是特征a4，而不是最初预想的a1或其他特征。

根据ID3算法的原理，这意味着a4在所有特征中具有最高的信息增益。回顾了一下数据集，发现a4有3个可能的取值（0, 1, 2）。当a4=2时，所有的3个样本都属于no类，它的信息熵为0。这个划分极大地拉低了a4的条件熵，从而使其信息增益变得很高。

在splitDataSet函数中，构造reducedFeatVec时，需要用[:axis]和[axis+1:]来跳过当前划分的特征，容易出错
