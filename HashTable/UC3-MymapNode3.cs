public class WordRemover
{
    private LinkedList[] hashTable;
    private int size;

    public WordRemover(int size)
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

    public void Remove(string word)
    {
        int index = GetBucketIndex(word);
        LinkedList linkedList = hashTable[index];
        LinkedList prev = null;

        while (linkedList != null)
        {
            if (linkedList.MapNode.Key.Equals(word))
            {
                if (prev == null)
                    hashTable[index] = linkedList.Next;
                else
                    prev.Next = linkedList.Next;

                return;
            }

            prev = linkedList;
            linkedList = linkedList.Next;
        }
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

