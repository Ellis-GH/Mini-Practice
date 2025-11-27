using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;
    private int health;
    [SerializeField] float detectionRange = 100;
    [SerializeField] float movementSpeed = 5;
    [SerializeField] int damage = 1;

    NavMeshAgent agent;
    PlayerMovementScript playerMovementScript;

    LayerMask layerMask;

    Vector3 lastPos;

    SpriteRotationScript spriteRotator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        spriteRotator = GetComponent<SpriteRotationScript>();

        health = maxHealth;
        agent.speed = movementSpeed;

        layerMask = ~LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerMovementScript.transform.position;
        Vector2 directionToPlayer = playerPos - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, layerMask);
        if (hit)
        {
            //Debug.Log("Hit! " + hit.collider.tag);
            if (hit.collider.CompareTag("Player"))
            {
                agent.destination = playerPos;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.position - lastPos;
        spriteRotator.SetOrientation(moveDirection);

        lastPos = transform.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getAttackDamage() { return damage; }
}
