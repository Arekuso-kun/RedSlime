using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThingSpawner : MonoBehaviour
{
    public GameObject BadThingPrefab;
    public SomeText m_text;
    public Collision m_collision;
    Rigidbody2D m_rigidbody;

    public float speed;

    float initialSpawnTime = 0.3f;
    float maxSpawnTime = 0.05f;
    float SpawnTime;

    float aspectRatio = Screen.width / Screen.height;

    bool initialDelay = true;

    Vector2 screenBounds = Vector2.zero;

    void Start()
    {
        speed = -(SpawnTimeFormula(m_text.level - 12.5f) - 12);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(Spawner());
    }
    void Update()
    {
        if (m_collision.Dead == true)
            initialDelay = true;
        if (Time.timeScale != 0 && initialDelay == true)
            StartCoroutine(Delay(1));
        SpawnTime = SpawnTimeFormula(m_text.level);
    }

    float SpawnTimeFormula(float x)
    {
        return Mathf.Pow(initialSpawnTime, 1 + (x - 1) / 5.0f) + maxSpawnTime;
    }
    void Spawn()
    {
        GameObject thing = Instantiate(BadThingPrefab) as GameObject;
        thing.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), 2 * screenBounds.y);
        m_rigidbody = thing.GetComponent<Rigidbody2D>();

        speed = -(SpawnTimeFormula(m_text.level - 12.5f) - 12);
        m_rigidbody.velocity = new Vector2(0, -speed);
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnTime / (16/9) * aspectRatio);
            if(initialDelay == false)
                Spawn();

        }
    }

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        initialDelay = false;
    }
}
