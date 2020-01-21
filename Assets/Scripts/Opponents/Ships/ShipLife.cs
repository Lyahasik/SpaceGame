using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : Opponent
{
    public float Speed = 10;
    public int ChangeTrajectory = 30;
    internal int nextTrajectory;
    internal Vector3 trajectory;
    internal float xBorder;

    public void Step()
    {
        if (nextTrajectory++ >= ChangeTrajectory)
        {
            trajectory = Vector3.Normalize(
                new Vector3(
                    Random.Range(-1.0f, 1.0f),
                    0,
                    Random.Range(-1.0f, 0.0f)));
            transform.rotation = Quaternion.Euler(
                0,
                transform.rotation.eulerAngles.y,
                trajectory.x * Speed);
            nextTrajectory = 0;
        }
        transform.position += trajectory * Speed * Time.deltaTime;

        xBorder = Mathf.Clamp(transform.position.x, -25.0f, 25.0f);
        transform.position = new Vector3(
            xBorder,
            0,
            transform.position.z);
    }

    public void CheckTrigger(Collider other)
    {
        if (other.CompareTag("GameZone"))
        {
            return ;
        }
        else if (other.CompareTag("ChargePlayer"))
        {
            collisionChargePlayer(other);
        }
        else if (other.CompareTag("Player"))
        {
            collisionPlayer(other);
        }
        else if (other.CompareTag("Asteroid"))
        {
            collisionAsteroid(other);
        }
    }

    private void collisionAsteroid(Collider other)
    {
        Health -= other.GetComponent<AsteroidLife>().DamageCollision;
        Destroy(other.gameObject);
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(TargetExplosion, transform.position, Quaternion.identity);
        }
    }
}
