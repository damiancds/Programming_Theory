using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public Rigidbody rb;

    private void Start()
    {
        health = 100;
        speed = 1;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckDeath();
        Move(FindPlayer());
    }
    public Vector3 FindPlayer()
    {
        Player player = FindObjectOfType<Player>();
        return (player.transform.position - transform.position).normalized;
    }
    public void Move(Vector3 target)
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
