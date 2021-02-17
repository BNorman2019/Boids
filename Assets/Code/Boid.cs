using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Boid()
    {

    }

    private void OnTriggerEnter()
    {
        Vector3 pos = someRenderer.transform.position;
        Bounds bounds = myBoxCollider.bounds;
        bool rendererIsInsideTheBox = bounds.Contains(pos);
    }

    private RaycastHit GetRaycast()
    {
        RaycastHit hit;
        Ray ray = Physics.Raycast(this.gameObject.transform.position, direction, maxDistance = Mathf.Infinity, , QueryTriggerInteraction.UseGlobal);
        Physics.Raycast(ray, out hit);
        return hit;
    }
}
