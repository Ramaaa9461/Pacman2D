using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Entitys_Movement : MonoBehaviour
{
    GameObject menu;
    [SerializeField] float speed = 10;
    CheckCollisions checkCollisions;
    [SerializeField] Tilemap tile;
    Vector2 direction;

    public Vector2 Direction
    {
        get { return direction; }
        private set { direction = value; }
    }

    private void Awake()
    {
        checkCollisions = GetComponent<CheckCollisions>();
        menu = GameObject.Find("Menu");
    }
    void Start()
    {
        Movement();
        //transform.position = newPosition;
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
            if (tileBase.name == "Wall")
            {
                Direction = Vector2.zero;
            }
            else
            {
                if (gameObject.CompareTag("Player"))
                {
                    checkCollisions.CompareCollision(tileBase);
                    tile.SetTile(cellPos, null);
                }
                pos = tile.CellToWorld(cellPos);
            }
        }



        return pos;

    }

    async void Movement()
    {
        Task task;

        Vector2 newPosition = checkFreeCell(direction);

        task = MoveToNewPosition(newPosition);

        await Task.WhenAll(task);

        Movement();
    }

    async Task MoveToNewPosition(Vector2 nextPosition)
    {
        float progress = 0;

        while (progress < 1)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, progress);
            progress += Time.deltaTime * speed;
            await Task.Yield();
        }
    }



    private void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
        style.fontSize = 20;
        style.normal.textColor = Color.yellow;
        Vector3Int cellPos = tile.WorldToCell(transform.position);

        Handles.Label(transform.position, $"Position { cellPos }", style);
    }
}
