using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if (GameData.items == null)
        {
            GameData.items = new List<Item>();
        }
        LoadInventory();
        Debug.Log("Inventory after load: " + string.Join(", ", GameData.items));
    }

    private void Start()
    {
        SaveInventory();
        Debug.Log("Inventory at start: " + string.Join(", ", GameData.items));
    }

    public void AddItem(Item item)
    {
        GameData.items.Add(item);
        SaveInventory();
        Debug.Log("Item added: " + item.ToString());
    }

    public void RemoveItem(Item item)
    {
        GameData.items.Remove(item);
        SaveInventory();
        Debug.Log("Item removed: " + item.ToString());
    }

    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(new Serialization<List<Item>>(GameData.items));
        PlayerPrefs.SetString("Inventory", json);
        PlayerPrefs.Save();
        Debug.Log("Inventory saved: " + json);
    }

    public void LoadInventory()
    {
        if (PlayerPrefs.HasKey("Inventory"))
        {
            string json = PlayerPrefs.GetString("Inventory");
            GameData.items = JsonUtility.FromJson<Serialization<List<Item>>>(json).ToList();
            Debug.Log("Inventory loaded: " + json);
        }
        else
        {
            Debug.Log("No inventory data found.");
        }
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }
}

public static class GameData
{
    public static List<Item> items = new List<Item>();
}

[System.Serializable]
public class Serialization<T>
{
    public T target;
    public Serialization(T target)
    {
        this.target = target;
    }

    public List<Item> ToList()
    {
        return target as List<Item>;
    }
}

