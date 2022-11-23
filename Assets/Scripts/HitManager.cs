using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitManager : MonoBehaviour
{
    private GameObject player1Obj;
    private GameObject player2Obj;

    private Player1 p1;
    private Player2 p2;

    [SerializeField]
    private Slider p1Hpbar;
    [SerializeField]
    private Slider p2Hpbar;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClips;

    private RoundManager roundManager;
    private CameraManager cameraManager;

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

    public bool isDieP1 = false;
    public bool isDieP2 = false;

    private void Start()
    {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
        cameraManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
        player1Obj = GameObject.FindGameObjectWithTag("p1");
        player2Obj = GameObject.FindGameObjectWithTag("p2");
        p1 = player1Obj.GetComponent<Player1>();
        p2 = player2Obj.GetComponent<Player2>();
    }

    private void Update()
    {
        //카메라 흔들리는 효과
        if (isHeadWeakHit1 || isHeadStrongHit1 || isBodyHit1 || isLegHit1 || isHeadWeakHit2 || isHeadStrongHit2 || isBodyHit2 || isLegHit2)
            ShakeCamera.Instance.OnShakeCamera(0.1f, 1f);

        //카메라 슬로우 및 줌인 효과
        if ((p1.curHP <= 10 && p2.curHP <= 10) && (Vector3.Distance(player2Obj.transform.position, player1Obj.transform.position) <= 3) && (p1.isAtk && p2.isAtk))
        {
            Time.timeScale = 0.1f;
            cameraManager.minDistance = 4.0f;
        }
        else if(!roundManager.isPause)
        {
            Time.timeScale = 1.0f;
            cameraManager.minDistance = 5.0f;
        }
            

        if (isHeadWeakHit2)
        {
            //Debug.Log("2p 약하게 머리 맞음");
            isHeadWeakHit2 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[0];
            audioSource.Play();
            StartCoroutine(p2.hwDamaged(headWHitDelay));
        }
        if (isHeadStrongHit2)
        {
            //Debug.Log("2p 세게 머리 맞음");
            isHeadStrongHit2 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[1];
            audioSource.Play();
            StartCoroutine(p2.hsDamaged(headSHitDelay));
        }
        if (isBodyHit2)
        {
            //Debug.Log("2p 몸통 맞음");
            isBodyHit2 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[2];
            audioSource.Play();
            StartCoroutine(p2.bDamaged(bodyHitDelay));
        }
        if (isLegHit2)
        {
            //Debug.Log("2p 다리 맞음");
            isLegHit2 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[3];
            audioSource.Play();
            StartCoroutine(p2.lDamaged(legHitDelay));
        }


        if (isHeadWeakHit1)
        {
            //Debug.Log("1p 약하게 머리 맞음");
            isHeadWeakHit1 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[0];
            audioSource.Play();
            StartCoroutine(p1.hwDamaged(headWHitDelay));
        }
        if (isHeadStrongHit1)
        {
            //Debug.Log("1p 세게 머리 맞음");
            isHeadStrongHit1 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[1];
            audioSource.Play();
            StartCoroutine(p1.hsDamaged(headSHitDelay));
        }
        if (isBodyHit1)
        {
            //Debug.Log("1p 몸통 맞음");
            isBodyHit1 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[2];
            audioSource.Play();
            StartCoroutine(p1.bDamaged(bodyHitDelay));
        }
        if (isLegHit1)
        {
            //Debug.Log("1p 다리 맞음");
            isLegHit1 = false;
            //StopAllCoroutines();
            audioSource.clip = audioClips[3];
            audioSource.Play();
            StartCoroutine(p1.lDamaged(legHitDelay));
        }

        p1Hpbar.value = p1.curHP;
        p2Hpbar.value = p2.curHP;
    }

    public void DieP1()
    {
        isDieP1 = true;
        Debug.Log("1p 죽음");
        roundManager.p2winCnt += 1;
        roundManager.RoundAdd();
    }

    public void DieP2()
    {
        isDieP2 = true;
        Debug.Log("2p 죽음");
        roundManager.p1winCnt += 1;
        roundManager.RoundAdd();
    }
}
