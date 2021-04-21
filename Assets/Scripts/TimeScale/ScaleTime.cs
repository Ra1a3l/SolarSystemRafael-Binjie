using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTime : MonoBehaviour
{
    
    void Update()
    {
        //fast forward 10x using key code T
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 10;
            Time.fixedDeltaTime = 0.2f;
        }
        //Return to normal timespeed using key code Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
