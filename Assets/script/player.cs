using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public GameManager gm;
    public float moveSpeed = 5f;
    public int startHealth = 3;
    public int Health = 3;

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position = newPosition;

        if(Health<=0){gm.Gamestate=false;}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Health--;
            Destroy(collision.gameObject);
        }
    }
}
