using UnityEngine;
using System.Collections.Generic;

public class IslandProduction : MonoBehaviour
{
    IslandInventory islandInventory;
    [SerializeField] private ItemDef producedItem;
    [SerializeField] private int amount;
    [SerializeField] private int time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        islandInventory = gameObject.GetComponent<IslandInventory>();
        InvokeRepeating(nameof(ProduceItem), time, time);
    }

    private void ProduceItem()
    {
        islandInventory.Add(producedItem, amount);
    }
}
