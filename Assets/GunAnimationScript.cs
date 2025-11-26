using UnityEngine;
using UnityEngine.InputSystem;

public class GunAnimationScript : MonoBehaviour
{
    private Transform playerPos;

    [SerializeField] float armLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GetComponentInParent<Transform>();
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
    }
}
