using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInitializer : MonoBehaviour
{
    public float gravity;
    public int SunMass;
    public float SpaceshipMass;
    public GameObject SpaceShip;
    public GameObject Earth;

    Vector3 EarthVelocity = new Vector3(0,-6.28273135f,0);
    float getForce(float mass1, float mass2, float distance)
    {
        // return F=(Gm2m2)/d^2
        return (gravity*mass1*mass2)/Mathf.Pow(distance,2);
    }
    void Start()
    {
        
        SpaceShip.GetComponent<Rigidbody>().mass = SpaceshipMass;
        SpaceShip.GetComponent<Rigidbody>().velocity = EarthVelocity;
    }
}
