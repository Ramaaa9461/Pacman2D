using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Entitys_Movement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Tilemap tile;
    Vector2 direction;

    public Vector2 Direction
    {
        get { return direction; }
        private set { direction = value; }
    }

    void Update()
    {
        Vector2 newPosition = checkFreeCell(direction);

        transform.position = newPosition;
    }

    public void moveToDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    Vector2 checkFreeCell(Vector2 direction)
    {
        Vector3Int cellPos = tile.WorldToCell(transform.position);
        Vector3Int dir = new Vector3Int(Mathf.RoundToInt(direction.normalized.x), Mathf.RoundToInt(direction.normalized.y));
        Vector2 pos = transform.position;

        cellPos += dir;
        TileBase tileBase = tile.GetTile(cellPos);


        if (tileBase == null)
        {
            pos = tile.CellToWorld(cellPos);
        }
        else
        {
            Direction = Vector2.zero;
        }

        return pos;
    }

   

    //private void OnDrawGizmos()
    //{
    //    GUIStyle style = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
    //    style.fontSize = 20;
    //    style.normal.textColor = Color.yellow;
    //    Vector3Int cellPos = tile.WorldToCell(transform.position);

    //    Handles.Label(transform.position, $"Position { cellPos }", style);
    //}
}
