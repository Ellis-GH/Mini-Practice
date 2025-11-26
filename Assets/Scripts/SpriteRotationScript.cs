using UnityEngine;

public class SpriteRotationScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] sprites;

    public enum Direction
    {
        Up = 0,
        Down = 2, 
        Left = 1, 
        Right = 2,
    } // ORDER: UpLeft, UpRight, DownLeft, DownRight
    private Direction horizontalDirection = Direction.Left; //L/R
    private Direction verticalDirection = Direction.Down; //U/D

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetOrientation(Vector2 moveInput)
    {
        if(moveInput.x < 0) { horizontalDirection = Direction.Left; }
        else if(moveInput.x > 0) { horizontalDirection = Direction.Right; }
        if (moveInput.y < 0) { verticalDirection = Direction.Down; }
        else if (moveInput.y > 0) { verticalDirection = Direction.Up; }

        spriteRenderer.sprite = sprites[((int)horizontalDirection + (int)verticalDirection) - 1]; //-1 bc array is 0-3, not 1-4
    }
}
