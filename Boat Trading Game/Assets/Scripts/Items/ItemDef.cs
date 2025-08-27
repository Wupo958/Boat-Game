using UnityEngine;

public enum ItemTier { T1, T2, T3, T4 }
[System.Flags] public enum ItemTag { None = 0, Food = 1, Raw = 2, Metal = 4, Luxury = 8, ShipPart = 16, Sail = 32, Ship = 64 }

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemDef : ScriptableObject
{
    [Header("Identity")]
    public string itemId;       // unique, z.B. "bread"
    public string displayName;
    public ItemTier tier;
    public ItemTag tags;

    [Header("Stats")]
    [Min(1)] public int size = 1;
    [Min(1)] public int worth = 1;

    [Header("Visuals")]
    public Sprite icon;
}