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
    int life = 3;
    public Vector2 initialPosition;
    bool canBeAttacked = false;
    
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

        if (life <= 0)
        {
            PlayerPrefs.SetInt(highScorePath, highSocre);
        }
    }
    
    public void subtractLife()
    {
        life--;

        if (life <= 0)
        {
            gameOverPanel.SetActive(true);
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
