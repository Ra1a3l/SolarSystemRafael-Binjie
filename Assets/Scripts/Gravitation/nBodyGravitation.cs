using System.Collections;
using System.Collections.Generic;
using Imu;
using UnityEngine;

public class nBodyGravitation : MonoBehaviour
{
    //Gravitational constant
    public double gravity;
    //array containing all planets and moons
    public GameObject[] Planets;
    //Spaceship
    public GameObject SpaceShip;
    public int SunMass;
    public double SpaceshipMass = 0.0001;
    

    //Array storing all planets, moons and the sun's mass
    float[] Mass = new float[]
    {
    2000000, //Sun
    0.33f,  //Mercury
    4.87f,  //Venus
    5.97f,  //Earth
    0.7375f,  //Moon
    0.64f,  //Mars
    1898,  //Jupiter
    0.0893f,  //Ganymede
    0.047998f,  //Europa
    0.10759f,  //Io
    570,  //Saturn
    87,  //Neptune
    102,  //Uranus
    0.13f,  //Pluto    
    };

    //Array storing all planets, moons and the suns's initial velocity
    Vector3[] VelocityInit = new Vector3[] 
    {
    new Vector3(0,0,0), //Sun
    new Vector3(0,10.10290546f,0), //Mercury
    new Vector3(0,7.29651291f,0),  //Venus
    new Vector3(0,6.28273135f,0),  //Earth
    new Vector3(0,8.098959f,0),  //Moon
    new Vector3(0,4.94945191f,0),  //Mars
    new Vector3(0,2.74394554f,0),  //Jupiter
    new Vector3(0,3.45094524521f,0),  //Ganymede
    new Vector3(0,3.387139f,0),  //Europa
    new Vector3(0,2.22217813691f,0),  //Io
    new Vector3(0,1.81834686f,0),  //Saturn
    new Vector3(0,1.42044486f,0),  //Uranus
    new Vector3(0,1.10876387f,0),  //Neptune
    new Vector3(0,0.95225637f,0),  //Pluto   
    };

    //Function calculating the magnitude of the gravitational force between two obects with mass1 and mass2 at a certain distance
    double getForce(double mass1, double mass2, float distance)
    {
    // return F=(Gm2m2)/d^2
    return (gravity*mass1*mass2)/Mathf.Pow(distance,2);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialize all rigidbodies with their respecting mass and initial orbital velocity by looping through the arrays defined before
        for (int i = 0; i < Mass.Length; i++)
        {
            Planets[i].GetComponent<Rigidbody>().mass = Mass[i];
            Planets[i].GetComponent<Rigidbody>().velocity = VelocityInit[i];
            
        }
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        // Loop through each sphere totaling up and applying gravitational forces
        foreach(GameObject s in Planets)
        {
            

            Vector3 totalForce=new Vector3(0,0,0),forceDirection;
            double forceAmount;
            float sphereMass = s.GetComponent<Rigidbody>().mass;

            forceDirection = (s.transform.position-SpaceShip.transform.position).normalized;
            forceAmount = getForce(SpaceshipMass,sphereMass,Vector3.Distance(SpaceShip.transform.position, s.transform.position));
            totalForce += forceDirection * (float)forceAmount;
            SpaceShip.GetComponent<Rigidbody>().AddForce(totalForce,ForceMode.Force);
            
    
            
            // if you want sphere gravity to affect each other
            foreach(GameObject p in Planets)
                {
                    if (!p.Equals(s))
                    { // don't check itself
                        forceDirection = (p.transform.position-s.transform.position).normalized;
                        forceAmount = getForce(sphereMass,p.GetComponent<Rigidbody>().mass,Vector3.Distance(p.transform.position, s.transform.position));
                        totalForce += forceDirection * (float)forceAmount; 
                    }
                }
        
            //apply all forces to sphere
            s.GetComponent<Rigidbody>().AddForce(totalForce,ForceMode.Force);
        }
    }
}
