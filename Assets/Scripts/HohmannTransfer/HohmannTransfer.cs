using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HohmannTransfer : MonoBehaviour
{
    //Sun
    public GameObject Sun;
    //SpaceShip
    public GameObject object1;
    //Destination planet
    public GameObject object2;
    //SPaceShip
    public GameObject Spaceship;
    //GameObject attached to the Ship always pointing towards the Sun
    public GameObject Target;
    //RigidBody
    public Rigidbody rb;
    //Gravitational Constant
    public const float G = 0.001965464f;
    //Sun Mass
    public const float SunMass = 2000000;
    //Constant that multiplies G and SunMass
    float Mu = G*SunMass;
    //Timer to start when transfer is initialized
    float Timer =0.0f;

    //Magnitude of the first impulse
    float DeltaV1(float r1, float r2)
    {
        return Mathf.Sqrt(Mu/r1)*(Mathf.Sqrt(2*r2/(r1+r2))-1);
    }

    //Magnitude of the second impulse
    float DeltaV2(float r1, float r2)
    {
        return Mathf.Sqrt(Mu/r2)*(1-Mathf.Sqrt(2*r2/(r1+r2)));
    }
    //Time it takes to complete the transfer
    public float TravelTime(float r1, float r2)
    {
        return Mathf.PI*Mathf.Sqrt(Mathf.Pow(r1+r2,3)/(8*Mu));
    }

    public float Omega2(float r2)
    {
        return Mathf.Sqrt(Mu/Mathf.Pow(r2,3));
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //A bool that will ensure if statements are computed only once(Apply each impulse only onece)
    bool AlreadyBegan = true;
    bool AlreadyBegan2 = true;
    bool TimeStarter = false;
    
    void FixedUpdate()
    {
        //The target is always pointing at the sun, will help calculate the direction in which each impulse has to be applied
        Target.transform.LookAt(Sun.transform);
        Vector3 Source = object1.transform.position;
        Vector3 Destination = object2.transform.position;
        //Direction of the first impulse
        Vector3 Direction1 = Vector3.ProjectOnPlane(Target.transform.forward, Source.normalized).normalized;
        //Direction of the second impulse
        Vector3 Direction2 = Vector3.ProjectOnPlane(Target.transform.forward, Destination.normalized).normalized;
        //Distance of the Souce planet and destination planet relative to the sun
        float r1 = Source.magnitude;
        float r2 = Destination.magnitude;
        //Angle between the two planets relative to the sun
        float currentAngle = Vector3.SignedAngle(Source, Destination, Vector3.right);
        //Vector of the two impulses
        Vector3 d1 = DeltaV1(r1,r2)*Direction1;
        Vector3 d2 = DeltaV2(r1,r2)*Direction2;
        
        
        //Debug.Log(DeltaV1(r1,r2));
        //Debug.Log(-Mathf.Round(currentAngle));
        //Debug.Log(Mathf.Round(Mathf.Rad2Deg*(Mathf.PI-Omega2(r2)*TravelTime(r1,r2))));
        float CurrentTravelTime = 0.0f;

        /*Apply the first impulse when the angle is right so that the ship reached 
        the correct orbit when the destination planet is at the right position*/
        if (-Mathf.Round(10*currentAngle) == Mathf.Round(10*Mathf.Rad2Deg*(Mathf.PI-Omega2(r2)*TravelTime(r1,r2))) && AlreadyBegan)
        {
            //Change this condition so that the first impulse is applied only once
            AlreadyBegan = false;
            //Start the timer when first impulse is applied
            TimeStarter = true;
            CurrentTravelTime = TravelTime(r1,r2);
            //Debug.Log(CurrentTravelTime);
            if (r1<r2)
            {
                Spaceship.GetComponent<Rigidbody>().AddForce(d1, ForceMode.VelocityChange);
                Debug.Log("First impulse!");
                //Debug.Log(TravelTime(r1,r2));
            }
            else
            {
                Spaceship.GetComponent<Rigidbody>().AddForce(-d1, ForceMode.VelocityChange);
                Debug.Log("First impulse!");
                //Debug.Log(TravelTime(r1,r2));
            }
            
        }
        //Debug.Log(CurrentTravelTime);
        //Starts when first impulse is applied
        if (TimeStarter)
        {
            Timer += Time.deltaTime;
            //Debug.Log(Mathf.Round(150*Timer));
            //Debug.Log(Mathf.Round(150*CurrentTravelTime));
        }
        //Aplly second impulse whenthe timer has reached the required travel time
        if (Mathf.Round(Timer) >= Mathf.Round(TravelTime(r1,r2)) && AlreadyBegan2)
        {
            Debug.Log("Second impluse");
            //Change this condition so that the second impulse is applied only once
            AlreadyBegan2 = false;
            if (r1<r2)
            {
                Spaceship.GetComponent<Rigidbody>().AddForce(d2, ForceMode.VelocityChange);
            }
            else
            {
                Spaceship.GetComponent<Rigidbody>().AddForce(-d2, ForceMode.VelocityChange);
            }
        }
    }
}