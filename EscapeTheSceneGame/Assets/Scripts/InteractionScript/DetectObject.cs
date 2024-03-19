using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] Vector3 collision = Vector3.zero;
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float distance;
    private string lastHit;

    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, objectLayer))
        {
            lastHit = hit.transform.gameObject.name;
            collision = hit.point;
            Debug.Log(lastHit);
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }
}
