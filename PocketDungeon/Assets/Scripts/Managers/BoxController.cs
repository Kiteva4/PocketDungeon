using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxController
{
    private List<Box> PlayerBoxes;

    public BoxController()
    {
        PlayerBoxes = SaveManager.save.PlayerBoxes;
    }

    public void AddBox(InventoryItemCreator creator, Rarity boxRarity)
    {
        Box box = new Box(creator, boxRarity);
        PlayerBoxes.Add(box);
    }

    public void AddItemToInventory()
    {
        Box box = PlayerBoxes[PlayerBoxes.Count - 1];
        box.OpenBox();
        PlayerBoxes.RemoveAt(PlayerBoxes.Count - 1);
    }

    public Sprite GetItemSprite()
    {
        return PlayerBoxes[PlayerBoxes.Count-1].GetItemImage();
    }

    public float GetBoxGoldCount()
    {
        return PlayerBoxes[PlayerBoxes.Count - 1].GoldsOnBox;
    }
}

