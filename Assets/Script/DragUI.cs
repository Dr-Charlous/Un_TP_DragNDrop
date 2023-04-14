using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class DragUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Image image;
    [SerializeField] Color colorOnHover;
    Color initialColor;
    //Vector3 initialPosition;
    RectTransform rectTransform;
    Vector2 initialPosition;
    Canvas canvas;

    void Start()
    {
        //initialPosition = transform.position;
        image = gameObject.GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (image == null) return;
        initialColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("Pointer Enter");
        image.color = colorOnHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("Pointer Exit");
        image.color = initialColor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //gameObject.transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //gameObject.transform.position = initialPosition;
        rectTransform.anchoredPosition = initialPosition;
    }
}