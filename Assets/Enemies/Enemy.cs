using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 10;
    public int experience = 10;
    public float speed = 4f;
    public GameObject healthBar;
    private float distanceToPlayer;
    private GameObject player;
    private HealthBar healthBarScript;
    private EnemySpawner spawner;
    private Rigidbody2D rb;
    private bool goingRight = true;
    private bool inContact = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 dir = player.transform.position - transform.position;
            distanceToPlayer = dir.magnitude;
            if (inContact)
            {
                dir = Vector2.zero;
            }
            rb.velocity = dir.normalized * speed;
            if (dir.x < 0 && goingRight)
            {
                Mirror();
            }
            else if (dir.x > 0 && !goingRight)
            {
                Mirror();
            }
        }
    }

    private IEnumerator DealDamage()
    {
        while (true)
        {
            player.GetComponent<Player>().TakeDamage(damage);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DealDamage());
            inContact = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            inContact = false;
        }
    }

    internal void TakeDamage(int damage)
    {
        if (!healthBarScript.AddHealth(-damage))
        {
            spawner.RemoveEnemy(gameObject);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AddExperience(experience);
        }
    }

    internal void Initiate(EnemySpawner enemySpawner, GameObject playerObject, float multiplier)
    {
        spawner = enemySpawner;
        player = playerObject;
        experience = (int)(experience * multiplier);
        speed *= multiplier;
        damage = (int)(damage * multiplier);
        healthBarScript = healthBar.GetComponent<HealthBar>();
        healthBarScript.SetMaxHealth((int)(health * multiplier));
    }

    private void Mirror()
    {
        goingRight = !goingRight;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    internal float GetDistanceToPlayer()
    {
        return distanceToPlayer;
    }
}
