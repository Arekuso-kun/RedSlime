using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThing : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    Vector2 screenBounds = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0, -10);

        if (- 2 * screenBounds.y > transform.position.y)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

    }
}
