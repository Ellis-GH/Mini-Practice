using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingScript : MonoBehaviour
{
    // Shooting is triggered in the PlayerMovementScript

    //cooldown, play animation

    [SerializeField] float bulletRange = 100;

    [SerializeField] float fireCooldown = 1;
    bool onCooldown = false;

    GameManagerScript gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LayerMask layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask(""); //Can be used to exclude layers from raycast collision
        gameManager = FindAnyObjectByType<GameManagerScript>();
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

            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToCursor);
            if(hit)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    // Get the enemy's script, deal damage to them
                }
            }
        }
        else if(gameManager.getAmmoBalance() <= 0) { Debug.Log("Click... no bullets ;("); }
        else { Debug.Log("On cooldown!"); }
    }

    IEnumerator FireCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(fireCooldown);
        onCooldown = false;
    }
}
