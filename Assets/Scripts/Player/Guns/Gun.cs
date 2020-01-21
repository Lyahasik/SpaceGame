using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    public List<ChargeType> ChargeTypes;
    internal Transform volley;
    internal ChargeType chargeType;
    internal float nextShot;

    private void Start()
    {
        volley = gameObject.transform.Find("Volley");
        nextShot = Time.time;
        chargeType = ChargeTypes[0];
    }

    public void RegimeChange(string name)
    {
        foreach (ChargeType type in ChargeTypes)
        {
            if (type.Name == name)
            {
                chargeType = type;
                break ;
            }
        }
    }

    public bool Fire()
    {
        if (Time.time > nextShot)
        {
            Instantiate(
                chargeType.Object,
                new Vector3(
                    volley.position.x,
                    volley.position.y,
                    volley.position.z),
                volley.rotation);
            nextShot = Time.time + chargeType.Delay;
            return (true);
        }
        return (false);
    }
}
