using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int totalScore = 0;
    bool calculated;

    void Awake()
    {
        score = totalScore;
        calculated = false;
    }

    static public void ScoreUp(int value)
    {        
        score += value;
        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.GetComponent<UIController>().UpdateScore(score);
    } 

    static public int GetScore()
    {
        return score;
    }

    void Update()
    {
        if (GameManager.gameState == GameState.retry && !calculated)
        {
            score = totalScore;
            calculated = true;
        }
        else if(GameManager.gameState == GameState.result && !calculated)
        {
            totalScore = score;
            calculated = true;
        }
    }
}
