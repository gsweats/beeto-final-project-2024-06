using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float paddleSpeed = 15f;
    Rigidbody2D PlayerRB;
    public float maxX = 7f;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRB.velocity = new Vector2 (paddleSpeed, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRB.velocity = new Vector2(-paddleSpeed, 0f);
        }
        else
        {
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
    }
}
