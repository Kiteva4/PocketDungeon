using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerTap;
    private delegate void PlayerTap();
    private PlayerTap PlayerTapEvent;

    private void Awake()
    {
        PlayerTapEvent = HandlerOnPlayerTap;
    }

    private void Update()
    {
        PlayerTapEvent?.Invoke();
    }

    private void HandlerOnPlayerTap()
    {
#if !UNITY_EDITOR
        if(Input.touchCount > 0 )
        {
            Debug.Log("Tap");
            OnPlayerTap?.Invoke();
            PlayerTapEvent = HandlerOnPlayerUntap;
        }
#else

        if (Input.anyKeyDown)
        {
            //Debug.Log("Tap");
            OnPlayerTap?.Invoke();
            PlayerTapEvent = HandlerOnPlayerUntap;
        }

#endif

    }

    private void HandlerOnPlayerUntap()
    {
#if !UNITY_EDITOR
        if(Input.touchCount == 0 )
        {
            Debug.Log("Tap");
            PlayerTapEvent = HandlerOnPlayerTap;
        }
#else

        if (!Input.anyKey)
        {
            //Debug.Log("Untap");
            PlayerTapEvent = HandlerOnPlayerTap;
        }
#endif
    }
}
