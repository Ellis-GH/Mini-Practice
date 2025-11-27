using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingScript : MonoBehaviour
{
    // Shooting is triggered in the PlayerMovementScript

    //Expanded to be a combat script instead

    //play animation

    [SerializeField] float bulletRange = 100;

    [SerializeField] float fireCooldown = 1;
    bool onCooldown = false;

    [SerializeField] float knockbackDistance = 3;
    [SerializeField] float invincTime = 2;
    bool invincible = false;


    GameManagerScript gameManager;
    GunAnimationScript gunAnimationScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LayerMask layerMask;

    private void Awake()
    {
        layerMask = ~LayerMask.GetMask("Player"); //Can be used to exclude layers from raycast collision
        gameManager = FindAnyObjectByType<GameManagerScript>();
        gunAnimationScript = FindAnyObjectByType<GunAnimationScript>();
    }


    public void Fire()
    {
        if (!onCooldown && gameManager.getAmmoBalance() > 0)
        {
            gameManager.adjustAmmoBalance(-1);
            StartCoroutine("FireCooldown");
            //Gun FX

            Vector2 cursorScreenPos = Mouse.current.position.ReadValue();
            Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(cursorScreenPos);
            cursorWorldPos.z = 0; //We're 2D
            Vector3 directionToCursor = (cursorWorldPos - transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToCursor, bulletRange, layerMask);
            if (hit)
            {
                Debug.Log("Hit! " + hit.collider.tag);
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Hit an enemy!");
                    hit.collider.GetComponent<EnemyScript>().TakeDamage(gameManager.getAttackDamage());
                }
            }
        }
        else if (gameManager.getAmmoBalance() <= 0) { Debug.Log("Click... no bullets ;("); }
        else { Debug.Log("On cooldown!"); }
    }

    IEnumerator FireCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(fireCooldown);
        onCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !invincible)
        {
            Debug.Log("Ow!");
            gameManager.adjustPlayerHealth(-collision.GetComponent<EnemyScript>().getAttackDamage());

            Vector2 dirFromEnemy = (transform.position - collision.transform.position).normalized;

            //GetComponent<Rigidbody2D>().MovePosition(dirFromEnemy * knockbackDistance); //Not working

            StartCoroutine("InvinceTimer");
        }
    }

    IEnumerator InvinceTimer()
    {
        invincible = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(invincTime);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible = false;
    }
}
