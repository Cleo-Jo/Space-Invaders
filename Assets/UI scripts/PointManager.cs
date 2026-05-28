using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    public TMP_Text ScoreText;
    void Start()
    {
       ScoreText.text = "SCoRE: " + score;
    }

    // Update is called once per frame
    
    public void UpdateScore(int points)
    {
        score += points;
        ScoreText.text = "SCoRE: " + score; 
    }
}
