using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button stop;
    [SerializeField] private GameObject stats;
   
    void Start()
    {
        Time.timeScale = 0;    
    }

    public void StartGame() 
    {
        Time.timeScale = 1;
        play.gameObject.SetActive(false);
        stop.gameObject.SetActive(true);
        stats.SetActive(true);
    }

    public void StopGame() 
    {
        SceneManager.LoadScene(0);
    }
}
