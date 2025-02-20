using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
   
    Loot GetDroppedItem()
    {
        //Calculates the drop chances from 1 to 100
        int randomNumber = Random.Range(1, 101); //101 because Random.Range value is (inclusive, exclusive)
        List<Loot> PossibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                PossibleItems.Add(item);
            }
        }
        //Drops the Item
        if(PossibleItems.Count > 0)
        {
            Loot droppedItem = PossibleItems[Random.Range(0, PossibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No Loot Drop");
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
        }
    }
}
