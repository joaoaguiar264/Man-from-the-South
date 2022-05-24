using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject Player;
    public GameObject startTextObject;
    public GameObject startText;
    private float textSpeed = 30;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (time <= 30)
        {
            time += Time.deltaTime;
            startText.transform.Translate(Camera.main.transform.up * textSpeed * Time.deltaTime);
        }
        else
        {
            Player.gameObject.GetComponent<Player>().enabled = true;
            startTextObject.SetActive(false);
        }
    }
}
