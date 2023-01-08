using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float Hinput;
    public float speed;

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Hinput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * Hinput * speed);

    }
}
