using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Complication", menuName = "Game/ComplicationCurve")]
public class ComplicationCurve : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public AnimationCurve curve;

    public float GetEvaluate(int _key)
    {
        return curve.Evaluate(_key);
    }
}
