using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_1 : ShipLife
{
    public GameObject[] GunBase;

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        Step();
        foreach (GameObject gun in GunBase)
        {
            gun.GetComponent<Base>().Fire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckTrigger(other);
    }
}
