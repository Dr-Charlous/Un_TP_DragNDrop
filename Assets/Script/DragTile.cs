using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragTile : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color colorOnHover;
    [SerializeField] Tilemap tileMap;
    Color initialColor;

    private void Start()
    {
        initialColor = spriteRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.material.color = colorOnHover;
    }

    private void OnMouseExit()
    {
        spriteRenderer.material.color = initialColor;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y)));
    }
}
