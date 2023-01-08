using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public bool Dead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision) //kena spike mati
    {
  
        if (collision.tag == "Spike")
        {
            Die();
            print("Die");
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        GetComponent<PlayerMovement>().enabled = false;
        Dead = true;
        rb.bodyType = RigidbodyType2D.Static;


    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    


}
