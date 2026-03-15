using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    // Ja lieto tipu pārbaudi
    public ItemType acceptedType;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem == null) return;

        DragItem dragItem = droppedItem.GetComponent<DragItem>();
        if (dragItem == null) return;

        // Tipu pārbaude (ja nepieciešams)
        if (dragItem.itemType != acceptedType)
            return; // nepareizs tips – neko nedara, priekšmets atgriezīsies sākotnējā vietā

        // Ja slotā jau ir priekšmets, IZNĪCINĀM to
        if (transform.childCount > 0)
        {
            Transform oldItem = transform.GetChild(0);
            Destroy(oldItem.gameObject); // vecais priekšmets pazūd pavisam
        }

        // Ievieto jauno priekšmetu slotā
        droppedItem.transform.SetParent(transform);
        droppedItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        // Pēc ievietošanas var atjaunot blocksRaycasts (to jau dara DragItem)
        // Bet svarīgi – ja priekšmets tika iznīcināts, tam vairs nav atsauču
    }
}