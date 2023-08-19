using System;
using System.Linq;

public class NativeCache<T>
{
    private int count;

    public int size;
    public string[] slots;
    public T[] values;
    public int[] hits;

    public NativeCache(int size)
    {
        this.size = size;
        slots = new string[size];
        values = new T[size];
        hits = new int[size];
    }

    public void Put(string key, T value)
    {
        var index = count < size ? SeekSlot(key) : FreeSlot();

        slots[index] = key;
        values[index] = value;
        count++;
    }

    public T Get(string key)
    {
        int hash = HashFun(key);
        int index = hash;

        for (int i = 0; i < size; i++)
        {
            if (slots[index] != null && slots[index].Equals(key))
            {
                hits[index]++;
                return values[index];
            }

            index = StepNext(hash, i);
        }

        return default(T);
    }

    private int FreeSlot()
    {
        var freeIndex = Array.IndexOf(hits, hits.Min());

        slots[freeIndex] = null;
        values[freeIndex] = default(T);
        hits[freeIndex] = 0;
        count--;

        return freeIndex;
    }

    private int SeekSlot(string key)
    {
        var hash = HashFun(key);
        int index = hash;

        for (int i = 1; i <= size; i++)
        {
            if (slots[index] == null)
            {
                return index;
            }

            index = StepNext(hash, i);
        }

        return -1;
    }

    private int StepNext(int index, int i)
    {
        return (index + i) % size;
    }

    private int HashFun(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += (int)c;
        }

        return hash % size;
    }
}