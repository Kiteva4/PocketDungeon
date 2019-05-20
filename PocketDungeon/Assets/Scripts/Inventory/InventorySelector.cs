using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelector : MonoBehaviour
{
    /// <summary>
    /// Надетый предмет
    /// </summary>
    private InventoryElement selectedElement = null;

    /// <summary>
    /// Надеть новый предмет инвентаря
    /// </summary>
    /// <param name="ie"> предмет инвентаря </param>
    public void SelectInventoryElement(InventoryElement ie)
    {

        if (ReferenceEquals(ie, selectedElement))
        {
            return;
        }

        //Снять предыдущий одетый предмет
        if (selectedElement != null)
            selectedElement.UnequipThisItem();

        //Сохранить надетый предмет
        selectedElement = ie;

        //Надеть выбранный
        selectedElement.EquipThisItem();
    }
}
