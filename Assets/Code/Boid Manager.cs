using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public List<Boid> boids;
    public int numBoids = 10;


    // Start is called before the first frame update
    void Start()
    {
        for (numBoids; numBoids > 0; numBoids--)
        {
            Boid a = Boid();
            boids.Add(a);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
