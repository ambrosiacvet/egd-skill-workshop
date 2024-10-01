using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> targets;
    private int targetPoint;

    // Update is called once per frame
    void Update()
    {
        // Move platform toward targets each frame
        transform.position = Vector3.MoveTowards(transform.position, targets[targetPoint].position, speed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        // If platform hits target, switch target
        if (transform.position == targets[targetPoint].position)
        {
            if (targetPoint == targets.Count - 1)
            {
                targetPoint = 0;
            }
            else
            {
                targetPoint += 1;
            }
        }
    }
    
    // If collide with object, make object Child of platform
    // Allows Player to slide with platform
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetParent(transform);
    }
    
    // If object leaves platform, remove Child
    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
