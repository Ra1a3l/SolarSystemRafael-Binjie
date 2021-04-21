using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitMoon : MonoBehaviour
{
    public GameObject Earth;
    public Transform target;
    public float RotationSpeed;
    public float OrbitDegrees;
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = RotatePointAroundPivot(transform.position,
                           transform.parent.position,
                           Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));
    }
}

