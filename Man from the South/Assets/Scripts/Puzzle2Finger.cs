using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Finger : MonoBehaviour
{
    private float spaceTime = 1;

    public static bool wrongClick = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(wrongClick == true)
        {
            wrongClick = false;
            Destroy(this.gameObject);
        }

        if (Puzzle2.score >= 0 && Puzzle2.score <= 5)
        {
            spaceTime = 3;
        }

        if (Puzzle2.score > 5 && Puzzle2.score < 10)
        {
            spaceTime = 1.8f;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(spaceTime);
        Puzzle2.timeUp = true;
        Destroy(this.gameObject);
    }

    public void Click()
    {
        Puzzle2.correct = true;
        Destroy(this.gameObject);
    }
}
