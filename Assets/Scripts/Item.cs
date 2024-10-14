using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
  [CanBeNull] public string ItemName;
  public Sprite ItemSprite;
  public ItemType Type;
  public bool CanDrop;
  
  public enum ItemType
  {
    Weapon,
    Consumable,
    Runes
  }
  
}
