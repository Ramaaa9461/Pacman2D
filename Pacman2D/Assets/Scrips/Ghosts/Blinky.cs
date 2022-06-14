using UnityEngine;
using UnityEngine.AI;

public class Blinky : Ghost_Movement
{
    void Update()
    {
        if (entitys_movement.Direction.magnitude == 0)
        {
            calculateDirection();
            entitys_movement.moveToDirection(direction);
        }
            Debug.Log(entitys_movement.Direction.magnitude);
    }

    void calculateDirection()
    {
        switch (Random.Range(0, 4))
        {
            case 0:

                direction = Vector2.up;

                break;
            case 1:

                direction = Vector2.down;

                break;
            case 2:

                direction =Vector2.left;

                break;
            case 3:

                direction = Vector2.right;
                break;
        }
    }
}
