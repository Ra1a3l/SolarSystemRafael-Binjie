using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthMoon : MonoBehaviour
{
    public GameObject Moon;
    public GameObject Earth;
    Rigidbody forceAmount;
    public float gravity;
    float MoonMass = 0.7375f;
    float EarthMass = 5.97f;
    Vector3 MoonVelocity = new Vector3(0, 0.020728034f, 0);


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = MoonMass;
        GetComponent<Rigidbody>().velocity = MoonVelocity;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 totalForce = new Vector3(0, 0, 0), forceDirection;
        float forceAmount;
        float moonMass = GetComponent<Rigidbody>().mass;


        forceDirection = (Earth.transform.position - Moon.transform.position).normalized;
        forceAmount = getForce(MoonMass, EarthMass, Vector3.Distance(Earth.transform.position, Moon.transform.position));
        totalForce += forceDirection * forceAmount;

        Moon.GetComponent<Rigidbody>().AddForce(totalForce, ForceMode.Force);

    }


    float getForce(float mass1, float mass2, float distance)
    {
        return (gravity * mass1 * mass2) / Mathf.Pow(distance, 2);

    }

}
