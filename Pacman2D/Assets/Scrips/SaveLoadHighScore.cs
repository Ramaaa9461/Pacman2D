using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadHighScore : MonoBehaviour
{
    const string highScorePath = "HS";

    public void LoadHighScore(ref int highScore)
    {
        if (PlayerPrefs.HasKey(highScorePath)) //Sacar de aca
        {
            highScore = PlayerPrefs.GetInt(highScorePath);
        }
    }
    public void LoadHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt(highScorePath, newHighScore); 
    }



}
