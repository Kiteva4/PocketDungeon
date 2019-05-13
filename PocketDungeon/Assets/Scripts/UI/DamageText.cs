using System.Collections;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private static DamageShower _damageShower;
    private static DamageShower damageShower
    {
        get
        {
            if (_damageShower == null)
                _damageShower = FindObjectOfType<DamageShower>();
            return _damageShower;
        }
    }

    private Animation anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animation>();
    }

    private void OnEnable()
    {
        StartCoroutine(EndAnim());
    }

    private IEnumerator EndAnim()
    {
        yield return new WaitUntil(() => !anim.isPlaying);
        damageShower.ReturnToPool(gameObject);
    }
}
