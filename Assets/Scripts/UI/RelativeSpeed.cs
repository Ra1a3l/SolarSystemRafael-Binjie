using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelativeSpeed : MonoBehaviour
{
    public Text textRenderer;
    public Rigidbody planet;
    public Rigidbody Spaceship;
    private float unitChange = 1500000.0f/52560.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed1 = planet.velocity;
        Vector3 speed2 = Spaceship.velocity;
        Vector3 RelativeVelocity = speed1-speed2;
        float speed = RelativeVelocity.magnitude * unitChange;

        float distance = Vector3.Distance(planet.position, Spaceship.position)*1500000;

        
        

        textRenderer.text = "Speed :" + speed.ToString() +" km/s"+ "\nDistance :" + distance.ToString() + "km";
        
    }
}
