using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int MaxShield = 50;
    [System.NonSerialized]
    public int Shield;
    public int MaxHealth = 100;
    [System.NonSerialized]
    public int Health;
    public float Speed = 10;
    public GameObject PlayerExplosion;
    private Rigidbody myRigidbody;
    private float xAxis, zAxis, xBorder, zBorder;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Health = MaxHealth;
    }

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector3(
            xAxis * Speed,
            0,
            zAxis * Speed);
        myRigidbody.rotation = Quaternion.Euler(
            0,
            0,
            -xAxis * Speed);

        xBorder = Mathf.Clamp(transform.position.x, -25.0f, 25.0f);
        zBorder = Mathf.Clamp(transform.position.z, -38.0f, 35.0f);

        transform.position = new Vector3(xBorder, 0, zBorder);
    }

    public void Collision(int damage)
    {
        Shield -= damage;
        if (Shield < 0)
        {
            Health += Shield;
            Shield = 0;
        }
        GameController.isInstance().UpdateHealth(Health, MaxHealth);
        GameController.isInstance().UpdateShield(Shield, MaxShield);
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
            Invoke("gameOver", 1.5f);
        }
    }

    private void gameOver()
    {
        GameController.isInstance().GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargeOpponents"))
        {
            Collision(other.GetComponent<ChargeAttribute>().Damage);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Consumable"))
        {
            other.GetComponent<ConsumableApply>().Apply(gameObject);
        }
    }
}
