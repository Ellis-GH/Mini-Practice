using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioClip gameOverSound;

    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(gameOverSound, transform, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
