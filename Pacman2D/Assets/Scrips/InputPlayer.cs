using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    Entitys_Movement entitys_movement;

    private void Awake()
    {
        entitys_movement = GetComponent<Entitys_Movement>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            entitys_movement.moveToDirection(direction);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            entitys_movement.moveToDirection(direction);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            entitys_movement.moveToDirection(direction);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            entitys_movement.moveToDirection(direction);
        }

    }
}
