using UnityEngine;

public class Sword : Weapon
{
    override protected void Fire()
    {
        Vector3 direction = player.GetComponent<Player>().GetDirection();
        CreateBullet(direction, true);
    }
}
