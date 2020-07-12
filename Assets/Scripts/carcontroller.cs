using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carcontroller : MonoBehaviour
{
    GameObject platform, platform2,platform3,platform4, platform5, platform6;
    public int z,kill=0;
    public int speed = 4;
    public int score = 0;
    public Text wintext;
    public Text Scorecard;

    // Start is called before the first frame update
    void Start()
    {
        kill = 0;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {

            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime*speed);
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime*speed);
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
        if(other.gameObject.tag=="a")
        {
            score++;
            Scorecard.text = "Score is " + score;
            other.gameObject.SetActive(false);
            
        }
        if(other.gameObject.tag=="enemy")
        {
            other.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        if(other.gameObject.tag=="trigger")
        {
            if (kill > 2)
            {
                Destroy(platform2);
                Destroy(platform3);
                Destroy(platform5);
                kill--;
            }
                
                z +=10;
                platform2 = platform;
                platform=(GameObject)Instantiate(Resources.Load("Level"), new Vector3(0, 0, z), Quaternion.identity);
            platform3 = platform4;
            platform4 = (GameObject)Instantiate(Resources.Load("pick"), new Vector3(Random.Range(-3.55f,-0.51f),0,z), Quaternion.identity);
            platform5 = platform6;
            platform6 = (GameObject)Instantiate(Resources.Load("enemies"), new Vector3(Random.Range(-1.39f, 1.62f), 0, z), Quaternion.identity);

            kill++;
            Debug.Log("trigger");
            //SceneManager.LoadScene("level name");
        }
    }
}
