using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class onClick2 : MonoBehaviour
{
    public Text displayText;
    public string textToDisplay;


    public void DisplayText()
    {
        displayText.text = "Information" + textToDisplay;
    }

    


 

    public string stringToEdit = "Planet Information";


    
}


