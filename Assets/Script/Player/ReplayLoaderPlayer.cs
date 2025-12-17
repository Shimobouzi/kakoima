using UnityEngine;

public class ReplayLoaderPlayer : Player
{
    [SerializeField]
    private string replayData;

    private int index = 0;
    private int id = 0;
    private ReplayData dataFile;
    private bool jumpFirst = false;

    private void Awake()
    {
        id = GameObject.FindGameObjectsWithTag("ReplayPlayer").Length - 1;
        LoadReplay();
    }

    protected override void FixedUpdate()
    {
        if (index >= dataFile.logs.Count) { OnMove(0); PlayerMove(); return; }

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
            jumpFirst = false;
            if (p_rb.linearVelocity.y > 1)
            {
                p_rb.linearVelocity = new Vector3(0, 1f, p_rb.linearVelocity.z);
            }
            else
            {
                p_rb.linearVelocity = new Vector3(0, p_rb.linearVelocity.y, p_rb.linearVelocity.z);
            }
        }
        else if (!jumpFirst)
        {
            jumpFirst = true;
            if (onGround)
            {
                p_rb.linearVelocity = new Vector3(0, jumpPower, p_rb.linearVelocity.z);
                _animator.SetBool("jumpBool", true);
            }
            else if (onGrasp)
            {
                p_rb.linearVelocity = new Vector3(0, jumpPower, p_rb.linearVelocity.z);
                _animator.SetBool("graspBool", true);
                _animator.SetBool("graspBool", false);
            }
        }

    }

    private void LoadReplay()
    {
        dataFile = JsonUtility.FromJson<ReplayData>(replayData);
    }
}
