using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SomeText : MonoBehaviour
{
    public TextMeshProUGUI MyText;
    public Transform player;
    private int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        //MyText.text = player.position.ToString();
        MyText.text = "Score: " + time.ToString();
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}
