using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SomeText : MonoBehaviour
{
    public TextMeshProUGUI m_score;
    public TextMeshProUGUI m_level;
    public TextMeshProUGUI m_levelTimer;
    public int time = 0;
    public int levelTimer = 0;
    int nextlevelTimer;
    public int level = 1;
    int levelDuration = 30;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTimer >= levelDuration)
        {
            level++;
            levelTimer = 0;
        }
        m_level.text = "Level " + level.ToString();
        score = time * 100 / levelDuration;
        m_score.text = "Score: " + score.ToString();
        nextlevelTimer = 30 - levelTimer;
        m_levelTimer.text = "Next level: " + nextlevelTimer.ToString();
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
            levelTimer++;
        }
    }
}
