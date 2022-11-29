using System.Collections;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float moveSpeed;

    void Update()
    {
        MoveCircle();
    }

    public void SetDefaultSize() 
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private float GetCircleSize()
    {
        return this.transform.localScale.x;
    }

    public void SetCircleSpeed()
    {
        moveSpeed = (-1f) * (2f / GetCircleSize());
    }
    void MoveCircle()
    {
        Vector3 changePos = new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        this.transform.position += changePos;  
    }
}
