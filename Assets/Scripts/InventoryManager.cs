using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public InventoryRenderer inventoryRenderer;
    public GameObject inventoryPanel;

    public bool InventoryOpen { get; private set; }

    public bool OpenInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryRenderer.RenderGrid();
        return InventoryOpen = true;
    }

    public bool CloseInventory()
    {
        inventoryPanel.SetActive(false);
        return InventoryOpen = false;
    }
}