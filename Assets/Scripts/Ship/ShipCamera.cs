using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    //Target of the Camera
    public Transform target;
    //How far behind the camera is relative to the target
    public Vector3 offset;
    //sensitivity of the camera movement
    public float flollowSpeed = 5;
    public float lookSpeed = 20;

    Vector3 orbit;
    Quaternion targetRotation;
    Vector3 targetPos;

    void FixedUpdate()
    {
        Orbit();
        MoveToTarget();
        LookAtTarget();
    }
    //Moves the camera so that it floows the target
    void MoveToTarget()
    {
        Vector3 v = transform.rotation.eulerAngles;
        targetPos = Quaternion.Euler(orbit.x, orbit.y, v.z)* offset;
        targetPos += target.position;
        //Lerp is used to smooth the movement of the camera
        transform.position = Vector3.Lerp(transform.position, targetPos, flollowSpeed * Time.deltaTime);
    }
    //The camera is always looking at the target
    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }
    //allows the player to orbit the camera around the target by using the mouse(dragging)
    void Orbit()
    {
        if (Input.GetMouseButton(0)){
            orbit.x -= Input.GetAxis("Mouse Y") * 5;
            orbit.y += Input.GetAxis("Mouse X") * 5;
        }
    }
}
