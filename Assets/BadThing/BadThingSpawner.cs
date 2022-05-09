using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThingSpawner : MonoBehaviour
{
    public GameObject BadThingPrefab;
    public SomeText m_text;
    public float initialSpawnTime = 0.2f;
    float SpawnTime;
    Vector2 screenBounds = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(Spawner());
    }
    private void Update()
    {
        SpawnTime = initialSpawnTime - (m_text.level - 1) * 0.04f;
    }
    void Spawn()
    {
        GameObject thing = Instantiate(BadThingPrefab) as GameObject;
        thing.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), 2 * screenBounds.y);
    }

    // Update is called once per frame
    IEnumerator Spawner()
    {
        while(true){
            yield return new WaitForSeconds(SpawnTime);
            Spawn();
        }
    }
}
