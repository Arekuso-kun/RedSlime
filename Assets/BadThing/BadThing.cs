using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThing : MonoBehaviour
{
    // public Rigidbody2D m_rigidbody;
    SomeText m_text;

    Vector2 screenBounds = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Setting up the reference.
        m_text = GameObject.FindWithTag("scoringSystem").GetComponent<SomeText>();

        StartCoroutine(DestroyThingFarAway(1));

        // m_rigidbody.velocity = new Vector2(0, Mathf.Pow(2, (-m_text.level + 13) / 4f) - 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.gameObject.CompareTag("BadThing"))
            Destroy(this.gameObject);

    }

    IEnumerator DestroyThingFarAway(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            if (Mathf.Abs(transform.position.y) > Mathf.Abs(2 * screenBounds.y) || Mathf.Abs(transform.position.x) > Mathf.Abs(2 * screenBounds.x))
                Destroy(this.gameObject);
        }
    }
}
