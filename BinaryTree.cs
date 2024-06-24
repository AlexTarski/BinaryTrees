using Newtonsoft.Json.Linq;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace BinaryTrees;

public class BinaryTree<T> : IEnumerable<T>
    where T : IComparable
{
    private T Value;
    private bool IsEmpty = true;
    private int Weight = 0;
    private BinaryTree<T> Left;
    private BinaryTree<T> Right;

    public BinaryTree()
    {

    }

    public BinaryTree(T value)
    {
        Value = value;
        IsEmpty = false;
        Weight = 1;
    }

    public T this[int i]
    {
        get
        {
            if (IsEmpty)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Tree is empty");
            }
            if (i < 0 || i > this.Weight - 1)
            {
                throw new IndexOutOfRangeException(nameof(i));
            }

            if (i == 0 && this.Left == null)
            {
                return Value;
            }

            return GetValueByIndex(this, i);

        }
    }

    private static T GetValueByIndex(BinaryTree<T> node, int index)
    {
        while (true)
        {
            int elementsBeforeIndex = node.Left?.Weight ?? 0;
            if (elementsBeforeIndex == index) return node.Value;

            if (elementsBeforeIndex < index)
            {
                index = index - elementsBeforeIndex - 1;
                node = node.Right;
            }
            else
            {
                node = node.Left;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if(IsEmpty)
        {
            yield break;
        }
        if (Left != null)
        {
            foreach (var v in Left)
            {
                yield return v;
            }
        }
        yield return Value;

        if (Right != null)
        {
            foreach (var v in Right)
            {
                yield return v;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T key)
    {
        if(this.IsEmpty)
        {
            this.IsEmpty = false;
            this.Value = key;
            this.Weight++;
        }
        else
        {
            this.InsertValue(key);
        }
    }

    private void InsertValue(T key)
    {
        BinaryTree<T> currentNode = this;
        while (true)
        {
            if (key.CompareTo(currentNode.Value) < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Weight++;
                    currentNode.Left = new BinaryTree<T>(key);
                    break;
                }
                else
                {
                    currentNode.Weight++;
                    currentNode = currentNode.Left;
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Weight++;
                    currentNode.Right = new BinaryTree<T>(key);
                    break;
                }
                else
                {
                    currentNode.Weight++;
                    currentNode = currentNode.Right;
                }
            }
        }
    }

    public bool Contains(T key)
    {
        if (this.IsEmpty)
        {
            return false;
        }
        else
        {
            BinaryTree<T> currentNode = this;
            while(currentNode != null)
            {
                if(key.CompareTo(currentNode.Value) == 0)
                {
                    return true;
                }
                else if (key.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return false;
        }
    }
}