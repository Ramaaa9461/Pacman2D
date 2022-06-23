using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{ 
    public UnityEvent<int> changeScore;
    public UnityEvent<int> changeHighScore;
    public UnityEvent<int> changeLife;

    const string highScorePath = "HS";

    Vector2 initialPosition;
    int score = 0;
    int highSocre;
    int life = 3;
    bool canBeAttacked = false;

    public Vector2 InitialPosition
    {
        get { return initialPosition; }
        set { initialPosition = value; }
    }

    public bool CanBeAttacked
    {
        get { return canBeAttacked; }
        set { canBeAttacked = value; }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(highScorePath))
        {
            highSocre = PlayerPrefs.GetInt(highScorePath);
        }

        initialPosition = transform.position;
    }

    public void AddPoint()
    {
        score++;
        changeScore.Invoke(score);

        if (score >= highSocre)
        {
            highSocre = score;
            changeHighScore.Invoke(highSocre);
        }
    }
    
    public void subtractLife()
    {
        life--;

        changeLife.Invoke(life);
    }
}