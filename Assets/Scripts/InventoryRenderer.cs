using System.Collections.Generic;
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

    // Liste de listes pour stocker les cellules
    private List<List<Cell>> cells;

    public void RenderGrid()
    {
        Debug.Log("RenderGrid called");
        // Clear existing cells
        foreach (Transform child in RectTransform)
        {
            Destroy(child.gameObject);
        }

        // Initialiser la liste de listes des cellules
        cells = new List<List<Cell>>();

        // Render empty cells grid
        for (int i = 0; i < YCells; i++)
        {
            cells.Add(new List<Cell>());
            for (int j = 0; j < XCells; j++)
            {
                var cell = new Cell(cellSize, CellSpriteEmpty);
                cell.RectTransform.SetParent(RectTransform, false);

                // Position the cell within the grid
                cell.RectTransform.anchoredPosition = new Vector2(j * cellSize.x, -i * cellSize.y);

                // Store the cell in the list
                cells[i].Add(cell);

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
                    cells[i][j].AddItem(item);

                    Debug.Log($"Created item cell at ({i}, {j}) with item {item.ItemName}");
                }
            }
        }
    }

    // Méthode pour obtenir la cellule à une position donnée
    public Cell GetCell(int row, int col)
    {
        if (row >= 0 && row < YCells && col >= 0 && col < XCells)
        {
            return cells[row][col];
        }
        return null;
    }

    // Méthode pour obtenir la position d'une cellule
    public Vector2 GetCellPosition(int row, int col)
    {
        return new Vector2(col * cellSize.x, -row * cellSize.y);
    }
}

public class Cell
{
    public RectTransform RectTransform { get; private set; }
    public Item Item { get; private set; }

    public Cell(Vector2 size, Sprite emptySprite)
    {
        var go = new GameObject();
        RectTransform = go.AddComponent<RectTransform>();
        var image = go.AddComponent<Image>();
        go.AddComponent<DropHandler>();
        RectTransform.sizeDelta = size;
        image.sprite = emptySprite;
    }

    public void AddItem(Item item)
    {
        Item = item;
        var go = new GameObject();
        var rectTransform = go.AddComponent<RectTransform>();
        go.AddComponent<CanvasGroup>();
        go.AddComponent<DragNDrop>();
        go.AddComponent<Image>();
        rectTransform.sizeDelta = RectTransform.sizeDelta;
        go.GetComponent<Image>().sprite = item.ItemSprite;
        rectTransform.SetParent(RectTransform, false);

        // Position the item within the grid
        rectTransform.anchoredPosition = Vector2.zero;
    }
}
