using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckCollisions : MonoBehaviour
{
    [SerializeField] List<GameObject> ghosts;
    [SerializeField] Tilemap tile;

    PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void CompareCollision(TileBase tileBase)
    {
        if (tileBase.name == "Points")
        {
            playerController.AddPoint();
        }
        else if (tileBase.name == "Bonus")
        {
            playerController.CanBeAttacked = true;

            //Pongo a los fantasmas azule

            StartCoroutine(WaitAttack());
        }
    }

    private void Update()
    {
        for (int i = 0; i < ghosts.Count; i++)
        {
            if (tile.WorldToCell(transform.position) == tile.WorldToCell(ghosts[i].transform.position))
            {
                    PlayerGhosthCollision(ghosts[i]);
            }
        }
    }

    void PlayerGhosthCollision(GameObject ghost)
    {
        if (playerController.CanBeAttacked)
        {
            // se destruye el fantasma
            ghost.transform.position = ghost.GetComponent<Ghost_Movement>().initialPosition;
        }
        else
        {
            //gameObject.SetActive(false);
            playerController.subtractLife();
            ResetPositions();
        }
    }

    void ResetPositions()
    {
        transform.position = tile.WorldToCell( playerController.initialPosition);
        for (int i = 0; i < ghosts.Count; i++)
        {
            ghosts[i].transform.position = tile.WorldToCell( ghosts[i].GetComponent<Ghost_Movement>().initialPosition);
        }
    }

    IEnumerator WaitAttack()
    {
        //animacion azul

        yield return new WaitForSeconds(5f);
        playerController.CanBeAttacked = false;
        //Los vuelvo a su color original
    }
}

