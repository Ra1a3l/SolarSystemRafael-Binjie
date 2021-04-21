using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class panel1 : MonoBehaviour
{
    public Text displayText;

    public string textToDisplay;

    public void DisplayText()
    {
        displayText.text = "Information" + textToDisplay;
    }
}
