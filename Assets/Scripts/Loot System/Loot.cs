using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public GameObject lootPrefab;
    public int dropChance;

    public Loot(string LootName, int DropChance)
    {
        this.lootName = LootName;
        this.dropChance = DropChance;
    }
}
