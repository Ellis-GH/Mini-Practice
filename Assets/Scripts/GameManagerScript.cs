using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = maxPlayerHealth;
        ammoBalance = maxAmmoBalance; //not permanent I think
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [SerializeField] int maxPlayerHealth = 10;
    private int playerHealth;
    public int getAmmoBalance() { return ammoBalance; }
    public void setAmmoBalance(int newAmmoBalance) { ammoBalance = Mathf.Clamp(newAmmoBalance, 0, maxAmmoBalance); }
    public void adjustAmmoBalance(int ammoBalanceDelta) { ammoBalance = Mathf.Clamp(ammoBalance + ammoBalanceDelta, 0, maxAmmoBalance); }

    [SerializeField] int maxAmmoBalance = 250; //ammo balance cap
    private int ammoBalance;
    public int getplayerHealth() { return playerHealth; }
    public void setPlayerHealth(int newPlayerHealth) { playerHealth = Mathf.Clamp(newPlayerHealth, 0, maxPlayerHealth); }
    public void adjustPlayerHealth(int playerHealthDelta) { playerHealth = Mathf.Clamp(playerHealth + playerHealthDelta, 0, maxPlayerHealth); }
}
