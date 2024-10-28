using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [CanBeNull] public string ItemName;
    public Sprite ItemSprite;
    public ItemType Type;
    public bool CanDrop;
    public float ItemPrice = 10;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Runes
    }
}