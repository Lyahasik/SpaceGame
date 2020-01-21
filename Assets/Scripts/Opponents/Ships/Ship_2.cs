using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_2 : ShipLife
{
    public GameObject Gun;
    private GameObject targetPlayer;

    private void Start()
    {
        targetPlayer = GameObject.Find("Player");
    }

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        Step();
        if (targetPlayer)
        {
            Gun.GetComponent<Base>().FireAim(targetPlayer.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckTrigger(other);
    }
}
