using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int capacitySize = 100; // Gesamtkapazität in Size-Einheiten
    [SerializeField] private List<ItemStack> stacks = new();

    public int CapacitySize => capacitySize;
    public int UsedSize
    {
        get
        {
            int used = 0;
            foreach (var s in stacks) used += s.TotalSize;
            return used;
        }
    }
    public int FreeSize => Mathf.Max(0, capacitySize - UsedSize);

    public void SetCapacity(int newCapacity)
    {
        capacitySize = Mathf.Max(0, newCapacity);
    }

    public bool Add(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return false;
        int required = def.size * amount;
        if (FreeSize < required) return false;

        // bestehenden Stack finden
        foreach (var s in stacks)
        {
            if (s.def == def)
            {
                s.amount += amount;
                return true;
            }
        }

        // neuen Stack anlegen
        stacks.Add(new ItemStack { def = def, amount = amount });
        return true;
    }
    public bool Remove(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return false;

        for (int i = 0; i < stacks.Count; i++)
        {
            var s = stacks[i];
            if (s.def != def) continue;

            if (s.amount < amount) return false; // nicht genug vorhanden
            s.amount -= amount;
            if (s.amount <= 0) stacks.RemoveAt(i);
            return true;
        }
        return false;
    }

    public bool Has(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return false;
        foreach (var s in stacks)
            if (s.def == def && s.amount >= amount) return true;
        return false;
    }

    public IReadOnlyList<ItemStack> Stacks => stacks;
}

[System.Serializable]
public class ItemInstance
{
    public ItemDef def;

    public ItemInstance(ItemDef def)
    {
        this.def = def;
    }

    public int Size => def != null ? def.size : 0;
}

[System.Serializable]
public class ItemStack
{
    public ItemDef def;
    public int amount;
    public int TotalSize => def.size * amount;
}