using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direct : MonoBehaviour, IObject
{
    private Vector3 direction;
    public float speed = 45.0f;

    private void Start()
    {
        direction = Vector3.Normalize(
            new Vector3(
                transform.forward.x,
                0,
                transform.forward.z));
    }

    private void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        Step();
    }

    public void Step()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
