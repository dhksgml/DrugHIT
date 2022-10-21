using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { Idle = 0, Walk, Run, Jump, Crouch, Punch, Kick, Defence}

public class playerController : MonoBehaviour
{
    public PlayerStates playerState;

    private bool isCrouch = false;
    public bool isAttack = false;

    private bool isLeftRun = false;
    private bool isRightRun = false;

    CapsuleCollider collider;

    public float speed = 5;
    public float backWalkSpeed = -3f;
    public float frontWalkSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(PlayerStates.Idle);
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadKey();
    }

    public void ReadKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("점프");
            ChangeState(PlayerStates.Jump);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("숙이기");
            ChangeState(PlayerStates.Crouch);

            isCrouch = true;

            if (isCrouch && Input.GetKeyDown(KeyCode.A))
            {   
                Debug.Log("하단 주먹");
            }
            else if(isCrouch && Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("하단 킥");
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("방어");
            ChangeState(PlayerStates.Defence);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("주먹지르기");
            ChangeState(PlayerStates.Punch);
        }
        else if (Input.GetKeyDown(KeyCode.D) && playerState != PlayerStates.Crouch)
        {
            Debug.Log("발차기");
            ChangeState(PlayerStates.Kick);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !isAttack)
        {
            Debug.Log("왼쪽 이동");
            speed = backWalkSpeed;
            ChangeState(PlayerStates.Walk);

        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !isAttack)
        {
            Debug.Log("오른쪽 이동");
            speed = frontWalkSpeed;
            ChangeState(PlayerStates.Walk);
        }
        else
        {
            ChangeState(PlayerStates.Idle);
        }

        Debug.Log(playerState);
    }

    private void ChangeState(PlayerStates newState)
    {
        StopCoroutine(playerState.ToString());
        playerState = newState;
        StartCoroutine(playerState.ToString());
    }

    private IEnumerator Idle()
    {
        while(true)
        {
            Debug.Log("Idle..");
            yield return null;
        }
        Debug.Log("end Idle");
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            Debug.Log("Walk..");
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("end Walk");
    }

    private IEnumerator Run()
    {
        while (true)
        {
            Debug.Log("Run..");
            yield return null;
        }
        Debug.Log("end Run");
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            Debug.Log("Jump..");
            yield return null;
        }
        Debug.Log("end Jump");
    }

    private IEnumerator Crouch()
    {
        while (true)
        {
            Debug.Log("Crouch..");
            yield return null;
        }
        Debug.Log("end Crouch");
    }


    private IEnumerator Punch()
    {
        while (true)
        {
            Debug.Log("Punch..");
            yield return null;
        }
        Debug.Log("end Punch");
    }

    private IEnumerator Kick()
    {
        while (true)
        {
            Debug.Log("Kick..");
            yield return null;
        }
        Debug.Log("end Kick");
    }

    private IEnumerator Defence()
    {
        while (true)
        {
            Debug.Log("Defence..");
            yield return null;
        }
        Debug.Log("end Defence");
    }

}
