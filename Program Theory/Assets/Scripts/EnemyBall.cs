using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : EnemyBase //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();   
    }

    // Update is called once per frame
    void Update()
    {
        Move(FindPlayer());
        CheckDeath();
    }
    public override void Move(Vector3 target)
    {
        base.Move(target);
    }
}
