using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    public GameObject puzzle;

    public float minX, maxX, minY, maxY;
    private Vector2 pos;
    public GameObject finger;

    public static int score;
    public float spaceTime;

    public Text passOrFail;

    public int isRolling;
    public int timer;

    public static bool timeUp;
    public static bool correct;

    public float startTimer = 5;
    public Text startTimerText;
    public GameObject tutorial;

    public static bool puzzleComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isRolling = 1;
        minX = 190f;
        maxX = 920f;
        minY = 200;
        maxY = 420;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeUp == true)
        {
            StartCoroutine(TimesUP());
            timeUp = false;
        }
        if(correct == true)
        {
            StartCoroutine(Correct());
            correct = false;
        }

        if (startTimer > -1 && startTimer < 0)
        {
            Tutorial();
            startTimer = -1;
        }
        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }
        startTimerText.text = startTimer.ToString("F0");

        if (score >= 10)
        {
            isRolling = 1;
            passOrFail.text = "Good Job!";
            StartCoroutine(Finished());
        }

        if (isRolling == 0)
        {
            SpawnObject();
        }
    }


    public void SpawnObject()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject obj = Instantiate(finger, pos, Quaternion.identity);
        obj.transform.parent = transform;
        isRolling = 1;
    }
    IEnumerator Correct()
    {
        score = score + 1;
        timer = 2;
        passOrFail.text = "Pass";
        Debug.Log("pass");
        yield return new WaitForSeconds(1f);
        passOrFail.text = "";
        yield return new WaitForSeconds(1f);
        isRolling = 0;
        timer = 1;
        correct = false;

    }
    IEnumerator TimesUP()
    {
        timer = 2;
        passOrFail.text = "Fail";
        Debug.Log("fail");
        Player.takeDamage = true;
        yield return new WaitForSeconds(1f);
        passOrFail.text = "";
        yield return new WaitForSeconds(1f);
        isRolling = 0;
        timer = 1;
        timeUp = false;
    }

    IEnumerator Finished()
    {
        yield return new WaitForSeconds(3f);
        puzzle.SetActive(false);
        puzzleComplete = true;
    }
    public void Tutorial()
    {
        startTimer = 0;
        isRolling = 0;
        tutorial.SetActive(false);

    }

    public void Wrong()
    {
        StartCoroutine(TimesUP());
        Puzzle2Finger.wrongClick = true;
    }
}
