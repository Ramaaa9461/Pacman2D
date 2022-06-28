using UnityEngine;
using UnityEngine.Events;

public class SaveLoadHighScore : MonoBehaviour
{
    const string highScorePath = "HS";
    public UnityEvent<int> loadHighScore;

    public void LoadHighScore()
    {
        int highScore = 0;

        if (PlayerPrefs.HasKey(highScorePath))
        {
            highScore = PlayerPrefs.GetInt(highScorePath);
        }

        loadHighScore.Invoke(highScore); //Asignarlo a UI y al personaje
    }

    public void SaveHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt(highScorePath, newHighScore);
    }



}
