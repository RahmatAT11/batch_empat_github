using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script yang mengatur seluruh kendali character yang digunakan player
public class CharacterMoveController : MonoBehaviour
{
    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;

    private Rigidbody2D rig;

    [Header("Jump")]
    public float jumpAccel;

    private bool isJumping;
    private bool isOnGround;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // membaca input
        if (Input.GetMouseButtonDown(0))
        {
            if (isOnGround)
            {
                isJumping = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocityVector = rig.velocity;
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

        rig.velocity = velocityVector;
    }
}
