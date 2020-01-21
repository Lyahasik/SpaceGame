using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float Speed = 10.0f;

    private void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        step();
    }

    private void step()
    {
        transform.position += -Vector3.forward * Speed * Time.deltaTime;
    }
}
