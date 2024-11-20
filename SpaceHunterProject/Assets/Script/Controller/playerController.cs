using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour, IDamageable
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private GameObject player, cam;
    [SerializeField] float speed = 5f;
    public float MaxSpeed;
    Vector3 inputDir;
    float currentVelocity;
    float smoothTime = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundMask;
    bool jumpKeyPressed;
    float lastJumpTime = -1000;
    [SerializeField] float jumpPower = 5;
    [SerializeField] PhysicMaterial slipMaterial;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();
        if (!jumpKeyPressed && Input.GetAxis("Jump") > 0 ) { jumpKeyPressed = true; }

    }
    private void FixedUpdate()
    {
        float inputMagnitude = Mathf.Clamp01(inputDir.magnitude);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }
        animator.SetFloat("Input Magnetude", inputMagnitude);
        float speed = inputMagnitude * MaxSpeed;
        IsGrounded();
        Move(speed);
        rb.angularVelocity = Vector3.zero;
        UpdateFriction();
    }
    void Move(float speed)
    {
        Vector3 forwardDir = transform.forward * inputDir.z;
        forwardDir.Normalize();
        forwardDir *= speed;

        Vector3 strafeDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafeDir.Normalize();
        strafeDir *= speed;

        Vector3 moveDir = forwardDir + strafeDir;

        rb.MovePosition(transform.position + (moveDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;
        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);



        if (jumpKeyPressed && IsGrounded())
        {
            JumpPower();
        }
    }

    public void JumpPower()
    {
        jumpKeyPressed = false;
        if (Time.timeSinceLevelLoad - lastJumpTime < 1.5) return;
        lastJumpTime = Time.timeSinceLevelLoad;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
    }

    /// <summary>
    /// return true if player is on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.11f, groundMask);
    }

    public void UpdateFriction()
    {
        bool isGrounded = IsGrounded();
        slipMaterial.staticFriction = isGrounded ? 0.6f : 0f;
        slipMaterial.dynamicFriction = isGrounded ? 0.6f : 0f;
    }
    //===============================================================IDamageable=========================================
    public bool IsDamageable { get { return true; } }
    public void OnDmg(int damage)
    {
        if (damage < 0) { Debug.Log("jai recupéré des point de vie"); }
        else if (damage > 0) { Debug.Log("Jai perdu des point de vie"); }
    }
}
