import numpy as np


def loaddata():
    X = np.array(
        [
            [1, "S"],
            [1, "M"],
            [1, "M"],
            [1, "S"],
            [1, "S"],
            [2, "S"],
            [2, "M"],
            [2, "M"],
            [2, "L"],
            [2, "L"],
            [3, "L"],
            [3, "M"],
            [3, "M"],
            [3, "L"],
            [3, "L"],
        ]
    )
    y = np.array([-1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, -1])
    return X, y


def Train(trainset, train_labels):
    m = trainset.shape[0]
    n = trainset.shape[1]
    prior_probability = {}  # 先验概率 key是类别值，value是类别的概率值
    conditional_probability = {}  # 条件概率 key的构造：类别，特征,特征值
    # 类别的可能取值
    labels = set(train_labels)
    # 计算先验概率(此时没有除以总数据量m)
    for label in labels:
        prior_probability[label] = len(train_labels[train_labels == label]) + 1

    # 计算条件概率
    for j in range(n):
        # features values from training set
        feature_values = set(trainset[:, j])
        S_j = len(feature_values)

        for label in labels:
            label_subset = trainset[train_labels == label]
            N_k = len(label_subset)

            for val in feature_values:
                count = len(label_subset[label_subset[:, j] == val])
                conditional_probability[(label, j, val)] = (count + 1) / (N_k + S_j)

    # 最终的先验概率(此时除以总数据量m)
    for label in labels:
        prior_probability[label] = prior_probability[label] / (m + len(labels))

    return prior_probability, conditional_probability, labels


def predict(data):
    result = {}
    for label in train_labels_set:
        temp = prior_probability[label]
        for j in range(len(data)):
            val = data[j]
            # Handle potential type mismatch (int vs string from numpy array)
            if (label, j, val) in conditional_probability:
                temp *= conditional_probability[(label, j, val)]
            elif (label, j, str(val)) in conditional_probability:
                temp *= conditional_probability[(label, j, str(val))]
            else:
                pass
        result[label] = temp
    print("result=", result)
    # 排序返回标签值
    return sorted(result.items(), key=lambda x: x[1], reverse=True)[0][0]


X, y = loaddata()
prior_probability, conditional_probability, train_labels_set = Train(X, y)
r_label = predict([2, "S"])
print(" r_label =", r_label)

# Verification check
# Based on common NB examples (e.g. from statistical learning books), let's calculate manually to be sure?
# P(Y=1) = (9+1)/(15+2) = 10/17
# P(Y=-1) = (6+1)/(15+2) = 7/17

# x = [2, 'S']
# P(X1=2 | Y=1) = (count(2 in Y=1) + 1) / (9 + 3) = (3+1)/12 = 4/12 = 1/3
# P(X1=2 | Y=-1) = (count(2 in Y=-1) + 1) / (6 + 3) = (2+1)/9 = 3/9 = 1/3

# P(X2='S' | Y=1) = (count('S' in Y=1) + 1) / (9 + 3) = (1+1)/12 = 2/12 = 1/6
# P(X2='S' | Y=-1) = (count('S' in Y=-1) + 1) / (6 + 3) = (3+1)/9 = 4/9

# P(Y=1 | x) ~ 10/17 * 1/3 * 1/6 = 10 / (17 * 18) = 5 / (17 * 9) = 5 / 153 ≈ 0.0327
# P(Y=-1 | x) ~ 7/17 * 1/3 * 4/9 = 28 / (17 * 27) = 28 / 459 ≈ 0.061

# So it should predict -1.
if r_label == -1:
    print("Verification PASSED: Predicted -1")
else:
    print(f"Verification FAILED: Predicted {r_label}, expected -1")
