using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{
    public Inventory Inventory;
    public Vector2 cellSize;
    public Sprite CellSpriteEmpty;
    public RectTransform RectTransform;
    public int YCells;
    public int XCells;
    private Image[] _images;

    public void RenderGrid()
    {
        Debug.Log("RenderGrid called");
        // Clear existing cells
        foreach (Transform child in RectTransform)
        {
            Destroy(child.gameObject);
        }

        // Render empty cells grid
        for (int i = 0; i < YCells; i++)
        {
            for (int j = 0; j < XCells; j++)
            {
                var go = new GameObject();
                var rectTransform = go.AddComponent<RectTransform>();
                go.AddComponent<Image>();
                rectTransform.sizeDelta = cellSize;
                go.GetComponent<Image>().sprite = CellSpriteEmpty;
                rectTransform.SetParent(RectTransform, false);

                // Position the cell within the grid
                rectTransform.anchoredPosition = new Vector2(j * cellSize.x, -i * cellSize.y);

                Debug.Log($"Created empty cell at ({i}, {j})");
            }
        }

// Render items on top of the empty cells
        for (int i = 0; i < YCells; i++)
        {
            for (int j = 0; j < XCells; j++)
            {
                int index = i * XCells + j;
                if (index < Inventory.items.Count)
                {
                    var item = Inventory.items[index];
                    var go = new GameObject();
                    var rectTransform = go.AddComponent<RectTransform>();
                    go.AddComponent<Image>();
                    rectTransform.sizeDelta = cellSize;
                    go.GetComponent<Image>().sprite = item.ItemSprite;
                    rectTransform.SetParent(RectTransform, false);

                    // Position the item within the grid
                    rectTransform.anchoredPosition = new Vector2(j * cellSize.x, -i * cellSize.y);

                    Debug.Log($"Created item cell at ({i}, {j}) with item {item.ItemName}");
                }
            }
        }
    }
}