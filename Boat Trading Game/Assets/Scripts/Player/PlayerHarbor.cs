using UnityEngine;

public class PlayerHarbor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harbor1")
        {
            Debug.Log("Test");
            gameObject.GetComponent<PlayerOpenTier1>().islandInventory = other.GetComponentInParent<IslandInventory>();
            gameObject.GetComponent<PlayerOpenTier1>().OpenUI();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Harbor1")
        {
            gameObject.GetComponent<PlayerOpenTier1>().CloseUI();
        }
    }
}
