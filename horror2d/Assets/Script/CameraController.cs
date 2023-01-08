using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player;

    //can see the further
    public float offset; 
    public float offsetSmoothing; //public can adjust the values, but its up to you~ just in case

    private Vector3 playerPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);// camera position gonna match the position player(follos the player position)

        if(player.transform.localScale.x > 0f) //greater than 0, looking right
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

    }
}
