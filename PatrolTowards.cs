using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolTowards : MonoBehaviour
{
   
    [SerializeField] float minX, maxX, minY, maxY, speed, rotSpeed;
    public float secondstoMaxdifficulty;
    public float minspeed, maxspeed;
    [SerializeField] private Transform target;
    private Vector2 center = Vector2.zero;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        var step = speed * Time.deltaTime;

        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            
        }

    }
}
