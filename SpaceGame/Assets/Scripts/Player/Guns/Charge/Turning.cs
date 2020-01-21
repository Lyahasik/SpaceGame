using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour, IObject
{
    public float stepRotate = 50.0f;
    public float speed = 45.0f;

    public enum direction
    {
        Left = -1,
        Right = 1
    };

    public direction directionRotate;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(
            0,
            transform.rotation.eulerAngles.y,
            0);
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
        transform.rotation *= Quaternion.Euler(
            0,
            stepRotate * Time.deltaTime * (int)directionRotate,
            0);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
