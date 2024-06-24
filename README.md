# BinaryTrees

This project is an implementation of Binary Search Tree <T> (BST).
It is empty by default (if the tree was initialized without any value).

BST has the next basic functionality:
(1) It supports indexer: tree[i] returns value of its "i" element by ascending of elements;
    Complexity O(h), where h - tree height;
(2) Add(T key) method: tree.Add(key) adds a new value to the tree;
(3) bool Contains(T key) method: tree.Contains(key) return true if the tree contains "key", otherwise - false;
(4) Implemented IEnumerable<T> enumerates elements in the tree by ascending;
    Complexity O(n), where n - count of elements in the tree;