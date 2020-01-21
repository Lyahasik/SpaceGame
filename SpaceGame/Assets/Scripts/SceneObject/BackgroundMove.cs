using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float Speed = 10.0f;
    private Vector3 startPosition;
    private float repeatPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        repeatPosition = Mathf.Repeat(Time.time * Speed, 102.4f);
        transform.position = startPosition + Vector3.back * repeatPosition;
    }
}
