using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundThings : MonoBehaviour
{
    public GameObject BadThingPrefab;
    public Transform m_transform;
    public SomeText m_text;
    Rigidbody2D m_rigidbody2d;

    public BadThingSpawner m_BadThingSpawner;
    float speed;
    public float numberOfThingsInASpawn = 16;
    public float SpawnTimeR;

    Vector2 screenBounds = Vector2.zero;
    Vector2 position = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // m_rigidbody2d = BadThingPrefab.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnTimeR = m_text.levelDuration * 1.5f;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimeR = m_BadThingSpawner.SpawnTimeFormula(m_text.level - 18) + 1;
    }
    void Spawn(float x, float y)
    {
        GameObject thing = Instantiate(BadThingPrefab) as GameObject;
        thing.transform.position = position;
        m_rigidbody2d = thing.GetComponent<Rigidbody2D>();
        m_rigidbody2d.velocity = new Vector2(x, y);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTimeR / (16 / 9) * m_BadThingSpawner.aspectRatio);
            position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
            for (float i = 0; i <= 2 * Mathf.PI; i += 2 * Mathf.PI / numberOfThingsInASpawn)
            {
                speed = m_BadThingSpawner.speed;
                Spawn(Mathf.Sin(i) * speed, Mathf.Cos(i) * speed);
            }

        }
    }
}
