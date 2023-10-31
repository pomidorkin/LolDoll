using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntIntDictionary
{
    public List<int> keys;
    public List<int> values;

    public void Add(int key, int value)
    {
        keys.Add(key);
        values.Add(value);
    }

    public void Initialize()
    {
        keys = new List<int>();
        values = new List<int>();
    }

    public int GetValue(int key)
    {
        int index = keys.IndexOf(key);
        if (index >= 0)
        {
            return values[index];
        }
        return default(int);
    }

    public void SetValue(int key, int value)
    {
        int index = keys.IndexOf(key);
        values[index] = value;
    }

    public void IncrementValue(int key, int value)
    {
        int index = keys.IndexOf(key);
        values[index] += value;
    }

    public bool ContainsKey(int key)
    {
        return keys.Contains(key);
    }

    // Implement other dictionary-like methods as needed
}