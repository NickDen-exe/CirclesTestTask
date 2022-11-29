using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private static int scoreValue = 0;
    private Text score;

    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    public static void AddScore(int scoreToAdd) 
    {
        scoreValue += scoreToAdd;
    }
}
