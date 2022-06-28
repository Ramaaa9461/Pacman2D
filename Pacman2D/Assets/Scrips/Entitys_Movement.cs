using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Entitys_Movement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Tilemap tile;
    [SerializeField] GameManager gameManager;
    Vector2 direction;

    float progress = 0;
    bool movement = false;

    Vector2 currentPos;
    Vector2 nextPosition;

    public Vector2 Direction
    {
        get { return direction; }
        private set { direction = value; }
    }

    private void Update()
    {
        if (movement)
        {
            transform.position = Vector3.Lerp(currentPos, nextPosition, progress);
            progress += Time.deltaTime * speed;

            if (progress >= 1.0f)
            {
                progress = 0.0f;
                transform.position = nextPosition;
                movement = false;
                ExecuteMovement();
            }
        }
    }

    public void moveToDirection(Vector2 direction)
    {
        this.direction = direction;

        if (!movement)
        {
            ExecuteMovement();
        }
    }

    void ExecuteMovement()
    {
        currentPos = transform.position;
        nextPosition = checkFreeCell(direction);

        movement = true;
    }

    Vector2 checkFreeCell(Vector2 direction)
    {
        Vector3Int cellPos = tile.WorldToCell(transform.position);
        Vector3Int dir = new Vector3Int(Mathf.RoundToInt(direction.normalized.x), Mathf.RoundToInt(direction.normalized.y));
        Vector2 pos = transform.position;
        
        cellPos += dir;
        TileBase tileToGo = tile.GetTile(cellPos);

        if (tileToGo == null)
        {
            pos = tile.CellToWorld(cellPos);
        }
        else
        {
            if (tileToGo.name == "Wall")
            {
                Direction = Vector2.zero;
            }
            else
            {
                if (gameObject.CompareTag("Player"))
                {
                    gameManager.CompareCollision(tileToGo);
                    tile.SetTile(cellPos, null);
                }
                pos = tile.CellToWorld(cellPos);
            }
        }

        return pos;
    }

    public void ResetPosition()
    {
        direction = Vector2.zero;
        currentPos = transform.position;
        nextPosition = transform.position;
    }

    //async void Movement()
    //{
    //    Task task;

    //    Vector2 newPosition = checkFreeCell(direction);

    //    task = MoveToNewPosition(newPosition);

    //    await Task.WhenAll(task);

    //    Movement();
    //}

    //async Task MoveToNewPosition(Vector2 nextPosition)
    //{
    //    float progress = 0;

    //    while (progress < 1)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, nextPosition, progress);
    //        progress += Time.deltaTime * speed;
    //        await Task.Yield();
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    GUIStyle style = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
    //    style.fontSize = 20;
    //    style.normal.textColor = Color.yellow;
    //    Vector3Int cellPos = tile.WorldToCell(transform.position);

    //    Handles.Label(transform.position, $"Position { cellPos }", style);
    //}
}
