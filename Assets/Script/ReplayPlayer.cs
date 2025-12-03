using UnityEngine;
using UnityEngine.InputSystem;

public class ReplayPlayer : Player
{
    private int index = 0;
    private int id = 0;
    private ReplayData dataFile;

    private void Awake()
    {
        id = GameObject.FindGameObjectsWithTag("ReplayPlayer").Length-1;
        LoadReplay();
    }

    protected override void FixedUpdate()
    {
        if (index >= dataFile.logs.Count) return;

        var log = dataFile.logs[index];
        OnMove(log.horizontal);
        OnJump(log.jumpHeld);
        index++;
        PlayerMove();
    }

    private void OnMove(float moveI)
    {
        moveInput = moveI;
    }

    private void OnJump(bool jumpB)
    {
        if (!jumpB)
        {
            if (p_rb.linearVelocity.y > 1)
            {
                p_rb.linearVelocity = new Vector3(0, 1f, p_rb.linearVelocity.z);
            }
            else
            {
                p_rb.linearVelocity = new Vector3(0, p_rb.linearVelocity.y, p_rb.linearVelocity.z);
            }
        }
        else if (onGround || onGrasp)
        {
            p_rb.linearVelocity = new Vector3(0, jumpPower, p_rb.linearVelocity.z);
            //_animator.SetBool("jump", true);
            onGround = false;
        }
    }

    private void LoadReplay()
    {
        dataFile = JsonController.instance.LoadFileId(id);
    }
}