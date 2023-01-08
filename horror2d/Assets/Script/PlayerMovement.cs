using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class PlayerMovement : MonoBehaviour
{

    private float Hinput;
    public float speed = 8f; //public can change the speed
    public float jumpSpeed = 6f;

    //public HealthBar healthBar;

    private float direction = 0f; //negative for left(a) and positive for right(d)
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public Animator playerAnimation;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private bool Dead;

    public TextMeshProUGUI checkPointText;

    //soundeffects
    [SerializeField] public AudioSource jumpEffect;
   






    private Rigidbody2D player; //access component to change movement or velocity

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();

        respawnPoint = transform.position;

        
    }

    //repeating
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //find the position of the player feet's and draw a circle of the player feet's

        direction = Input.GetAxisRaw("Horizontal"); //left and right 
        Debug.Log(direction);

        if (direction > 0f) //D KEY (POSITIVE NUMBER) 
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y); //change y axis
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-1f, 1f); //change the x-axis 
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround == true)
        {

            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            jumpEffect.Play();
           

        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("IsOnGround", isTouchingGround);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        // the player position on the x axis and y axis 
        //follow the player on the x axis but
        //on the y axis its just going to keep its current position, its not gonna top or down. 
    
   
    }

   

    private void OnTriggerEnter2D(Collider2D collision) //whenever the player has entered another collider as collision. its change the position of the player
    {
        if (collision.tag == "FallDetector")
            
        {
            
            transform.position = respawnPoint;
           
            //respawn point at the start of the game.. diatas yang void Start
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
            checkPointText.gameObject.SetActive(true);
            
            
            
        }
        else if (collision.tag == "Spike")
        {
            
            player.transform.position = respawnPoint;
           



        }
        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            //SceneManager.LoadScene(1); // 1 it is specific index number
            respawnPoint = transform.position;
            //IN THE BUILD SETTINGS, theres index number on the left side
            // scene/first ...0  scene/second ...1 
            //just if you want to go the next level, it means just add +1 so = 2
            
        }

    {

        

    }

   

}

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.tag == "CheckPoint")
        {
            checkPointText.gameObject.SetActive(false);
        }
    }








}
