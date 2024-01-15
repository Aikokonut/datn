using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform r;
    private CanvasGroup canvasGroup;
    private Vector3 resetpos;
    private void Awake()
    {
        r= GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
    }
    void Start()
    {
        resetpos = this.transform.localPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("on");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("in");
        r.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter == null || !eventData.pointerEnter.CompareTag("DropBlock"))
        {
            this.transform.localPosition = resetpos;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("dd");
    }
    
}
    
