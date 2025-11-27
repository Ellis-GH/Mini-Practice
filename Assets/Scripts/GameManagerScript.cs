using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerMovementScript playerMovementScript;
    SceneManagerScript sceneManagerScript;

    private int currentLevel = 0;//Shop scene atm

    private float playerMovementSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        sceneManagerScript = FindAnyObjectByType<SceneManagerScript>();

        playerMovementScript.setMovementSpeed(playerMovementSpeed);

        playerHealth = maxPlayerHealth;
        ammoBalance = maxAmmoBalance; //not permanent I think
    }

    public void LoadNextLevel()
    {
        sceneManagerScript.GoToLevel(currentLevel+1);
    }

    public void LoadShopScene()
    {
        sceneManagerScript.GoToLevel(0);
    }

    public void AdjustPlayerSpeed( float speedDelta)
    {
        playerMovementSpeed += speedDelta;
        if(playerMovementScript) { playerMovementScript.setMovementSpeed(playerMovementSpeed); }
        
    }

    [SerializeField] int maxPlayerHealth = 10;
    private int playerHealth;
    public int getAmmoBalance() { return ammoBalance; }
    public void setAmmoBalance(int newAmmoBalance) { ammoBalance = Mathf.Clamp(newAmmoBalance, 0, maxAmmoBalance); }
    public void adjustAmmoBalance(int ammoBalanceDelta) { ammoBalance = Mathf.Clamp(ammoBalance + ammoBalanceDelta, 0, maxAmmoBalance); }

    [SerializeField] int maxAmmoBalance = 250; //ammo balance cap
    private int ammoBalance;
    public int getPlayerHealth() { return playerHealth; }
    public void setPlayerHealth(int newPlayerHealth) { playerHealth = Mathf.Clamp(newPlayerHealth, 0, maxPlayerHealth); }
    public void adjustPlayerHealth(int playerHealthDelta) { playerHealth = Mathf.Clamp(playerHealth + playerHealthDelta, 0, maxPlayerHealth); }

    private int attackDamage;
    public int getAttackDamage() { return attackDamage; }
    public void setAttackDamage(int newAttackDamage) { attackDamage = newAttackDamage; }
    public void adjustAttackDamage(int attackDamageDelta) { attackDamage += attackDamageDelta; }
}
