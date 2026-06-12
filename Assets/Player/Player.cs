using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public float speed = 5.0f;
    public GameObject healthBar;
    public List<GameObject> weapons;
    public int maxWeapons = 4; // not used
    public GameObject levelUpPrefab;
    public GameObject deathScreenPrefab;
    private HealthBar healthBarScript;
    private Vector2 direction = Vector2.down;
    private int experience = 0;
    private int level = 1;
    private Rigidbody2D rb;
    private Animator anim;
    private bool goingRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBarScript = healthBar.GetComponent<HealthBar>();
        healthBarScript.SetMaxHealth(health);
    }

    private void FixedUpdate()
    {
        Vector2 dir = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dir != Vector2.zero)
        {
            anim.SetFloat("Horizontal", dir.x);
            anim.SetFloat("Vertical", dir.y);
            direction = dir;
        }
        if (dir.x < 0 && goingRight)
        {
            Mirror();
        }
        else if (dir.x > 0 && !goingRight)
        {
            Mirror();
        }
        anim.SetFloat("Velocity", dir.magnitude);
        rb.velocity = dir.normalized * speed;
    }

    private void AddWeapon(GameObject weaponPrefab)
    {
        GameObject weapon = Instantiate(weaponPrefab, gameObject.transform);
        weapons.Add(weapon);
        weapon.transform.localPosition = Vector3.zero;
        weapon.name = weaponPrefab.name;
    }

    internal void AddExperience(int experience)
    {
        this.experience += experience;
        if (this.experience >= (int)(10 * 1.5f * level))
        {
            this.experience -= (int)(10 * 1.5f * level);
            level++;
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            Instantiate(levelUpPrefab, canvas.transform);
            GameObject.FindGameObjectWithTag("GameTimer").GetComponent<Timer>().timeMultiplier = 0;
        }
    }

    // not used
    internal bool CanAddWeapon()
    {
        return weapons.Count < maxWeapons;
    }

    internal void TakeDamage(int damage)
    {
        health -= damage;
        if (!healthBarScript.AddHealth(-damage))
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            Instantiate(deathScreenPrefab, canvas.transform);
            GameObject.FindGameObjectWithTag("GameTimer").GetComponent<Timer>().timeMultiplier = 0;
        }
    }

    internal Vector2 GetDirection()
    {
        return direction;
    }

    private void Mirror()
    {
        goingRight = !goingRight;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    internal void AddOrUpgradeWeapon(GameObject weapon)
    {
        foreach (GameObject w in weapons)
        {
            if (w.name == weapon.name)
            {
                w.GetComponent<Weapon>().Upgrade();
                return;
            }
        }
        AddWeapon(weapon);
    }
}
