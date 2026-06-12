using UnityEngine;

public class HomingOrb : Weapon
{
    override protected void Fire()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().GetClosestEnemy();
        if (enemy == null)
        {
            return;
        }
        Vector3 direction = enemy.transform.position - transform.position;
        CreateBullet(direction, false);
    }
}
