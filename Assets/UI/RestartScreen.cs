using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    internal void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
