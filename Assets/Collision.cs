using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    public TextMeshProUGUI MyText;

    private int collisionNumber = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Bad Thing(Clone)")
        {
            collisionNumber++;
            MyText.text = collisionNumber.ToString();
        }
    }
}
