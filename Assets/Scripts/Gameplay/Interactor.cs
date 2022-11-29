using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnMouseDown()
    {
        Score.AddScore(10);
        this.gameObject.SetActive(false);
    }
}
