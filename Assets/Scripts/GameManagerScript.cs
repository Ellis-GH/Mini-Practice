using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerMovementScript playerMovementScript;
    SceneManagerScript sceneManagerScript;

    int lvlOneSceneNum = 2;

    private int currentLevel;//Shop scene atm

    private float playerMovementSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        sceneManagerScript = GetComponent<SceneManagerScript>();

        if (playerMovementScript) { playerMovementScript.setMovementSpeed(playerMovementSpeed); }

        playerHealth = maxPlayerHealth;
        ammoBalance = maxAmmoBalance; //not permanent I think
    }

    public void LoadNextLevel()
    {
        sceneManagerScript.GoToLevel(currentLevel+1);
        currentLevel += 1;
    }

    public void LoadFirstLevel()
    {
        sceneManagerScript.GoToLevel(lvlOneSceneNum);
    }

    public void LoadShopScene()
    {
        sceneManagerScript.GoToLevel(1); //Shop scene is assigned as 1
    }

    public void AdjustPlayerSpeed( float speedDelta)
    {
        playerMovementSpeed += speedDelta;
        if(playerMovementScript) { playerMovementScript.setMovementSpeed(playerMovementSpeed); }
    }

    public void GameOver()
    {
        currentLevel = lvlOneSceneNum;
        sceneManagerScript.GoToLevel(0); //Gameover scene is assigned as 0
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
    public void adjustPlayerHealth(int playerHealthDelta) 
    { 
        playerHealth = Mathf.Clamp(playerHealth + playerHealthDelta, 0, maxPlayerHealth); 
        if (playerHealth == 0)
        {
            Debug.Log("Game Over!");
            GameOver();
        }
    }

    [SerializeField] private int attackDamage;
    public int getAttackDamage() { return attackDamage; }
    public void setAttackDamage(int newAttackDamage) { attackDamage = newAttackDamage; }
    public void adjustAttackDamage(int attackDamageDelta) { attackDamage += attackDamageDelta; }
}
