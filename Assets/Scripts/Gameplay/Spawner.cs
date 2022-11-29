using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Circle objToSpawn;

    private CirclesPool<Circle> pool;
    private float availableSize;

    [SerializeField] float minTime = 1f;
    [SerializeField] float maxTime = 3f;
    private bool spawning;

    Randomizer rand = new Randomizer();
    void Start()
    {
        this.pool = new CirclesPool<Circle>(this.objToSpawn, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
        availableSize = GetCamraWidth();
        spawning = false;
        StartCoroutine(SpawningFlow());
    }

    private void CreateObject() 
    {
        var obj = this.pool.GetFreeElement();
        obj.transform.localScale = objToSpawn.transform.localScale;//refreshing size to default
        rand.Randomize(obj);
        obj.transform.position = GetSpawnPosition(obj.transform.localScale.x);//seting start position which depends on the circle size
    }

    IEnumerator SpawnDelay(float delayTime)
    {
        spawning = true;
        CreateObject();
        yield return new WaitForSeconds(delayTime);
        spawning = false;
    }

    private Vector3 GetSpawnPosition(float objSize) 
    { 
        float negX = ((availableSize * 0.5f) - (objSize * 0.5f)) * -1f;
        float posX = ((availableSize * 0.5f) - (objSize * 0.5f));
        float zPosition = this.transform.position.z - 1 / objSize;
        return new Vector3(Random.Range(negX, posX), this.transform.position.y, zPosition);
    }

    private float GetCamraWidth() 
    {
        Camera cam = Camera.main;
        float camWidth = 2f * cam.orthographicSize * cam.aspect;
        return camWidth - 0.1f; //0.1f is for optimizing(To make some borders/not use all space)
    }

    IEnumerator SpawningFlow() 
    {
        while (true) 
        {   
            if(!spawning)
                StartCoroutine(SpawnDelay(Random.Range(minTime, maxTime)));
            yield return null;
        }
    }
}
