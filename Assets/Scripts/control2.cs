using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class control2 : MonoBehaviour
{
    GameObject platform, platform2, platform3, platform4, platform5, platform6;
    public int z, kill = 0;
    public int speed = 4;
    public int k;
    public int cnt = 3;
    public int temp = 0;
    public AudioSource[] audo = new AudioSource[26];
    String[] arr = new String[5];
    public Text charact;
    public Text score;
    public int t = 97;
    public Text lifetext;
    public Text Scorecard;
    public Text charec;
    int points = 0;


    // Start is called before the first frame update
    void Start()
    {
        //audo[0].Stop();
        kill = 0;
        z = 0;
        arr[0] = "apple";
        arr[1] = "bat";
        arr[2] = "cat";
        arr[3] = "doll";
        arr[4] = "egg";
        Scorecard.text = "Word : " + arr[0];
        charec.text = " " + arr[0][0];
        lifetext.text = " Lifes : 3";
        score.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime*speed);
            transform.Rotate(new Vector3(0, -10, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime*speed);
            transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * speed);
        }
        


    }
    int p = 0;

    private void OnTriggerEnter(Collider other)
    {
        string c = other.gameObject.tag;
        char[] ca = c.ToCharArray();
        int len = arr[temp].Length;
        char[] temp1 = arr[temp].ToCharArray();

        char t1 = temp1[p];
        if (t1 == ca[0])
        {
            p++;
            points++;

            if (p == len)
            {
                temp++;
                p = 0;
            }

            Scorecard.text = "Word : " + arr[temp];
            charec.text = " " + arr[temp][p];
            other.gameObject.SetActive(false);
            

            // t = t + 1;
            if (!audo[ca[0] - 97].isPlaying)
                audo[ca[0] - 97].Play();
            score.text = "Score : " + points;


        }

        else
        {
            cnt--;
            lifetext.text = "Lifes : " + cnt;
            if (cnt == 0)
            {
                other.gameObject.SetActive(false);
                //Time.timeScale = 0;
                SceneManager.LoadScene("SampleScene");

            }
        }
        if (t == 123)
        {
            SceneManager.LoadScene("Scene2");
        }
        if (other.gameObject.tag == "end")
        { Time.timeScale = 0; }
    }


}
