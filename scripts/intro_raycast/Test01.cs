using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test01 : MonoBehaviour
{

    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore))
        {
            print(hitInfo.collider.gameObject.name);
            Destroy(hitInfo.collider.gameObject);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        } else
        {
            Debug.DrawLine(ray.origin,ray.direction * 100, Color.green);
        }
    }
}
