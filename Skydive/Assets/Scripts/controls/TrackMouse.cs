﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour
{
   
    //used to keep track of initial position of the knob to easily create an artifical origin for the mouse
    float startX;
    float startY;
    public float c;
    public float x;
    public float y;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    void Update()
    {

        //maps mouse pos to Canvas pos
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float mousePosX = mousePos.x * Screen.width;
        float mousePosY = mousePos.y * Screen.height;

        x = startX - mousePosX;
        y = startY - mousePosY;

        

        //used to track Knob distance from center in order to restrict it within a certain area
        c = Mathf.Sqrt((x * x) + (y * y));
        //Debug.Log(c);
        if (Input.touchCount == 1 || Input.GetKey(KeyCode.Mouse0))
        {
            //follow mouse position
            transform.position = new Vector2(mousePosX, mousePosY);

            //if the knob center exceeds 175 units from its center
            if (c > 175)
            {
                //restrict it to a certain perimeter
                transform.position = new Vector2(x, y).normalized * -175;
                transform.position += new Vector3(startX, startY);
            }
        }

        //returns knob to center
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(startX, startY), 0.5f);
        }
    }
}