using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public float turnRate = 0.25f;
    private GameObject parent;

    /// <summary>
    /// Grabs a reference to its parent Boid, then sets a preferred direction to dodge other boids.
    /// True is right, false is left.
    /// </summary>
    void Start()
    {
        parent = transform.parent.gameObject;
    }
    //Look into SLERPing for this
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.ClosestPoint(transform.position).x >= transform.localPosition.x || col.ClosestPoint(transform.position).y >= transform.localPosition.y)
        {
            parent.transform.rotation = Quaternion.Euler(0f, 0f, parent.transform.rotation.eulerAngles.z + (turnRate * 3));
            Debug.Log(col.gameObject.name);
        }
        else
        {
            parent.transform.rotation = Quaternion.Euler(0f, 0f, parent.transform.rotation.eulerAngles.z + (-turnRate * 3));
        }   
    }

    void OnTriggerEnter(Collider2D col)
    {
        if (col.transform.parent.parent.name == "Wallz")
        {
            parent.transform.rotation = Quaternion.Inverse(parent.transform.rotation);
        }
    }
}
