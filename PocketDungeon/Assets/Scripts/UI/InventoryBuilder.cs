using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBuilder : MonoBehaviour
{
    private List<InventoryItem> _items;
    private List<InventoryItem> items
    {
        get
        {
            SetContentViewType();
            return _items;
        }
    }

    [SerializeField] private GameEquipmentData equipmentsData;
    [SerializeField] private readonly int itemOffset;
    [SerializeField] private GameObject itemHolderPrefab;
    [SerializeField] private ItemType itemTypes;


    private List<GameObject> instItems;
    private RectTransform contentRect;

    private Queue<GameObject> SlotsPool = new Queue<GameObject>();

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
    }

    private void SetContentViewType()
    {
        switch (itemTypes)
        {
            case ItemType.Head:
                _items = SaveManager.save.inventoryData.heads;
                break;
            case ItemType.Сhest:
                _items = SaveManager.save.inventoryData.chests;
                break;
            case ItemType.Legs:
                _items = SaveManager.save.inventoryData.legs;
                break;
            case ItemType.Weapon:
                _items = SaveManager.save.inventoryData.weapons; 
                break;
            default:
                break;
        }
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

        for (int i = 0; i < items.Count; i++)
        {
            instItems.Add(PoolObject());

            instItems[i].GetComponent<InventoryElement>().AddItemOnThisSlot(GetEquipment(items[i].id), items[i]);

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

        Debug.LogError($"return null cant get{id} of type: {itemTypes} on {equipmentsData.name}");
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

            if (items.Contains(invItem))
                items.Remove(invItem);
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
        contentRect.sizeDelta = new Vector2(0.0f, items.Count * (itemHolderPrefab.GetComponent<RectTransform>().sizeDelta.y + itemOffset));
    }
}
