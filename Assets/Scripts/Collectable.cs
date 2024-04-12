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

            if (this.type == CollectableType.CHICKEN)
            {
                var healthComponent = collision.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.maxHealth += 10;
                    healthComponent.healDamage(10);
                }
            }
            else if (this.type == CollectableType.SWORD)
            {
                var attackComponent = collision.GetComponent<Attack>();
                if (attackComponent != null)
                {
                    attackComponent.addAttack(5);
                }
            }
            else if (this.type == CollectableType.WINE)
            {
                var speedComponent = collision.GetComponent<Speed>();
                if (speedComponent != null)
                {
                    speedComponent.addSpeed(3);
                }
            }

            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, CHICKEN, SWORD, WINE
}