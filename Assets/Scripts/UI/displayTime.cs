using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class displayTime : MonoBehaviour
{
    public GameObject theDisplay;
    public int hour;
    public int minutes;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
   
        theDisplay.GetComponent<Text>().text = "" + hour + ":" + minutes + ":" + seconds;

    }
}