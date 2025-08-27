using UnityEngine;

[System.Serializable]
public struct ItemAmount { public ItemDef item; public int amount; }

[CreateAssetMenu(menuName = "Data/Recipe")]
public class RecipeDef : ScriptableObject
{
    public string recipeId;

    [Header("IO")]
    public ItemAmount[] inputs;
    public ItemAmount[] outputs;

    [Header("Processing")]
    public float craftTimeSeconds = 5f;
    public ItemTag requiredStationTag;  
    public int cost = 0; 
}