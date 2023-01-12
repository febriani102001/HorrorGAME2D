using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField] float moveSpeed;

    [SerializeField] GameObject Enemy;

    private void Start()
    {
        
    }

    private void Update()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);
        print("disToPlayer: " + disToPlayer);

        if(disToPlayer < agroRange)

        {
            ChasePlayer();
        }
        else
        {

            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            Enemy.transform.position = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if(transform.position.x > player.position.x)
        {
            Enemy.transform.position = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
           
        }
    }

    private void StopChasingPlayer()
    {
        Enemy.transform.position = new Vector2(0, 0);
    }
}
