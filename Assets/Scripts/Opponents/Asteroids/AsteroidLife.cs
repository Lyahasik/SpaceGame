using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : Opponent
{
    public float minSpeed = 1.0f;
    public float maxSpeed = 3.0f;
    private float speed;
    private Vector3 stepRotate;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        stepRotate = Random.insideUnitSphere * speed * 15.0f;
    }

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        Step();
    }

    public void Step()
    {
        transform.rotation *= Quaternion.Euler(
            stepRotate.x * Time.deltaTime,
            stepRotate.y * Time.deltaTime,
            stepRotate.z * Time.deltaTime);
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameZone") || other.CompareTag("Asteroid"))
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
    }
}
