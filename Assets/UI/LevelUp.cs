using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public GameObject[] weaponsPrefabs;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    internal void WeaponChoise(int weaponIndex)
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.AddOrUpgradeWeapon(weaponsPrefabs[weaponIndex]);
        GameObject.FindGameObjectWithTag("GameTimer").GetComponent<Timer>().timeMultiplier = 1;
        Destroy(gameObject);
    }
}
