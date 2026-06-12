using UnityEngine;

public class Fireball : Weapon
{
    override protected void Fire()
    {
        Vector3 direction = new(Random.Range(-1f,1), Random.Range(-1f,1));
        CreateBullet(direction, true);
    }
}
