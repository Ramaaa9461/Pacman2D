using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ghosts;
    [SerializeField] GameObject player;
    [SerializeField] Tilemap tile;

    PlayerController playerController;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    private void Start()
    {
        PauseGame();
    }

    private void Update()
    {
        for (int i = 0; i < ghosts.Count; i++)
        {
            if (tile.WorldToCell(player.transform.position) == tile.WorldToCell(ghosts[i].transform.position))
            {
                PlayerGhosthCollision(ghosts[i]);
            }
        }
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

            //Pongo a los fantasmas azules

            StartCoroutine(WaitAttack());
        }
    }

    void PlayerGhosthCollision(GameObject ghost)
    {
        if (playerController.CanBeAttacked)
        {
            ghost.transform.position = ghost.GetComponent<Ghost_Movement>().InitialPosition;
        }
        else
        {
            playerController.subtractLife();
            ResetPositions();
        }
    }

    void ResetPositions()
    {
        player.transform.position = playerController.InitialPosition;

        for (int i = 0; i < ghosts.Count; i++)
        {
            ghosts[i].transform.position = ghosts[i].GetComponent<Ghost_Movement>().InitialPosition;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(5f);
        playerController.CanBeAttacked = false;
        //Los vuelvo a su color original
    }
}

