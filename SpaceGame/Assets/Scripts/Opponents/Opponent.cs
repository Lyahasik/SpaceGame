using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Opponent : MonoBehaviour
{
    public int Score = 1;
    public int Health = 1;
    public int DamageCollision = 10;
    public GameObject TargetExplosion;

    private void takeDamage(int damage)
    {
        Health -= damage;
    }

    public void collisionChargePlayer(Collider other)
    {
        takeDamage(other.GetComponent<ChargeAttribute>().Damage);
        Destroy(other.gameObject);
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(TargetExplosion, transform.position, Quaternion.identity);
            GetComponent<ConsumableSpawn>().Spawn();
            GameController.isInstance().UpdateScore(Score);
        }
    }

    public void collisionPlayer(Collider other)
    {
        Destroy(gameObject);
        Instantiate(TargetExplosion, transform.position, Quaternion.identity);
        other.GetComponent<PlayerLife>().Collision(DamageCollision);
    }
}
