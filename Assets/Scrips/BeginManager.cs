using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeginManager : MonoBehaviour
{
    //variable para puntaje
    public int score;
    public int soulCount;
    public TextMeshProUGUI soulText;

    public TextMeshProUGUI ScoreText;
    
    public TextMeshProUGUI LifeText;

    public TextMeshProUGUI ScoreFinal;
    

    private void Start()
    {
        soulText.text = " " + soulCount;
        ScoreText.text = "Score: " + score;
        ScoreFinal.text = "Score: " + score;


    }

    //Añade
    public void UpdateSoul(int soul)
    {
        soulCount += soul;

        soulText.text = " " + soulCount;

    }


    public void UpdateScore(int newScore)
    {
        score += newScore;

        ScoreText.text = "Score: " + score;
        ScoreFinal.text = "Score: " + score;

    }

    public void UpdateLifes (int lifes)
    {
        LifeText.text = " " + lifes.ToString();
    }
}
