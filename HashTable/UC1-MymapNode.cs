using System;
using System.Collections.Generic;

// Class to represent each key-value pair in the map
public class MyMapNode
{
    public string Key { get; set; }
    public int Value { get; set; }
}

// Class to represent a LinkedList of MyMapNodes
public class LinkedList
{
    public LinkedList? Next { get; set; }
    public MyMapNode? MapNode { get; set; }
}

// Class for Use Case 1: FrequencyCounter for a sentence
public class SentenceFrequencyCounter
{
    private LinkedList[] hashTable;
    private int size;

    public SentenceFrequencyCounter(int size)
    {
        this.size = size;
        hashTable = new LinkedList[size];
    }

    private int GetBucketIndex(string word)
    {
        int hashCode = word.GetHashCode();
        int index = Math.Abs(hashCode % size);
        return index;
    }

    public void InsertOrUpdate(string word)
    {
        int index = GetBucketIndex(word);
        LinkedList linkedList = hashTable[index];

        while (linkedList != null)
        {
            if (linkedList.MapNode.Key.Equals(word))
            {
                linkedList.MapNode.Value++;
                return;
            }
            linkedList = linkedList.Next;
        }

        LinkedList newNode = new LinkedList
        {
            MapNode = new MyMapNode { Key = word, Value = 1 }
        };

        newNode.Next = hashTable[index];
        hashTable[index] = newNode;
    }

    public int GetFrequency(string word)
    {
        int index = GetBucketIndex(word);
        LinkedList linkedList = hashTable[index];

        while (linkedList != null)
        {
            if (linkedList.MapNode.Key.Equals(word))
                return linkedList.MapNode.Value;

            linkedList = linkedList.Next;
        }

        return 0;
    }
}

