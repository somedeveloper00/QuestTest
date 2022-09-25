using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "SampleTest/Location", order = 0)]
public class Location : ScriptableObject
{
    public string title;

    [TextArea] public string description;
}