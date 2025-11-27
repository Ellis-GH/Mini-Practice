using UnityEngine;

public class ShopScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    int cost = 0; //Cost to be determined by the level

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyHealth()
    {
        if(gameManagerScript.getAmmoBalance() >= cost)
        {
            gameManagerScript.adjustAmmoBalance(-cost);
            gameManagerScript.adjustPlayerHealth(1);
            Debug.Log("Buying Health for: " + cost);
        }
    }

    public void BuyDamage()
    {
        if (gameManagerScript.getAmmoBalance() >= cost)
        {
            gameManagerScript.adjustAmmoBalance(-cost);
            gameManagerScript.adjustAttackDamage(1);
            Debug.Log("Buying Damage for: " + cost);
        }
    }

    public void BuySpeed()
    {
        if (gameManagerScript.getAmmoBalance() >= cost)
        {
            gameManagerScript.adjustAmmoBalance(-cost);
            gameManagerScript.AdjustPlayerSpeed(1); 
            Debug.Log("Buying Speed for: " + cost);
        }
    }
}
