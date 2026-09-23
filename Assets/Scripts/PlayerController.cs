using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector3 moveDirection;
    public SpriteRenderer sr;
    public Animator animator;

    public InputActionReference move;
    public InputActionReference interact;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        moveDirection = move.action.ReadValue<Vector3>();
        
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.z);
        //The reason why I don't use this line of code
        //animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        //Is because it will include the Y component and as of now
        //Y is not part of the movement.
        float speed = moveDirection.x * moveDirection.x +
              moveDirection.z * moveDirection.z;
        animator.SetFloat("Speed", speed);


        moveDirection = move.action.ReadValue<Vector3>();
        if (moveDirection.x > 0 && moveDirection.x != 0)
        {
            sr.flipX = true;
        }
        else if (moveDirection.x < 0 && moveDirection.x != 0)
        {
            sr.flipX = false;
        }
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

    }
}
