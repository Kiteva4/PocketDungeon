using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageShower : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private int maxObjectOnPool;
    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();

    private static Transform cameraT;
    private int currentIndex;

    private void Awake()
    {
        currentIndex = 0;
        cameraT = Camera.main.GetComponent<Transform>();
        PoolInit();
    }

    private void PoolInit()
    {
        for (int i = 0; i < maxObjectOnPool; i++)
        {
            pool.Enqueue(Instantiate(textPrefab, parentTransform));
            //Debug.Log("Enqueue");
        }
    }

    GameObject GetGoFromPool()
    {
        if (pool.Count > 0)
        {
            currentIndex++;

            if (currentIndex >= pool.Count)
            {
                currentIndex = 0;
            }

            //Debug.Log("Deueue");
            return pool.Dequeue();
        }

        return null;
    }

    public void ShowDamage(Color color, float amount)
    {
        GameObject go = GetGoFromPool();

        if (go != null)
        {
            go.GetComponentInChildren<TextMeshProUGUI>().color = color;
            go.GetComponentInChildren<TextMeshProUGUI>().text = amount.Converter();

            go.transform.localPosition = Vector2.zero + Random.insideUnitCircle * Screen.width * 0.3f;
            go.SetActive(true);
            return;
        }
        //Debug.Log("poll returned null");
    }

    public void ReturnToPool(GameObject go)
    {
        pool.Enqueue(go);
        go.SetActive(false);
        //Debug.Log("falsed");
    }
}