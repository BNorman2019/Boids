using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boid : MonoBehaviour
{
    //public bool leader = false;
    BoidManager manager;
    float rotateSpeed = 0.05f;
    List<Transform> boidNeighbors = new List<Transform>();
    Vector3 velocity = new Vector3();
    Rigidbody2D body;
    LineRenderer liner;
    bool visualize = false;

    public void UpdateBoid()
    {
        //Move forward
        body.velocity = transform.up * 2;

        //Rotate towards the center of flock mass
        Quaternion rot = Quaternion.LookRotation(transform.position - (Vector3)manager.avgPosition, Vector3.forward);
        Quaternion temp = Quaternion.Slerp(transform.rotation, rot, rotateSpeed);
        transform.eulerAngles = new Vector3(0, 0, temp.eulerAngles.z);

        //Rotate towards the average heading of all boids
        temp = Quaternion.Slerp(transform.rotation, manager.avgRotQuat, rotateSpeed);
        transform.eulerAngles = new Vector3(0f, 0f, temp.eulerAngles.z);


        ////Visualize center of flock mass.
        //if (visualize == true)
        //{
        //    List<Vector3> pos = new List<Vector3>
        //    {
        //        new Vector3(transform.position.x, transform.position.y),
        //        new Vector3(manager.GetComponent<BoidManager>().avgPosition.x, manager.GetComponent<BoidManager>().avgPosition.y)
        //    };
        //    liner.startWidth = 0.25f;
        //    liner.endWidth = 0.25f;
        //    liner.SetPositions(pos.ToArray());
        //    liner.useWorldSpace = true;
        //}
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Boid Manager").GetComponent<BoidManager>();
        liner = gameObject.AddComponent<LineRenderer>();
        //velocity = Vector3.zero;
    }
}
