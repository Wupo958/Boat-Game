using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOpenTier1 : MonoBehaviour
{
    [SerializeField] public IslandInventory islandInventory;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private GameObject uiTier1;
    [SerializeField] private TextMeshProUGUI[] uiItem1;
    [SerializeField] private TextMeshProUGUI[] uiItem2;
    [SerializeField] private GameObject iconItem1;
    [SerializeField] private GameObject iconItem2;
    void Update()
    {
        iconItem1.GetComponent<RawImage>().texture = islandInventory.Stacks[0].def.icon;
        uiItem1[0].text = islandInventory.Stacks[0].def.displayName;
        uiItem1[1].text = islandInventory.Stacks[0].def.worth.ToString();
        if (islandInventory.Stacks.Count > 0)
        {
            uiItem1[2].text = islandInventory.Stacks[0].amount.ToString();
        }
        else
        {
            uiItem1[2].text = "0";
        }

        iconItem2.GetComponent<RawImage>().texture = islandInventory.Stacks[1].def.icon;
        uiItem2[0].text = islandInventory.Stacks[1].def.displayName;
        uiItem2[1].text = islandInventory.Stacks[1].def.worth.ToString();
        if (islandInventory.Stacks.Count > 1)
        {
            uiItem2[2].text = islandInventory.Stacks[1].amount.ToString();
        }
        else
        {
            uiItem2[2].text = "0";
        }
    }

    public void getItems1(int amount)
    {
        getItem(0, amount);
    }

    public void getItems2(int amount)
    {
        getItem(1, amount);
    }

    public void getItem(int index, int amount)
    {
        if (islandInventory.Stacks[index].amount == 0)
        {
            return;
        }

        if (amount > islandInventory.Stacks[index].amount)
        {
            amount = islandInventory.Stacks[index].amount;
        }
        while (playerInventory.money < amount * islandInventory.Stacks[index].def.worth)
        {
            amount--;
        }
        islandInventory.Remove(islandInventory.Stacks[index].def, amount);
        playerInventory.Add(islandInventory.Stacks[index].def, amount);
    }

    public void OpenUI()
    {
        uiTier1.SetActive(true);
    }

    public void CloseUI()
    {
        uiTier1.SetActive(false);
    }
}
