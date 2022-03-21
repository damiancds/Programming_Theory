using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health;
    public float speed;
    public Rigidbody rb;

    public void Initialize()
    {
        health = 100;
        speed = 1;
        rb = GetComponent<Rigidbody>();
    }
    public Vector3 FindPlayer()
    {
        Player player = FindObjectOfType<Player>();
        return (player.transform.position - transform.position).normalized;
    }
    public virtual void Move(Vector3 target)
    {
        rb.AddForce(target*speed, ForceMode.Force);
    }
    public void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
