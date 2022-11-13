using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    private Player1 p1;
    [SerializeField]
    private Player2 p2;

    [SerializeField]
    private Slider p1Hpbar;
    [SerializeField]
    private Slider p2Hpbar;

    public bool isHeadWeakHit1 = false;
    public bool isHeadStrongHit1 = false;
    public bool isBodyHit1 = false;
    public bool isLegHit1 = false;

    public bool isHeadWeakHit2 = false;
    public bool isHeadStrongHit2 = false;
    public bool isBodyHit2 = false;
    public bool isLegHit2 = false;

    private float headWHitDelay = 0.3f;
    private float headSHitDelay = 0.3f;
    private float bodyHitDelay = 0.3f;
    private float legHitDelay = 0.3f;

    private bool isDieP1 = false;
    private bool isDieP2 = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (isHeadWeakHit2)
        {
            //Debug.Log("2p 약하게 머리 맞음");
            isHeadWeakHit2 = false;
            //StopAllCoroutines();
            StartCoroutine(p2.hwDamaged(headWHitDelay));
        }
        if (isHeadStrongHit2)
        {
            //Debug.Log("2p 세게 머리 맞음");
            isHeadStrongHit2 = false;
            //StopAllCoroutines();
            StartCoroutine(p2.hsDamaged(headSHitDelay));
        }
        if (isBodyHit2)
        {
            //Debug.Log("2p 몸통 맞음");
            isBodyHit2 = false;
            //StopAllCoroutines();
            StartCoroutine(p2.bDamaged(bodyHitDelay));
        }
        if (isLegHit2)
        {
            //Debug.Log("2p 다리 맞음");
            isLegHit2 = false;
            //StopAllCoroutines();
            StartCoroutine(p2.lDamaged(legHitDelay));
        }


        if (isHeadWeakHit1)
        {
            //Debug.Log("1p 약하게 머리 맞음");
            isHeadWeakHit1 = false;
            //StopAllCoroutines();
            StartCoroutine(p1.hwDamaged(headWHitDelay));
        }
        if (isHeadStrongHit1)
        {
            //Debug.Log("1p 세게 머리 맞음");
            isHeadStrongHit1 = false;
            //StopAllCoroutines();
            StartCoroutine(p1.hsDamaged(headSHitDelay));
        }
        if (isBodyHit1)
        {
            //Debug.Log("1p 몸통 맞음");
            isBodyHit1 = false;
            //StopAllCoroutines();
            StartCoroutine(p1.bDamaged(bodyHitDelay));
        }
        if (isLegHit1)
        {
            //Debug.Log("1p 다리 맞음");
            isLegHit1 = false;
            //StopAllCoroutines();
            StartCoroutine(p1.lDamaged(legHitDelay));
        }

        p1Hpbar.value = p1.curHP;
        p2Hpbar.value = p2.curHP;
    }

    public void DieP1()
    {
        isDieP1 = true;
        Debug.Log("1p 죽음");
    }

    public void DieP2()
    {
        isDieP2 = true;
        Debug.Log("2p 죽음");
    }
}
