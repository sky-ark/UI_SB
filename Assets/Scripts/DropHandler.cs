using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        // Vérifiez si l'objet déposé n'est pas nul
        if (eventData.pointerDrag != null)
        {
            // Stockez la position initiale de l'objet déposé
            Vector2 initialPosition = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
            Transform initialParent = eventData.pointerDrag.transform.parent;

            // Vérifiez si l'emplacement cible a déjà un enfant
            if (transform.childCount == 0)
            {
                // Repositionnez l'objet déposé
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                Debug.Log("Object dropped successfully");
            }
            else
            {
                // Remplacez l'objet déposé par son ancienne position
                eventData.pointerDrag.transform.SetParent(initialParent);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                Debug.Log("Drop location already has a child. Drag and drop canceled.");
            }
        }
    }
}