using UnityEngine;
using UnityEngine.InputSystem;

public class GunAnimationScript : MonoBehaviour
{
    private Transform playerPos;
    SpriteRenderer spriteRenderer;

    [SerializeField] float armLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindWithTag("Player").transform; //as long as only the play has this tag
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Going to move the gun!");
        Vector2 cursorScreenPos = Mouse.current.position.ReadValue();
        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(cursorScreenPos);
        cursorWorldPos.z = 0; //We're 2D
        //Debug.Log("CursorWorldPos is: " + cursorWorldPos + " playerPos is: " + playerPos.position);
        Vector3 directionToCursor = (cursorWorldPos - playerPos.position).normalized;
        Vector3 gunPos = directionToCursor * armLength;
        //Debug.Log("Gun pos is: " + gunPos);
        transform.localPosition = gunPos;

        float gunRotation = Mathf.Atan2(directionToCursor.y, directionToCursor.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, gunRotation+180);

        if(Vector2.Dot(transform.up, Vector2.right) > 0) { //Put gun behind player when up
            spriteRenderer.sortingOrder = 0;
        } else {
            spriteRenderer.sortingOrder = 2;
        }

        if (Vector2.Dot(transform.right, Vector2.right) < 0) { //Flip gun on the other half 
            spriteRenderer.flipY = true;
        } else {
            spriteRenderer.flipY = false;
        }


        //Debug.Log("Direction to cursor: " + directionToCursor + " distance to cursor: " + Vector3.Distance(playerPos.position, cursorWorldPos));
    }
}
