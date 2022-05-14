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
    float numberOfThingsInASpawn = 16;

    // Start is called before the first frame update
    void Start()
    {
        // m_rigidbody2d = BadThingPrefab.GetComponent<Rigidbody2D>();
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn(float x, float y)
    {
        GameObject thing = Instantiate(BadThingPrefab) as GameObject;
        thing.transform.position = new Vector2(transform.position.x, transform.position.y);
        m_rigidbody2d = thing.GetComponent<Rigidbody2D>();
        m_rigidbody2d.velocity = new Vector2(x, y);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Debug.Log(Mathf.PI / numberOfThingsInASpawn);
            yield return new WaitForSeconds(1);
            for (float i = 0; i <= 2 * Mathf.PI; i += 2 * Mathf.PI / numberOfThingsInASpawn)
            {
                speed = m_BadThingSpawner.speed;
                Spawn(Mathf.Sin(i) * speed, Mathf.Cos(i) * speed);
            }

        }
    }
}
