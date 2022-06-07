using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionsController : MonoBehaviour
{
    const string ghostTag = "Ghost";

    [SerializeField] bool moveUp;
    [SerializeField] bool moveDown;
    [SerializeField] bool moveRigth;
    [SerializeField] bool moveLeft;

    AnimatorControl animatorControl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ghostTag)
        {
            animatorControl = collision.GetComponent<AnimatorControl>();
            checkPosition(collision.gameObject);
        }
    }

    void checkPosition(GameObject ghost)
    {
        int random = Random.Range(0, 3);

        Debug.Log(random);

        switch (random)
        {
            case 0:

                if (moveUp)
                {
                    animatorControl.Direction = new Vector2(0, 1);
                }
                else
                {
                    checkPosition(ghost);
                }

                break;
            case 1:
                if (moveDown)
                {
                    animatorControl.Direction = new Vector2(0, -1);

                }
                else
                {
                    checkPosition(ghost);
                }
                break;
            case 2:
                if (moveLeft)
                {
                    animatorControl.Direction = new Vector2(-1, 0);
                }
                else
                {
                    checkPosition(ghost);
                }
                break;
            case 3:
                if (moveRigth)
                {
                    animatorControl.Direction = new Vector2(1, 0);
                }
                else
                {
                    checkPosition(ghost);
                }
                break;
        }
    }
}
