using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public RectTransform GridParent;

    private void Awake()
    {
        RenderGrid();
    }

    private void RenderGrid()
    {
        Debug.Log("RenderGrid called");

        // Get all child slots from the GridParent
        int slotIndex = 0;
        foreach (Transform slot in GridParent)
        {
            if (slotIndex < GameData.items.Count)
            {
                var item = GameData.items[slotIndex];
                AddItemToSlot(slot, item);
                Debug.Log($"Added item {item.ItemName} to slot {slotIndex}");
            }
            slotIndex++;
        }
    }

    private void AddItemToSlot(Transform slot, Item item)
    {
        var itemGO = new GameObject("Item");
        var rectTransform = itemGO.AddComponent<RectTransform>();
        var image = itemGO.AddComponent<Image>();
        itemGO.AddComponent<CanvasGroup>();
        itemGO.AddComponent<DragNDrop>();

        rectTransform.sizeDelta = slot.GetComponent<RectTransform>().sizeDelta;
        image.sprite = item.ItemSprite;
        rectTransform.SetParent(slot, false);

        // Position the item within the slot
        rectTransform.anchoredPosition = Vector2.zero;
    }
}