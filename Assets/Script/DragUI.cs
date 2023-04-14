using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Image image;
    [SerializeField] Color colorOnHover;
    Color initialColor;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        image = gameObject.GetComponent<Image>();
        if (image == null) return;
        initialColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Pointer Enter");
        image.color = colorOnHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Pointer Exit");
        image.color = initialColor;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.position = initialPosition;
    }
}
