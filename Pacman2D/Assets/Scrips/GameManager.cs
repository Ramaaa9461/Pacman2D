using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> setTotalPointsInLevel;

    [SerializeField] List<GameObject> ghosts;
    [SerializeField] GameObject player;
    [SerializeField] Tilemap tileMap;

    PlayerController playerController;

    private int totalPointsInLevel;
    private TileBase compareTile;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    private void Start()
    {
        PauseGame();

        for (int i = tileMap.cellBounds.xMin; i < tileMap.cellBounds.xMax; i++)
        {
            for (int j = tileMap.cellBounds.yMin; j < tileMap.cellBounds.yMax; j++)
            {
                Vector3Int tilePosition = new Vector3Int(i, j, 0);

                compareTile = tileMap.GetTile(tilePosition);

                if (compareTile != null && compareTile.name == "Points")
                {
                    totalPointsInLevel++;
                }
            }
        }

        setTotalPointsInLevel.Invoke(totalPointsInLevel);
    }

    private void Update()
    {
        for (int i = 0; i < ghosts.Count; i++)
        {
            if (tileMap.WorldToCell(player.transform.position) == tileMap.WorldToCell(ghosts[i].transform.position))
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

            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].GetComponent<AnimatorControl>().ChangeColor(true);
            }

            StartCoroutine(WaitAttack());
        }
    }

    void PlayerGhosthCollision(GameObject ghost)
    {
        if (playerController.CanBeAttacked)
        {
            ghost.transform.position = ghost.GetComponent<Ghost_Movement>().InitialPosition;
            ghost.GetComponent<Entitys_Movement>().ResetPosition();
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
            ghosts[i].GetComponent<Entitys_Movement>().ResetPosition();
        }
            player.GetComponent<Entitys_Movement>().ResetPosition();
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

        for (int i = 0; i < ghosts.Count; i++)
        {
            ghosts[i].GetComponent<AnimatorControl>().ChangeColor(false);
        }
    }
}

