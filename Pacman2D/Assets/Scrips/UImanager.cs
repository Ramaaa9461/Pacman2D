using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI highScore_text;
    [SerializeField] Image[] lifes;

    const string highScorePath = "HS";


    void Start()
    {
        if (PlayerPrefs.HasKey(highScorePath)) //Sacar de aca
        {
           // highSocre = PlayerPrefs.GetInt(highScorePath);
        }

        score_text.text = "0";
        highScore_text.text = "0";
    }

    public void ChangeTheScore(int newScore)
    {
        score_text.text = (newScore).ToString();
    }
    public void ChangeTheHighScore(int newHighScore)
    {
        highScore_text.text = (newHighScore).ToString();
    }

    public void restLife(int newLife)
    {
        if (newLife <= 0)
        {
            gameOverPanel.SetActive(true);
            //  PlayerPrefs.SetInt(highScorePath, highSocre); //Sacar de aca
        }

        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].enabled = false;
        }
        for (int i = 0; i < newLife; i++)
        {
            lifes[i].enabled = true;
        }
    }
}
