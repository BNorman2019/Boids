using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoid : MonoBehaviour
{
    BoidManager manager;
    float alignmentSpeed = 0.02f;
    float cohesionRotate = 0.002f;
    float separationRotate = 0.15f;
    List<Transform> boidNeighbors = new List<Transform>();
    Vector3 velocity = new Vector3();
    Rigidbody2D body;
    LineRenderer liner;
    bool visualize = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Boid Manager").GetComponent<BoidManager>();
        liner = gameObject.AddComponent<LineRenderer>();
        //velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * 4;

        //Rotate towards the center of flock mass
        Quaternion rot = Quaternion.LookRotation(transform.position - (Vector3)manager.avgPosition, Vector3.forward);
        Quaternion temp = Quaternion.Slerp(transform.rotation, rot, alignmentSpeed);
        transform.eulerAngles = new Vector3(0, 0, temp.eulerAngles.z);

        //Rotate towards the average heading of all boids
        temp = Quaternion.Slerp(transform.rotation, manager.avgRotQuat, cohesionRotate);
        transform.eulerAngles = new Vector3(0f, 0f, temp.eulerAngles.z);


    }
}
