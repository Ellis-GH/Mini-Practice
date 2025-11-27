using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
