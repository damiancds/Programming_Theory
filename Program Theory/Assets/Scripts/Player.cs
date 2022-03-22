using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //ENCAPSULATION
    public int health { get; private set; }
    public float speed { get; set; }
    public float jumpForce { get; set; }
    
    [SerializeField] private Light flashlight;
    GameManager gm;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 5;
        speed = 1;
        jumpForce = 250;
        gm = FindObjectOfType<GameManager>();

    }
    void Update()
    {
        Move();
        Jumping();
        if (health <= 0) {gm.GameOver();}
    }
    private void Move()
    {
        float vIn = Input.GetAxis("Vertical");
        float hIn = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(hIn, 0, vIn);

        rb.AddForce(movement, ForceMode.Acceleration);
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!gm.isGameOver) health--;
        }
    }
}
