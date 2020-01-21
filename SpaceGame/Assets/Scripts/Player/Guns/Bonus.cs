using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Gun
{
    private int clip;
    private float stepRotate = 50.0f;

    private void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        if (clip > 0)
        {
            if (transform.rotation.y > 0.3826834f
                || transform.rotation.y < -0.3826834f)
            {
                stepRotate = -stepRotate;
            }
            transform.rotation *= Quaternion.Euler(
                0,
                stepRotate * Time.deltaTime,
                0);
            if (Fire())
            {
                clip--;
            }
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    public void Clip(int quantityCartriges)
    {
        clip = quantityCartriges;
    }
}
