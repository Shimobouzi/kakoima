using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAngle : MonoBehaviour
{
    private float moveInput = 0;
    private float rotateSpeed = 8f;  //player‚ÌƒAƒ“ƒOƒ‹speed

    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        moveInput = this.transform.parent.GetComponent<Player>().getMoveInput;
        Vector3 moveValue = new Vector3(0f, 0f, moveInput);
        transform.forward = Vector3.Slerp(transform.forward, moveValue,Time.deltaTime * rotateSpeed); //angle•ÏX
    }
}
