using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    [SerializeField] Text costText;
    [SerializeField] Text ammoText;

    int cost = 0; //Cost to be determined by the level

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();

        costText.text = "Cost\n" + cost;
        ammoText.text = "Ammo\n" + gameManagerScript.getAmmoBalance();
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
