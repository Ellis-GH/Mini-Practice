using UnityEngine;
using UnityEngine.UI;

public class DebugUIScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    [SerializeField] Text textBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = GameManagerScript.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Health: " + gameManagerScript.getPlayerHealth() + "\nAmmo: " + gameManagerScript.getAmmoBalance();
    }
}