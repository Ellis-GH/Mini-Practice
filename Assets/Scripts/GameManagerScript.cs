using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerMovementScript playerMovementScript;
    SceneManagerScript sceneManagerScript;

    int lvlOneSceneNum = 2;

    private int currentLevel = 1;

    private float playerMovementSpeed = 5;

    public static GameManagerScript Instance;
    void Awake() //Make this object a singleton (only one exists, and always does)
    {
        // Make sure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        sceneManagerScript = GetComponent<SceneManagerScript>();

        if (playerMovementScript) { playerMovementScript.setMovementSpeed(playerMovementSpeed); }

        playerHealth = startPlayerHealth;
        ammoBalance = startAmmoBalance; //not permanent I think
    }

    public void LoadFirstLevel()
    {
        sceneManagerScript.GoToLevel(lvlOneSceneNum);
        currentLevel += 1;
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

    [SerializeField] int startPlayerHealth = 5;
    private int playerHealth;
    public int getAmmoBalance() { return ammoBalance; }
    public void setAmmoBalance(int newAmmoBalance) { ammoBalance = Mathf.Clamp(newAmmoBalance, 0, 100); }
    public void adjustAmmoBalance(int ammoBalanceDelta) { ammoBalance = Mathf.Clamp(ammoBalance + ammoBalanceDelta, 0, 100); }

    [SerializeField] int startAmmoBalance = 12; //ammo balance cap
    private int ammoBalance;
    public int getPlayerHealth() { return playerHealth; }
    public void setPlayerHealth(int newPlayerHealth) { playerHealth = Mathf.Clamp(newPlayerHealth, 0, 100); }
    public void adjustPlayerHealth(int playerHealthDelta) 
    { 
        playerHealth = Mathf.Clamp(playerHealth + playerHealthDelta, 0, 100); 
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

    public int GetCurrentLevel() { return currentLevel; }
}
