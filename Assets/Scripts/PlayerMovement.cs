using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private float groundDistance = .2f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    [SerializeField] private float CameraXoffset;
    [SerializeField] private float CameraYoffset;
    [SerializeField] private float CameraZoffset;
    [SerializeField] private float senstivity;

    [SerializeField] private Animator _animator;

    bool isGrounded;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * moveSpeed * Time.deltaTime);
        _animator.SetFloat("Speed", (move * moveSpeed * Time.deltaTime).magnitude);

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundLayer);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);

        }
        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;

        Debug.Log(velocity);
        characterController.Move(velocity * Time.deltaTime);


    }
}
