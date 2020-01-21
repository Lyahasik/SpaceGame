using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableApply : MonoBehaviour
{
    private Action<GameObject> application = (player) => {};
	private Action<GameObject>[] listApplications;

    public enum ApplyConsumable
    {
        GunBase = 0,
        GunExtra = 1,
        GunBonus = 2,
        FixShip = 3,
        replenishShield = 4
    };

    public ApplyConsumable TypeConsumable;
    public string ChargeName;
    public int Points;
    public int quantityCartriges = 15;

	void Start()
	{
		listApplications = new Action<GameObject>[]{
            gunBase,
            gunExtra,
            gunBonus,
            fixShip,
            replenishShield};
	}

	public void Apply(GameObject player)
	{
		application = listApplications[(int)TypeConsumable];
		application(player);
	}

    private void gunBase(GameObject player)
    {
        PlayerShooting shooting = player.GetComponent<PlayerShooting>();
        GameObject[] guns = shooting.GunBase;
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<Base>().RegimeChange(ChargeName);
        }
        shooting.ClipBase(quantityCartriges);
        Destroy(gameObject);
    }
    private void gunExtra(GameObject player)
    {
        PlayerShooting shooting = player.GetComponent<PlayerShooting>();
        GameObject[] guns = shooting.GunExtra;
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<Extra>().RegimeChange(ChargeName);
        }
        shooting.ClipExtra(quantityCartriges);
        Destroy(gameObject);
    }

    private void gunBonus(GameObject player)
    {
        Bonus gun = player.GetComponent<PlayerShooting>()
            .GunBonus.GetComponent<Bonus>();
        gun.Clip(quantityCartriges);
        gun.RegimeChange(ChargeName);
        Destroy(gameObject);
    }

    private void fixShip(GameObject player)
    {
        PlayerLife ship = player.GetComponent<PlayerLife>();
        ship.Health += Points;
        if (ship.Health > ship.MaxHealth)
        {
            ship.Health = ship.MaxHealth;
        }
        GameController.isInstance().UpdateHealth(ship.Health, ship.MaxHealth);
        Destroy(gameObject);
    }

    private void replenishShield(GameObject player)
    {
        PlayerLife ship = player.GetComponent<PlayerLife>();
        ship.Shield += Points;
        if (ship.Shield > ship.MaxShield)
        {
            ship.Shield = ship.MaxShield;
        }
        GameController.isInstance().UpdateShield(ship.Shield, ship.MaxShield);
        Destroy(gameObject);
    }
}
