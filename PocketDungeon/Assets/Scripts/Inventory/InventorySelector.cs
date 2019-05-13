using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelector : MonoBehaviour
{
    private InventoryElement selectedElement = null;

    public void SelectInventoryElement(InventoryElement ie)
    {
        if (ReferenceEquals(ie, selectedElement))
        {
            return;
        }

        if (selectedElement != null)
            selectedElement.UnequipThisItem();

        selectedElement = ie;
        selectedElement.EquipThisItem();
    }
}
