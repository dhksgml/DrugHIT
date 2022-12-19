using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static int roundCnt = 1;
    


    [SerializeField]
    private GameObject pauseBackgroundUI;
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject pauseBtn1;
    [SerializeField]
    private GameObject pauseBtn2;
    [SerializeField]
    private GameObject roundTxt;

    [SerializeField]
    private GameObject[] p1winCntUI;
    [SerializeField]
    private GameObject[] p2winCntUI;

    public bool isPause = false;

    public int p1winCnt = 0;
    public int p2winCnt = 0;

    private SceneScript sceneScript;
    private bool flag = false;

    //private HitManager hitManager;
    private void Start()
    {
        //hitManager = GameObject.Find("hitManager").GetComponent<HitManager>();
        roundCnt = 1;

        foreach (GameObject i in p1winCntUI)
        {
            i.SetActive(false);
        }

        foreach (GameObject i in p2winCntUI)
        {
            i.SetActive(false);
        }

        sceneScript = this.gameObject.GetComponent<SceneScript>();
    }
    public void Pause()
    {
        //Debug.Log("멈춤!");
        isPause = true;
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        //Debug.Log("경기 재개");
        isPause = false;
        Time.timeScale = 1.0f;
    }

    public void RoundAdd()
    {
        roundCnt += 1;
    }

    private void Update()
    {
        pauseBackgroundUI.SetActive(isPause);
        pauseUI.SetActive(isPause);
        pauseBtn1.SetActive(isPause);
        pauseBtn2.SetActive(isPause);

        roundTxt.GetComponent<Text>().text = "Round " + roundCnt;

        if(p1winCnt == 1)
        {
            p1winCntUI[0].SetActive(true);
        }

        if(p1winCnt == 2)
        {
            p1winCntUI[1].SetActive(true);
        }

        if (p2winCnt == 1)
        {
            p2winCntUI[0].SetActive(true);
        }

        if (p2winCnt == 2)
        {
            p2winCntUI[1].SetActive(true);
        }

        if (p1winCnt == 2 || p2winCnt == 2)
        {
            //승패 정해지고 일정 시간 후 시작화면으로 넘어감.
            if(flag == false)
            {
                StartCoroutine( ChangeFlag() );
            }
        }
    }

    IEnumerator ChangeFlag()
    {
        flag = true;
        yield return new WaitForSeconds(3.0f);
        sceneScript.loadScene(0);
    }
}
