using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBuilder : MonoBehaviour
{
    [SerializeField] private GameInventoryData inventoryData;
    [SerializeField] private GameEquipmentData equipmentsData;
    private List<GameObject> instItems;
    [SerializeField] private readonly int itemOffset;
    [SerializeField] private GameObject itemHolderPrefab;

    private RectTransform contentRect;

    private Queue<GameObject> SlotsPool = new Queue<GameObject>();

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        ConstructItemsOnContent();
    }

    private void OnDisable()
    {
        ClearContent();
    }
    private void RebuildContent()
    {
        ClearContent();
        ConstructItemsOnContent();
    }

    private void ClearContent()
    {
        for (int i = instItems.Count - 1; i >= 0; i--)
        {
            instItems[i].SetActive(false);
            SlotsPool.Enqueue(instItems[i]);
        }

        instItems.Clear();
    }

    private void ConstructItemsOnContent()
    {
        instItems = new List<GameObject>();

        for (int i = 0; i < inventoryData.inventoryItems.Count; i++)
        {
            instItems.Add(PoolObject());

            instItems[i].GetComponent<InventoryElement>().AddItemOnThisSlot(GetEquipment(inventoryData.inventoryItems[i].id), inventoryData.inventoryItems[i]);

            if (i == 0)
                instItems[i].transform.localPosition = Vector2.zero;
            else
                instItems[i].transform.localPosition = new Vector2(
                    instItems[i].transform.localPosition.x,
                    instItems[i - 1].transform.localPosition.y - instItems[i].GetComponent<RectTransform>().sizeDelta.y - itemOffset);

            instItems[i].SetActive(true);
        }

        ChangeContentSize();
    }

    private Equipment GetEquipment(string id)
    {
        foreach (var item in equipmentsData.Items)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }

    /// <summary>
    /// При продаже имеющегося предмета
    /// </summary>
    public void RemoveItem(GameObject go)
    {
        if (instItems.Contains(go))
        {
            go.SetActive(false);
            SlotsPool.Enqueue(go);

            var invItem = go.GetComponent<InventoryElement>().InvItem;

            if (inventoryData.inventoryItems.Contains(invItem))
                inventoryData.inventoryItems.Remove(invItem);
            instItems.Remove(go);
            RebuildContent();
        }
        else
        {
            Debug.LogError($"Gameobject:{go.name} don`t contained on {instItems.GetHashCode()}");
        }
    }

    private GameObject PoolObject()
    {
        if (SlotsPool.Count == 0)
            SlotsPool.Enqueue(Instantiate(itemHolderPrefab, transform, false));

        return SlotsPool.Dequeue();
    }

    private void ChangeContentSize()
    {
        contentRect.localPosition = Vector2.zero;
        contentRect.sizeDelta = new Vector2(0.0f, inventoryData.inventoryItems.Count * (itemHolderPrefab.GetComponent<RectTransform>().sizeDelta.y + itemOffset));
    }
}
