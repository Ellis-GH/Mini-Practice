using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private float distance;

    void Awake()
    {
        // rb = GetComponent<Rigidbody2D>();
        // player = GameObject.FindWithTag("Player");
    }


    void FixedUpdate()
    {
        // Gets the distance between the enemy and player and returns it as a float
        //distance = Vector2.Distance(transform.position, player.transform.position);

        // Returns the direction that the enemy will be moving towards
        // Vector2 direction = player.transform.position - transform.position;


        // Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // rb.MovePosition(newPosition);

       
    }
}
