using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    public TextMeshProUGUI MyText;
    public SomeText scriptText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Bad Thing(Clone)")
        {
            Debug.Log("U died!");
            scriptText.PlayerDead = true;
        }
    }
}
