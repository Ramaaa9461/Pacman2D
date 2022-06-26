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
    int highScore;
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
        initialPosition = transform.position;
    }

    public void AddPoint()
    {
        score++;
        changeScore.Invoke(score);

        if (score >= highScore)
        {
            highScore = score;
            changeHighScore.Invoke(highScore);
        }
    }
    
    public void subtractLife()
    {
        life--;

        changeLife.Invoke(life);
    }
}