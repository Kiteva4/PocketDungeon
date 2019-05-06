using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    //public static void SaveData(string id, int level)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/player.data";

    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    InventoryItem data = new InventoryItem(id, level);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    //public static InventoryItem LoadInventoryItem()
    //{
    //    string path = Application.persistentDataPath + "/player.data";

    //    if(File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        InventoryItem data = formatter.Deserialize(stream) as InventoryItem;
    //        stream.Close();

    //        return data;
    //    }

    //    else
    //    {
    //        Debug.LogError("SaVE file not found in" + path);
    //        return null;
    //    }
    //}

    public static SaveData saveData;

    public GameInventoryData weaponList; 
    public GameInventoryData headList; 
    public GameInventoryData chestList; 
    public GameInventoryData legsList; 

    private void Awake()
    {
        LoadData();
        Debug.Log("Load");
    }

    [ContextMenu("Save Data")]
    public void SaveGame()
    {
        saveData.weaponsData = weaponList.inventoryItems;
        saveData.headsData = headList.inventoryItems;
        saveData.chestData = chestList.inventoryItems;
        saveData.legsData = legsList.inventoryItems;

        var data = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("GameData", data);
    }

    [ContextMenu("Load Data")]
    public void LoadData()
    {
        var data = PlayerPrefs.GetString("GameData");
        saveData = JsonUtility.FromJson<SaveData>(data);

        weaponList.inventoryItems   = saveData.weaponsData;
        headList.inventoryItems     = saveData.headsData;
        chestList.inventoryItems    = saveData.chestData;
        legsList.inventoryItems     = saveData.legsData;
    }

    private void OnDisable()
    {
        SaveGame();
        //Debug.Log("OnDisable Save");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        //Debug.Log("OnApplicationQuit Save");
    }
}
