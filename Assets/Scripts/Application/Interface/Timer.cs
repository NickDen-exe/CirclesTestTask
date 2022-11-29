using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float playtime = 0;
    Text timerCounter;

    void Start()
    {
        playtime = 0;
        timerCounter = GetComponent<Text>();
    }

    void Update()
    {
        playtime += Time.deltaTime;
        timerCounter.text = "Time: " + playtime;
    }
}
