using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] GunBase;
    [Space]
    public GameObject[] GunExtra;
    public GameObject GunBonus;
    private int clipBase;
    private int clipExtra;

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        if (Input.GetButton("Fire1"))
        {
            foreach (GameObject gun in GunBase)
            {
                if (gun.GetComponent<Base>().Fire())
                {
                    clipBase--;
                    if (clipBase <= 0)
                    {
                        gun.GetComponent<Base>().RegimeChange("Base_1");
                    }
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (clipExtra > 0)
            {
                foreach (GameObject gun in GunExtra)
                {
                    if (gun.GetComponent<Extra>().Fire())
                    {
                        clipExtra--;
                    }
                }
            }
        }
    }

    public void ClipBase(int quantityCartriges)
    {
        clipBase = quantityCartriges;
    }

    public void ClipExtra(int quantityCartriges)
    {
        clipExtra = quantityCartriges;
    }
}
