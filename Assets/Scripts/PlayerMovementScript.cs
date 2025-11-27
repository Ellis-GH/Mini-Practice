using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRotationScript spriteRotator;

    private InputSystem_Actions controls;
    private Vector2 moveInput;

    [SerializeField] float movementSpeed = 5f;

    ShootingScript shootingScript;

    private void Awake()
    {
        controls = new InputSystem_Actions();

        //Not sure what these 2 lines do exactly
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        rb = GetComponent<Rigidbody2D>();
        spriteRotator = GetComponent<SpriteRotationScript>();

        shootingScript = GetComponent<ShootingScript>();
    }
    private void OnEnable()
    {
        controls.Player.Attack.performed += OnLeftClick;
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * movementSpeed * Time.deltaTime); //Move player

        Vector2 cursorScreenPos = Mouse.current.position.ReadValue();
        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(cursorScreenPos);
        cursorWorldPos.z = 0; //We're 2D
        Vector3 directionToCursor = (cursorWorldPos - transform.position).normalized;
        spriteRotator.SetOrientation(directionToCursor); //Rotate player

        //if(moveInput.magnitude != 0) { spriteRotator.SetOrientation(moveInput); }

        //Debug.Log("Move input is: " + moveInput);
        //Time.deltaTime is a small number, like 0.01, but is tied to framerate, or the change in time between now and the last frame.
        //If not multiplied in, the player will move at [movementSpeed] every frame, which means they move slower at a slow framerate.
    }

    private void OnLeftClick(InputAction.CallbackContext ctx)
    {
        shootingScript.Fire();
    }

    public void setMovementSpeed( float newMovementSpeed){ movementSpeed = newMovementSpeed; }
    public float getMovementSpeed(){ return movementSpeed; }
}
