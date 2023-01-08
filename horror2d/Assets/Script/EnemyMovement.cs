using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float MoveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

   
  
    void Update()
    {

        
        if (isChasing)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if(transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            }
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
        }

        if (patrolDestination == 0) 
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, MoveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) 
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, MoveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 0;
            }
        }
    }
}
