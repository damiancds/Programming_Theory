using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : EnemyBase
{

    [SerializeField] float torque;
    public float tumblingDuration = 0.2f;

    bool isTumbling = false;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();   
    }

    // Update is called once per frame
    void Update()
    {

        var dir = Vector3.zero;
        if ((FindPlayer().x > FindPlayer().y && FindPlayer().x > FindPlayer().z) || (FindPlayer().x < FindPlayer().y && FindPlayer().x < FindPlayer().z))
            dir = new Vector3(FindPlayer().x, 0, 0);
        if ((FindPlayer().y > FindPlayer().x && FindPlayer().y > FindPlayer().z) || (FindPlayer().y < FindPlayer().x && FindPlayer().y < FindPlayer().z))
            dir = new Vector3(0, FindPlayer().y, 0);
        if ((FindPlayer().z > FindPlayer().y && FindPlayer().z > FindPlayer().x) || (FindPlayer().z < FindPlayer().y && FindPlayer().z < FindPlayer().x))
            dir = new Vector3(0, 0, FindPlayer().z);

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }



        //Move(FindPlayer());
        CheckDeath();
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

