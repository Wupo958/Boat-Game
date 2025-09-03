using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public enum ItemTier { T1, T2, T3, T4 }

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemDef : ScriptableObject
{
    [Header("Identity")]
    public string itemId;       // unique, z.B. "bread"
    public string displayName;
    public ItemTier tier;
    public bool consumable;

    [Header("Stats")]
    [Min(1)] public int size = 1;
    [Min(1)] public int worth = 1;

    [Header("Visuals")]
    public Texture icon;
}


[System.Serializable]
public class ItemStack
{
    public ItemDef def;
    public int amount;
    public int TotalSize => def.size * amount;
}