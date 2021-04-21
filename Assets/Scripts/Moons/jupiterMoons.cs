using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jupiterMoons : MonoBehaviour
{
    public GameObject[] Moons;
    Rigidbody forceAmount;
    public float gravity;
    public float JupiterMass;
    public float IOMass = 0.893f;
    public float EuropaMass = 0.47998f;
    public float GanymedeMass = 1.0759f;

    Vector3 IOVelocity = new Vector3(0, 3.45094524521f, 0);
    Vector3 EuropaVelocity = new Vector3(0, 2.78629348443f, 0);
    Vector3 GanymedeVelocity = new Vector3(0, 2.22217813691f, 0);


    // Start is called before the first frame update
    void Start()
    {
        Moons[0].GetComponent<Rigidbody>().mass = IOMass;
        Moons[0].GetComponent<Rigidbody>().velocity = IOVelocity;
        Moons[0].GetComponent<Rigidbody>().mass = EuropaMass;
        Moons[0].GetComponent<Rigidbody>().velocity = EuropaVelocity;
        Moons[0].GetComponent<Rigidbody>().mass = GanymedeMass;
        Moons[0].GetComponent<Rigidbody>().velocity = GanymedeVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject s in Moons)
        {
            Vector3 totalForce = new Vector3(0, 0, 0), forceDirection;
            float forceAmount;
            float moonMass = s.GetComponent<Rigidbody>().mass;

            forceDirection = (transform.position - s.transform.position);
            forceAmount = getForce(moonMass, JupiterMass, Vector3.Distance(transform.position, s.transform.position));
            totalForce += forceDirection * forceAmount;

            s.GetComponent<Rigidbody>().AddForce(totalForce, ForceMode.Force);

        }

    }

    float getForce(float mass1, float mass2, float distance)
    {
        return (gravity * mass1 * mass2 / Mathf.Pow(distance, 2));
    }
}
