using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class ScriptPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Boundary boundary;
    public float maxMoveSpeed;
    private Rigidbody rb;

    // Distinguish between player 1 and player 2
    public bool isPlayerOne = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check which player's controls to use
        float moveHorizontal = isPlayerOne ? Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal2");
        // float moveHorizontal = Input.GetAxis("Horizontal"); // if Single Player

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        rb.velocity = movement * moveSpeed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            0.0f
        );
    }

    public void IncreasePlayerSpeed(float increment)
    {
        moveSpeed = Mathf.Min(moveSpeed + increment, maxMoveSpeed);
    }
}
