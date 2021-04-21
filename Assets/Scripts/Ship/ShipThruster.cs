using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThruster : MonoBehaviour
{
    public Vector3 force;
    public bool isForce;

    ParticleSystem particles;
    Ship ship;
    bool isOn;
    string identifier;

    void Start(){
        ship = transform.parent.GetComponent<Ship>();
        particles = GetComponent<ParticleSystem>();
        identifier = GetInstanceID().ToString();
    }
    //the two functions just start the particle system when the thrusters are on and stop the particle system otherwise
    public void StartThrust(){
        if (!isOn){
            particles.Play();
            if (isForce){
                ship.AddForce(identifier, force);
            }
            else
            {
                ship.AddTorque(identifier, force);
            }
            isOn = true;
        }
    }
    public void StopThrust(){
        if (isOn)
        {
            particles.Stop();
            if (isForce)
            {
                ship.RemoveForce(identifier);
            }
            else
            {
                ship.removeTorque(identifier);
            }
            isOn = false;
        }
    }
}
