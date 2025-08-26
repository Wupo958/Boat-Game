using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Geschwindigkeit & Schub")]
    public float maxForwardSpeed = 10f;
    public float acceleration = 20f;        
    public float reverseFactor = 0.25f;             

    [Header("Rotation")]
    public float turnSpeedDeg = 60f;   
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float steer = Input.GetAxisRaw(horizontalAxis);
        float thrustInput = Input.GetAxisRaw(verticalAxis);

        float yawStep = turnSpeedDeg * steer;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, yawStep, 0f));

        Vector3 velocity = rb.linearVelocity; velocity.y = 0f;

        float velocityForward = Vector3.Dot(velocity, transform.forward);
        float maxReverseSpeed = maxForwardSpeed * reverseFactor;

        if (thrustInput > 0f)
        {
            if (velocityForward < maxForwardSpeed)
            {
                float scale = Mathf.Clamp01(thrustInput);
                rb.AddForce(transform.forward * (acceleration * scale), ForceMode.Acceleration);
            }
        }
        else if (thrustInput < 0f)
        {
            if (velocityForward > -maxReverseSpeed)
            {
                float scale = Mathf.Clamp01(-thrustInput);
                rb.AddForce(-transform.forward * (acceleration * reverseFactor * scale), ForceMode.Acceleration);
            }
        }
    }
}