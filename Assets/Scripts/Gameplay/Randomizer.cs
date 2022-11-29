using UnityEngine;

public class Randomizer
{
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 3f;

    public float GetRandomScale() 
    {
        return Random.Range(minScale, maxScale);
    }

    public Color32 GetRandomColor() 
    {
        Color col = new Color(
            Random.Range(0.5f, 1f),
            Random.Range(0.5f, 1f),
            Random.Range(0.5f, 1f));
        return col;
    }

    public void Randomize(Circle obj) 
    {
        obj.GetComponent<SpriteRenderer>().color = GetRandomColor();
        var tempScale = GetRandomScale();
        obj.transform.localScale *= tempScale;
        obj.GetComponent<Circle>().SetCircleSpeed();
    }
}
