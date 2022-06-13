using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckCollisions : MonoBehaviour
{
    const string pointTag = "Points";
    const string bonusTag = "Bonus";
    const string ghostTag = "Ghost";

    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == pointTag)
        {
            playerController.AddPoint();
        }
        if (collision.tag == bonusTag)
        {
            playerController.IsAttack();
        }

        Destroy(collision.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ghostTag)
        {
            if (playerController.CanBeAttacked)
            {
                // se destruye el fantasma
                collision.gameObject.SetActive(false);
                
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
