using System.Collections.Generic;
using UnityEngine;

public class CirclesPool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;

    public CirclesPool(T prefab, int count) 
    {
        this.prefab = prefab;
        this.container = null;
        this.CreatePool(count);
    }

    public CirclesPool(T prefab, int count, Transform container) 
    {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(count);
    }

    private void CreatePool(int count) 
    {
        this.pool = new List<T>();
        for (int i = 0; i < count; i++) 
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false) 
    {
        var createdObj = Object.Instantiate(this.prefab, this.container);
        createdObj.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObj);
        return createdObj;
    }

    public bool HasFreeElement(out T element) 
    {
        foreach (var mono in pool) 
        {
            if (!mono.gameObject.activeInHierarchy) 
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement() 
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
            return this.CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }   
}
