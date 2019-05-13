using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyViewBuilder : MonoBehaviour
{
    [SerializeField] private GameObject itemHolderPrefab;
    [SerializeField] private readonly int itemOffset;
    [SerializeField] private GameArmyData armyData;

    private List<ArmyUnit> _units;
    private List<ArmyUnit> units
    {
        get
        {
            _units = SaveManager.save.armyData.units;
            return _units;
        }
    }

    private List<GameObject> instItems;


    private RectTransform contentRect;

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        ConstructUnitsOnContent();
    }

    public void ConstructUnitsOnContent()
    {
        instItems = new List<GameObject>();

        for (int i = 0; i < units.Count; i++)
        {
            instItems.Add(Instantiate(itemHolderPrefab,transform));

            instItems[i].GetComponent<ArmyViewElement>().AddUnitOnThisSlot(GetArmy(units[i].unitName), units[i]);

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

    private void ChangeContentSize()
    {
        contentRect.anchoredPosition = Vector2.zero;
        //contentRect.localPosition
        contentRect.sizeDelta = new Vector2(0.0f, units.Count * (itemHolderPrefab.GetComponent<RectTransform>().sizeDelta.y + itemOffset));
    }

    private Army GetArmy(string _name)
    {
        foreach (var unit in armyData.units)
        {
            if (unit.name == _name)
            {
                return unit;
            }
        }

        Debug.LogError($"return null cant get {_name} of type: {armyData.name}");
        return null;

    }
}
