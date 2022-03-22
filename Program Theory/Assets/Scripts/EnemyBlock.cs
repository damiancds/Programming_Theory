using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : EnemyBase //INHERITANCE
{

    [SerializeField] float torque;
    public float tumblingDuration = 0.2f;
    bool isTumbling = false;

    void Start()
    {
        Initialize();   
    }
    void Update()
    {
        Move(FindPlayer());
        CheckDeath();
    }

    public override void Move(Vector3 target) //POLYMORPHISM
    {
        var dir = Vector3.zero;
        if ((target.x > target.y && target.x > target.z) || (target.x < target.y && target.x < target.z))
            dir = new Vector3(target.x, 0, 0);
        if ((target.y > target.x && target.y > target.z) || (target.y < target.x && target.y < target.z))
            dir = new Vector3(0, target.y, 0);
        if ((target.z > target.y && target.z > target.x) || (target.z < target.y && target.z < target.x))
            dir = new Vector3(0, 0, target.z);

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }
    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;
        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }

        isTumbling = false;
    }
}

