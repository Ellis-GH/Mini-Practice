using TMPro;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text ammoText;

    [SerializeField] AudioClip purchaseSound;

    int cost; //Cost to be determined by the level

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = GameManagerScript.Instance;

        cost = gameManagerScript.GetCurrentLevel();

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
            SoundFXManager.instance.PlaySoundFXClip(purchaseSound, transform, 1f);
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

    public void ExitShop()
    {
        gameManagerScript.LoadFirstLevel();
    }
}
