using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    private Player1 p1;
    [SerializeField]
    private Player2 p2;

    public bool isHeadHit1 = false;
    public bool isBodyHit1 = false;
    public bool isLegHit1 = false;

    public bool isHeadHit2 = false;
    public bool isBodyHit2 = false;
    public bool isLegHit2 = false;

    private float headDelay = 0.2f;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (isHeadHit2 && (p1.state == State.hp_left || p1.state == State.hp_right))
        {
            Debug.Log("2p ���ϰ� �Ӹ� ����");
            isHeadHit2 = false;
            StopAllCoroutines();
            StartCoroutine(p2.hwDamaged(headDelay));
        }
        if(isHeadHit2 && (p1.state == State.hk_left || p1.state == State.hk_right))
        {
            Debug.Log("2p ���� �Ӹ� ����");
            isHeadHit2 = false;
            StopAllCoroutines();
            StartCoroutine(p2.hsDamaged(0.3f));
        }
        if (isBodyHit2 && (p1.state == State.bp_left || p1.state == State.bp_right || p1.state == State.bk_left || p1.state == State.bk_right))
        {
            Debug.Log("2p ���� ����");
            isBodyHit2 = false;
            StopAllCoroutines();
            StartCoroutine(p2.bDamaged(0.3f));
        }
        if (isLegHit2 && (p1.state == State.lk_left || p1.state == State.lk_right))
        {
            Debug.Log("2p �ٸ� ����");
            isLegHit2 = false;
            StopAllCoroutines();
            StartCoroutine(p2.lDamaged(0.3f));
        }


        if (isHeadHit1 && (p2.state == State.hp_left || p2.state == State.hp_right))
        {
            Debug.Log("1p ���ϰ� �Ӹ� ����");
            isHeadHit1 = false;
            StopAllCoroutines();
            StartCoroutine(p1.hwDamaged(headDelay));
        }
        if(isHeadHit1 && (p2.state == State.hk_left || p2.state == State.hk_right))
        {
            Debug.Log("1p ���� �Ӹ� ����");
            isHeadHit1 = false;
            StopAllCoroutines();
            StartCoroutine(p1.hsDamaged(0.3f));
        }
        if (isBodyHit1 && (p2.state == State.bp_left || p2.state == State.bp_right || p2.state == State.bk_left || p2.state == State.bk_right))
        {
            Debug.Log("1p ���� ����");
            isBodyHit1 = false;
            StopAllCoroutines();
            StartCoroutine(p1.bDamaged(0.3f));
        }
        if (isLegHit1 && (p2.state == State.lk_left || p2.state == State.lk_right))
        {
            Debug.Log("1p �ٸ� ����");
            isLegHit1 = false;
            StopAllCoroutines();
            StartCoroutine(p1.lDamaged(0.3f));
        }
    }
}
