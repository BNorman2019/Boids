using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BoidManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public bool advanced;
    public int boidsToGenerate;
    public Vector2 avgPosition;
    public float avgRot;
    public Quaternion avgRotQuat;
    public InputField boidNum;
    public InputField boidSize;
    public GameObject panel;

    public List<GameObject> boids;

    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));

        for (int i = 0; i < boidsToGenerate; i++)
        {
            boids.Add(Instantiate(boidPrefab, position, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        OldUpdate();
    }

    public void Reset()
    {
        foreach (GameObject boid in boids)
        {
            Destroy(boid);
        }
        boids.Clear();

        boidsToGenerate = System.Int32.Parse(boidNum.text);
        boidPrefab.transform.localScale = new Vector3(System.Single.Parse(boidSize.text), System.Single.Parse(boidSize.text));

        Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));

        for (int i = 0; i < boidsToGenerate; i++)
        {
            boids.Add(Instantiate(boidPrefab, position, Quaternion.identity));
        }
        panel.SetActive(false);

    }

    private void OldUpdate()
    {
        List<float> xValues = new List<float>();
        List<float> yValues = new List<float>();
        List<float> rotValues = new List<float>();

        foreach (GameObject boid in boids)
        {
            xValues.Add(boid.transform.position.x);
            yValues.Add(boid.transform.position.y);
            rotValues.Add(boid.transform.eulerAngles.z);
        }

        avgPosition = new Vector2(xValues.Sum() / xValues.Count, yValues.Sum() / yValues.Count);
        avgRot = rotValues.Sum();
        avgRot /= rotValues.Count;
        avgRotQuat = Quaternion.Euler(0f, 0f, avgRot);
        foreach (GameObject boid in boids)
        {
            boid.GetComponent<Boid>().UpdateBoid();
        }
    }
}
