using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject weaponChoicePrefab;

    internal void StartGame()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        Instantiate(weaponChoicePrefab, canvas.transform);
        Destroy(gameObject);
    }
}
