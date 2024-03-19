using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] Vector3 collision = Vector3.zero;
    [SerializeField] private LayerMask objectLayer;
    private string lastHit;

    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, objectLayer))
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
