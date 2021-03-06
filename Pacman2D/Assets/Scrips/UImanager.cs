using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI titleGameOverPanel;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI highScore_text;
    [SerializeField] Image[] lifes;

    public UnityEvent loadHighScore;
    public UnityEvent<int> saveHighScore;

    int highScore = 0;
    int maxPointToWin;
    void Start()
    {
        loadHighScore.Invoke();

        highScore_text.text = highScore.ToString();

        score_text.text = "0";
    }

    public void RecibeMaxPointsToWin(int totalPoints)
    {
        maxPointToWin = totalPoints;
    }

    public void AssignHighScore(int HighScore)
    {
        highScore = HighScore;
    }

    public void ChangeTheScore(int newScore)
    {
        score_text.text = (newScore).ToString();

        if (newScore >= maxPointToWin) 
        {
            gameOverPanel.SetActive(true);
            titleGameOverPanel.text = "You Win";
            saveHighScore.Invoke(highScore);
        }
    }

    public void ChangeTheHighScore(int newHighScore)
    {
        highScore_text.text = (newHighScore).ToString();
        highScore = newHighScore;
    }

    public void restLife(int newLife)
    {
        if (newLife <= 0)
        {
            gameOverPanel.SetActive(true);
            titleGameOverPanel.text = "Game Over";
            saveHighScore.Invoke(highScore);
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
