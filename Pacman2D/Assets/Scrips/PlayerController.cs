using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI highScore_text;
    [SerializeField] Image[] lifes;

    const string highScorePath = "HS";

    int score = 0;
    int highSocre;
    Vector2 initialPosition;
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

        if (score >= highSocre)
        {
            highSocre = score;
        }
    }

    private void Update()
    {
        score_text.text = (score).ToString();
        highScore_text.text = (highSocre).ToString();
    }
    
    public void subtractLife()
    {
        life--;

        if (life <= 0)
        {
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt(highScorePath, highSocre);
        }

        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].enabled = false;
        }
        for (int i = 0; i < life; i++)
        {
            lifes[i].enabled = true;
        }
    }
}