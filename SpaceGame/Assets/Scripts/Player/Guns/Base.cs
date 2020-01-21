using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Gun
{
	public void FireAim(Vector3 target)
	{
		transform.LookAt(target);
		if (Time.time > nextShot)
        {
            Instantiate(
				chargeType.Object,
				new Vector3(
					volley.position.x,
					volley.position.y,
					volley.position.z),
				transform.rotation);
            nextShot = Time.time + chargeType.Delay;
        }
	}
}
