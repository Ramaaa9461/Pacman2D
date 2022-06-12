using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    Vector2 direction;
    Entitys_Movement entitys_movement;

    private void Awake()
    {
        entitys_movement = GetComponent<Entitys_Movement>();
    }
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        entitys_movement.moveToDirection(direction);
    }
}
