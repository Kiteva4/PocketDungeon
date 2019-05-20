using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class SaveManager : MonoBehaviour
{
    [SerializeField] protected UnityEvent OnGpdateGold;

    private LootManager _lootManager;
    private LootManager lootManager
    {
        get
        {
            if (_lootManager == null)
                _lootManager = FindObjectOfType<LootManager>();
            return _lootManager;
        }
    }

    private ArmyManager _armyManager;
    private ArmyManager armyManager
    {
        get
        {
            if (_armyManager == null)
                _armyManager = FindObjectOfType<ArmyManager>();
            return _armyManager;
        }
    }

    public static SaveData save = new SaveData();

    private string path;

    #region MonoBehaviout
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif

        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            lootManager.InitPlayerEquipments();
        }

        else
        {
            Debug.Log("InitLoad");
            lootManager.CollectFirstEquipments();
            lootManager.InitBoxList();
            GetFirstCurrencies();
            armyManager.InitArmiesUnit();
        }
        lootManager.InitBoxController();
        lootManager.InitEquipLoadedItems();
        armyManager.WakeUpArmy();
    }
#if UNITY_ANDROID && !UNITY_EDITOR

    private void OnApplicationPause(bool pause)
    {
        if(pause) 
            SaveGame();      
    }
#endif
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    #endregion

    public void GetFirstCurrencies()
    {
        save.goldCount = 10f;
        OnGpdateGold?.Invoke();
    }

    [ContextMenu("Save Data")]
    public void SaveGame()
    {
        File.WriteAllText(path, JsonUtility.ToJson(save));
        Debug.Log("Saving");
    }

    [ContextMenu("Load Data")]
    public void LoadData()
    {
        save = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
        Debug.Log("Loading");
    }
}
