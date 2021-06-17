using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");


    }

    // Update is called once per frame
    void Update()
    {
        float speed = car.GetComponent<CarController>().speed;
        bool notsecond = car.GetComponent<CarController>().notsecond;
        float length = this.flag.transform.position.x - this.car.transform.position.x - 1.64f;
        if (length <= -5.0f || (length <= -1.0f && speed < 0.05f))
        {
            this.distance.GetComponent<Text>().text = "ゲームオーバー";
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        else if (length >= 0 && length <= 1.0f && speed < 0.001f)
        {
            this.distance.GetComponent<Text>().text = "ゲームクリア！";
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        else if (notsecond)
        {
            this.distance.GetComponent<Text>().text = "ゴールまで" + length.ToString("F2") + "m";
        }
        else if (speed < 0.001f)
        {
            this.distance.GetComponent<Text>().text = "惜しい！";
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        else if (speed < 0.1f && !notsecond || length <= 3.0f)
        {
            this.distance.GetComponent<Text>().text = "ゴールまで" + length.ToString("F2") + "m";
        } 
        else
        {
            this.distance.GetComponent<Text>().text = "";
        }

    }
}
