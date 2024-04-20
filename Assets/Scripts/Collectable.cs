using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);

            if (this.type == CollectableType.Chicken)
            {
                var healthComponent = collision.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.maxHealth += 10;
                    healthComponent.healDamage(10);
                }
            }
            else if (this.type == CollectableType.Weapon)
            {
                var attackComponent = collision.GetComponent<Attack>();
                if (attackComponent != null)
                {
                    attackComponent.addAttack(5);
                }
            }
            else if (this.type == CollectableType.Wine)
            {
                var speedComponent = collision.GetComponent<Speed>();
                if (speedComponent != null)
                {
                    speedComponent.addSpeed(3);
                }
            }
            else if (this.type == CollectableType.LuckyEgg)
            {
                var critComponent = collision.GetComponent<CritChance>();
                if (critComponent != null)
                {
                    critComponent.addCritChance(2);
                }
            }

            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, Chicken, Weapon, Wine, LuckyEgg
}