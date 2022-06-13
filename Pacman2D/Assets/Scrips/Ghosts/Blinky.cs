using UnityEngine;
using UnityEngine.AI;

public class Blinky : Ghost_Movement
{
    void Update()
    {
        if (body.velocity.magnitude < 1)
        {
            calculateDirection();
            entitys_movement.moveToDirection(direction);
        }
    }

    void calculateDirection()
    {
        switch (Random.Range(0, 4))
        {
            case 0:

                direction = new Vector2(1, 0);

                break;
            case 1:

                direction = new Vector2(-1, 0);

                break;
            case 2:

                direction = new Vector2(0, 1);

                break;
            case 3:

                direction = new Vector2(0, -1);
                break;
        }
    }
}
