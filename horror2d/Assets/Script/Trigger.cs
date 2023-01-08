using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{

    public GameObject jumpscare;
   

    void Start()
    {
       
        jumpscare.SetActive(false); //pertama mati
        


    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            jumpscare.gameObject.SetActive(true);
            

            StartCoroutine(EndJumpscare());
            

            

        }

            
    }

 

    IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(0.5f);
        jumpscare.gameObject.SetActive(false);
        Destroy(gameObject);
        

    }

    
    

    



}
