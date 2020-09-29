using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public Image imagePrefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
