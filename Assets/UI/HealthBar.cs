using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Transform healthBar;

    internal bool AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            health = 0;
            UpdateHealthBar();
            return false;
        }
        UpdateHealthBar();
        return true;
    }

    internal void SetMaxHealth(int amount)
    {
        maxHealth = amount;
        health = amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {

        float healthRatio = (float)health / (float)maxHealth;
        healthBar.localScale = new Vector3(healthRatio, healthBar.localScale.y, healthBar.localScale.z);
    }
}
