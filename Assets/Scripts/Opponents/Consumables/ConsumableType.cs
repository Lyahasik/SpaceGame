using UnityEngine;

[System.Serializable]
public class ConsumableType
{
    public string Name;
    public GameObject Object;
    [Range(0, 100)]
    public int Probability;
    internal int bottomLine;
    internal int topLine;
}
