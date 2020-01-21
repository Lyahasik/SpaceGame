using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagging : MonoBehaviour, IObject
{
    public float stepRotate = 50.0f;
    public float speed = 45.0f;
    public int maxStepRotate = 30;
    private int numberStepRotate;
    private Vector3 direction;

    private void Start()
    {
        numberStepRotate = maxStepRotate / 2;
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
        if (numberStepRotate++ == maxStepRotate)
        {
            stepRotate = -stepRotate;
            numberStepRotate = 0;
        }
        transform.rotation *= Quaternion.Euler(0, stepRotate * Time.deltaTime, 0);
        direction = Vector3.Normalize(
            new Vector3(
                transform.forward.x,
                0,
                transform.forward.z));
        transform.position += direction * speed * Time.deltaTime;
    }
}
