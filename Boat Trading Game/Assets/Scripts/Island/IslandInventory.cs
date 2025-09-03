using UnityEngine;
using System.Collections.Generic;

public class IslandInventory : MonoBehaviour
{
    [SerializeField] private int maxStackSize = 100;                // maximale Größe pro Stack
    [SerializeField] private List<ItemStack> stacks = new();

    public int MaxStackSize => maxStackSize;

    public void Add(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return;

        foreach (var s in stacks)
        {
            if (s.def == def)
            {
                if (s.amount >= maxStackSize) return;

                int space = maxStackSize - s.amount;
                int toAdd = Mathf.Min(space, amount);
                s.amount += toAdd;
            }
        }
        return;
    }

    public void Remove(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return;

        for (int i = 0; i < stacks.Count; i++)
        {
            var s = stacks[i];
            if (s.def != def) continue;
            s.amount -= amount;
        }
    }

    public bool Has(ItemDef def, int amount)
    {
        if (def == null || amount <= 0) return false;
        foreach (var s in stacks)
        {
            if (s.def == def && s.amount >= amount) return true;
        }
        return false;
    }

    public IReadOnlyList<ItemStack> Stacks => stacks;
}
