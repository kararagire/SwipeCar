using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    public bool notsecond = true;
    Vector2 startPos;
    float startTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && notsecond)

        {
            this.startPos = Input.mousePosition;
            startTime = Time.time;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetMouseButtonUp(0) && notsecond)
        {
            Vector2 endPos = Input.mousePosition;
            float endTime = Time.time;
            float swipeLength = endPos.x - this.startPos.x;
            float swipeTime = endTime - startTime;

            this.speed = swipeLength / (swipeTime * 8500.0f);
            notsecond = false;
        }
        if (this.speed < 0)
        {
            this.speed = 0;
            notsecond = true;
        }
        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;

    }
}
