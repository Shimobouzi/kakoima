using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float jumpPower = 11f;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    protected Animator _animator;

    protected float moveInput;
    public float getMoveInput { get { return moveInput; } }
    private bool jumpInput = false;
    protected Rigidbody p_rb;
    protected bool onGround = false;
    protected bool onGrasp = false;

    private ReplayData data = new ReplayData();
    private void Start()
    {
        p_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        data.logs.Add(new InputLog
        {
            horizontal = moveInput,
            jumpHeld = jumpInput
        });
        PlayerMove();
    }
    protected void PlayerMove()
    {
        p_rb.linearVelocity = new Vector3(0, p_rb.linearVelocity.y, moveInput * moveSpeed);
        if (p_rb.linearVelocity.z != 0)
        {
            _animator.SetBool("runBool", true);
        }
        else
        {
            _animator.SetBool("runBool", false);
        }
    }
    
    public virtual void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
    }

    public virtual void OnJump(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            jumpInput = false;
            if (p_rb.linearVelocity.y > 1)
            {
                p_rb.linearVelocity = new Vector3(0, 1f, p_rb.linearVelocity.z);
            }
            else
            {
                p_rb.linearVelocity = new Vector3(0, p_rb.linearVelocity.y, p_rb.linearVelocity.z);
            }
        }
        else if (onGround)
        {
            jumpInput = true;
            p_rb.linearVelocity = new Vector3(0, jumpPower ,p_rb.linearVelocity.z);
            _animator.SetBool("jumpBool", true);
        }else if (onGrasp)
        {
            jumpInput = true;
            p_rb.linearVelocity = new Vector3(0, jumpPower, p_rb.linearVelocity.z);
            _animator.SetBool("graspBool", true);
            _animator.SetBool("graspBool", false);
        }
    }

    public void SaveReplay()
    {
        JsonController.instance.SaveFile(data);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            _animator.SetBool("jumpBool", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grasp")
        {
            onGrasp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grasp")
        {
            onGrasp = false;
        }
    }
}
