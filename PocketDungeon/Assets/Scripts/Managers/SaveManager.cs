using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
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


    public static SaveData save = new SaveData();

    private string path;

    #region MonoBehaviout
    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            Debug.Log("weapons count: " + save.inventoryData.weapons.Count);
            Debug.Log("heads count: " + save.inventoryData.heads.Count);
            Debug.Log("chests count: " + save.inventoryData.chests.Count);
            Debug.Log("legs count: " + save.inventoryData.legs.Count);
        }
        else
        {
            Debug.Log("InitLoad");
            InitSaves();
        }
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

    /// <summary>
    /// При отсутствии файла сохранений при первом запуске игры
    /// </summary>
    public void InitSaves()
    {
        lootManager.InitPlayerEquipments();
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
