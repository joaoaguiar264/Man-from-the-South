using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject startTextObject;
    public GameObject startText;
    private float textSpeed = 30;
    public float time;

    public static bool bossFightBool = false;
    public GameObject dialog;
    public static bool dialogOn = false;
    public GameObject Dialogs;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;
    public GameObject dialog5;
    public GameObject dialog6;
    public GameObject dialog7;
    public GameObject dialog8;
    public GameObject dialog9;
    public GameObject dialog10;
    public GameObject dialog11;
    public GameObject dialog12;
    public GameObject dialog13;
    public GameObject dialog14;
    public GameObject dialog15;

    public GameObject puzzle1;
    public bool puzzle2OneTime = false;
    public GameObject puzzle2;

    public GameObject bossFight;
    public Transform initialPosition;

    public Image accept;
    public Image deny;
    public bool acceptSelected = true;

    public GameObject enemyHP;

    public GameObject respawn;

    public static bool win = false;
    public GameObject Win;
    public GameObject Win2;

    public static bool win2 = false;
    public GameObject win2Screen;
    public GameObject win2Screen2;

    public static bool screenText;
    public GameObject screenTextObj;
    public Text screenTextText;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        Win.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        Win2.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        win2 = false;
        win2Screen.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        win2Screen2.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(screenText == true)
        {
            StartCoroutine(ScreenText());
            screenText = false;
        }

        if(Puzzle1.puzzleComplete == true && Puzzle2.puzzleComplete == true)
        {
            win = true;

        }

        if(win == true)
        {
            StartCoroutine(End());
        }

        if(win2 == true)
        {
            StartCoroutine(End2());
        }

        if(Puzzle1.puzzleComplete == true && puzzle2OneTime == false)
        {
            puzzle2OneTime = true;
            Puzzle2Active();
        }

        if(Player.hp <= 0)
        {
            StartCoroutine(GameOver());
        }

        if (time <= 40)
        {
            time += Time.deltaTime;
            startText.transform.Translate(Camera.main.transform.up * textSpeed * Time.deltaTime);
        }
        else
        {
            player.gameObject.GetComponent<Player>().enabled = true;
            startTextObject.SetActive(false);
        }


        if(dialogOn == true)
        {
            Dialogs.gameObject.SetActive(true);

            if (Input.GetKeyUp(KeyCode.Space) && dialog14.activeSelf == true)
            {
                dialog14.SetActive(false);
                dialog15.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog13.activeSelf == true)
            {
                dialog13.SetActive(false);
                dialog14.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog12.activeSelf == true)
            {
                dialog12.SetActive(false);
                dialog13.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog11.activeSelf == true)
            {
                dialog11.SetActive(false);
                dialog12.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog10.activeSelf == true)
            {
                dialog10.SetActive(false);
                dialog11.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog9.activeSelf == true)
            {
                dialog9.SetActive(false);
                dialog10.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog8.activeSelf == true)
            {
                dialog8.SetActive(false);
                dialog9.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog7.activeSelf == true)
            {
                dialog7.SetActive(false);
                dialog8.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog6.activeSelf == true)
            {
                dialog6.SetActive(false);
                dialog7.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog5.activeSelf == true)
            {
                dialog5.SetActive(false);
                dialog6.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog4.activeSelf == true)
            {
                dialog4.SetActive(false);
                dialog5.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog3.activeSelf == true)
            {
                dialog3.SetActive(false);
                dialog4.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog2.activeSelf == true)
            {
                dialog2.SetActive(false);
                dialog3.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && dialog1.activeSelf == true)
            {
                dialog1.SetActive(false);
                dialog2.SetActive(true);
            }

            
        }

        if(acceptSelected == true)
        {
            accept.color = Color.yellow;
            deny.color = Color.white;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                acceptSelected = false;
            }

            if(Input.GetKeyDown(KeyCode.Space) && dialog15.activeInHierarchy == true)
            {
                Puzzle1Active();
                dialog15.SetActive(false);
            }
        }
        else
        {
            deny.color = Color.yellow;
            accept.color = Color.white;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                acceptSelected = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && dialog15.activeInHierarchy == true)
            {
                BossFight();
                dialog15.SetActive(false);
            }
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);

        respawn.SetActive(true);
    }

    IEnumerator ScreenText()
    {
        screenTextObj.SetActive(true);
        yield return new WaitForSeconds(2);
        screenTextObj.SetActive(false);
    }

    IEnumerator End()
    {
        if (Win.gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            Win.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.3f;
        }
        yield return new WaitForSeconds(8f);

        if(Win2.gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            Win2.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * speed;
        }
        //Win2.SetActive(true);


    }

    IEnumerator End2()
    {
        yield return new WaitForSeconds(3f);

        if (win2Screen.gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            win2Screen.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.3f;
        }
        yield return new WaitForSeconds(8f);

        if (win2Screen2.gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            win2Screen2.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * speed;
        }

    }

    public void Skip()
    {
        startTextObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Respawn()
    {
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
        dialogOn = false;
        Dialogs.SetActive(false);
        dialog2.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Puzzle1Active()
    {
        dialog.SetActive(false);
        puzzle1.SetActive(true);
    }
    public void Puzzle2Active()
    {
        dialog.SetActive(false);
        puzzle2.SetActive(true);
    }

    public void BossFight()
    {
        enemyHP.SetActive(true);
        bossFightBool = true;
        dialog.SetActive(false);
        bossFight.SetActive(true);
        player.transform.position = initialPosition.transform.position;
        Player.stopPlayer = false;
        enemy.gameObject.GetComponent<Enemy>().enabled = true;
    }
}
