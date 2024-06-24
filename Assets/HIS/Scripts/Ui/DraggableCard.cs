using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private GameObject dropZone;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (dropZone.CompareTag(tag)) 
        {
            transform.SetParent(dropZone.transform);  
        }
        else
        {
            transform.SetParent(originalParent);  
        }

        transform.localPosition = Vector3.zero; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))  
        {
            dropZone = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))  
        {
            dropZone = null;
        }
    }
}
