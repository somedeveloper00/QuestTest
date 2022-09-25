using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "SampleTest/Collectible", order = 0)]
public abstract class Collectible : ScriptableObject
{
    public string displayName;
    public Sprite icon;

    public event Action onCollect;

    public void Collect()
    {
        onCollect?.Invoke();
    }
}