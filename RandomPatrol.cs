using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : MonoBehaviour
{

    [SerializeField] float minX, maxX, minY, maxY, speed, rotSpeed;
    Vector2 targetPosition;
    public Vector3 Rotdirection;
   
  
    public float secondstoMaxdifficulty;
    public float minspeed, maxspeed;
    void Start()
    {
       
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
            transform.Rotate(rotSpeed * Rotdirection * Time.deltaTime);
        
      
        if((Vector2)transform.position!= targetPosition)
        {
            speed = Mathf.Lerp(minspeed,maxspeed,GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed *Time.deltaTime);
        }
        else { targetPosition=GetRandomPosition();}
    }

    Vector2 GetRandomPosition()
    {
        float randomX= Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);

    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondstoMaxdifficulty);
    }

   
}
