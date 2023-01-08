using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //changing the color of the bar from green to red

    private RectTransform bar;
    private Image barImage;
    private Animator anim;
    private bool dead;
   

    void Start()
    {

        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        SetSize(Health.totalHealth);


        anim = GetComponent<Animator>();
    }

    public void Damage(float damage)
    {
        if((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;

        }
        if(Health.totalHealth < 0.3f )
        {
            barImage.color = Color.red;
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("death");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
           

        }
        SetSize(Health.totalHealth);


       

    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
        // if(Health.totalHealth <= 0)
       // {
          //  Destroy(gameObject);
           // print("You dead");
       // }
    }
}
