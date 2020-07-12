using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class control : MonoBehaviour
{
    GameObject platform, platform2, platform3, platform4, platform5, platform6;
    public int z, kill = 0;
    public int speed = 4;
    public int k;
    public AudioSource []audo=new AudioSource[26];
    public Text charact;
    public int t = 97;
    public Text wintext;
    public Text Scorecard;
    int points=0;
    

    // Start is called before the first frame update
    void Start()
    {
        audo[0].Stop();
        kill = 0;
        z = 0;
        Scorecard.text = "Next Alphabet : a";
        wintext.text = " Score : 0";
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
   
    private void OnTriggerEnter(Collider other)
    {
        string c = other.gameObject.tag;
        char[] ca = c.ToCharArray();
        

        if (t == ca[0])
            {
            k = t+1;
            points++;
                Scorecard.text = "Next Alphabet : "+ (char)k;
                other.gameObject.SetActive(false);
            wintext.text = "  Score : "+points;
            t = t + 1 ;
            if (!audo[t-97].isPlaying)
                audo[t-97].Play();
            

        }
        
        else
        {
            other.gameObject.SetActive(false);
            //Time.timeScale = 0;
            SceneManager.LoadScene("SampleScene");
        }
        if (t == 123)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.gameObject.tag == "end")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    
}
