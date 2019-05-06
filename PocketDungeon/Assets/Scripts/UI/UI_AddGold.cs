using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_AddGold : MonoBehaviour
{
    [SerializeField] private FloatVariable gold;
    public UnityEvent OnGoldChanges;

    public void AddGold()
    {
        gold.Value += 1000;
        OnGoldChanges.Invoke();
    }
}
