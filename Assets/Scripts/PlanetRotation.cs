using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public GameObject planetObject;
    public Vector3 roatationVector;

    // Update is called once per frame
    void Update()
    {
        planetObject.transform.Rotate(roatationVector * Time.deltaTime);
    }

}
