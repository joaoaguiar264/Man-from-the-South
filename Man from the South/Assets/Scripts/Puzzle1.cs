using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{
    public GameObject puzzle;
    public static int score;
    public float spaceTime;
    public bool acceptingAnswer = true;

    public Text passOrFail;
    public Text displayBox;
    public int key;
    public int isRolling;
    public int correctKey;
    public int timer;

    public float startTimer = 5;
    public Text startTimerText;
    public GameObject tutorial;

    public static bool puzzleComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isRolling = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer > -1 && startTimer < 0)
        {
            Tutorial();
            startTimer = -1;
        }
        if(startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }
        startTimerText.text = startTimer.ToString("F0");

        if(score >= 20)
        {
            isRolling = 1;
            displayBox.text = "Good job!";
            passOrFail.text = "";
            StartCoroutine(Finished());
        }

        if(score >= 0 && score < 10)
        {
            spaceTime = 2;
        }

        if (score > 10 && score < 15)
        {
            spaceTime = 1;
        }

        if (score >= 15)
        {
            spaceTime = 0.8f;
        }

        if (isRolling == 0)
        {
            key = Random.Range(1, 8 + 1);
            timer = 1;
            StartCoroutine(CountDown());

            if (key == 1)
            {
                isRolling = 1;
                displayBox.text = "[A]";
            }
            if (key == 2)
            {
                isRolling = 1;
                displayBox.text = "[S]";
            }
            if (key == 3)
            {
                isRolling = 1;
                displayBox.text = "[D]";
            }
            if (key == 4)
            {
                isRolling = 1;
                displayBox.text = "[F]";
            }
            if (key == 5)
            {
                isRolling = 1;
                displayBox.text = "[H]";
            }
            if (key == 6)
            {
                isRolling = 1;
                displayBox.text = "[J]";
            }
            if (key == 7)
            {
                isRolling = 1;
                displayBox.text = "[K]";
            }
            if (key == 8)
            {
                isRolling = 1;
                displayBox.text = "[L]";
            }
        }

        if (key == 1)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 2)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 3)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 4)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 5)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 6)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 7)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (key == 8)
        {
            if (Input.anyKeyDown && acceptingAnswer == true)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        key = 4;
        if(correctKey == 1)
        {
            score = score + 1;
            timer = 2;
            passOrFail.text = "Pass";
            acceptingAnswer = false;
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            displayBox.text = "";
            passOrFail.text = "";
            yield return new WaitForSeconds(1f);
            acceptingAnswer = true;
            isRolling = 0;
            timer = 1;
        }
        if (correctKey == 2)
        {
            timer = 2;
            passOrFail.text = "Fail";
            Player.takeDamage = true;
            acceptingAnswer = false;
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            displayBox.text = "";
            passOrFail.text = "";
            yield return new WaitForSeconds(1f);
            acceptingAnswer = true;
            isRolling = 0;
            timer = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(spaceTime);
        if(timer == 1)
        {
            key = 4;
            timer = 2;
            passOrFail.text = "Fail";
            Player.takeDamage = true;
            acceptingAnswer = false;
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            displayBox.text = "";
            passOrFail.text = "";
            yield return new WaitForSeconds(1f);
            acceptingAnswer = true;
            isRolling = 0;
            timer = 1;
        }
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
}
