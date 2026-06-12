using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool pierce;
    private int damage;

    internal IEnumerator LifeTime(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }

    internal void SetDamage(int amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            if (!pierce)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
