using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// 게임의 스테이지를 관리하고, 초기화하고, 게임 성공 or 실패 여부를 결정하는 class
public class GameManager : MonoBehaviour {

    public enum FADE { IN, OUT }
    public const string strLoadingSceneName = "SceneStageLoading";
    public GameObject prefabBarUI;
    public GameObject preSceneFade;
    public Transform transStartPosInNewGame;
    public List<Stage> listStage;
    public List<Job> listJob; // 직업별 정보

    private Stage curStage; // 현재 Stage
    private Job.JOB jobNewSelected = Job.JOB.WARRIOR;// 선택한 직업
    private GameObject objPlayer;   // 생성한 플레이어 오브젝트
    private GameObject objBarUI;    // 생성한 Bar UI;
    private float fadeTime = 2f;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        curStage = listStage[0];
    }

    public Stage getCurrentStageInfo()
    {
        return curStage;
    }
    public void SelectJob(Job.JOB job)
    {
        jobNewSelected = job;
    }
    public void CreateNewPlayer()
    {
        GameObject prefab = getJobInfo(jobNewSelected).jopPrefab;
        objPlayer = Instantiate(prefab);
        DontDestroyOnLoad(objPlayer);
    }
    public void MoveStage(int indexStage, Transform transStartPos)
    {
        curStage = listStage[indexStage];
        StartCoroutine(LoadStage(curStage.sceneName, transStartPos));
    }
    public Job getJobInfo(Job.JOB job) // 직업에 해당하는 정보를 반환
    {
        return listJob[(int)job];
    }
    public GameObject getObjPlayer()
    {
        return objPlayer;
    }
    public void StartNewGame()
    {
        CreateNewPlayer();
        objBarUI = Instantiate(prefabBarUI);
        DontDestroyOnLoad(objBarUI);
        MoveStage(0, transStartPosInNewGame);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadStage(string sceneName, Transform transPlayerPos)
    {
        yield return FadeEffect(FADE.OUT);
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        while (!ao.isDone)
        {
            yield return null;
        }
        objPlayer.transform.position = transPlayerPos.position;
        yield return FadeEffect(FADE.IN);
    }
    IEnumerator FadeEffect(FADE mode)
    {
        Color colorSource;
        Color colorDestination;
        Time.timeScale = 0f;
        if(mode == FADE.IN) // 점점 맑아지는 효과
        {
            colorSource = Color.black;
            colorDestination = Color.clear; 
        }
        else
        {
            colorSource = Color.clear;
            colorDestination = Color.black;            
        }
        GameObject obj = Instantiate(preSceneFade);
        DontDestroyOnLoad(obj);
        Image img = obj.GetComponentInChildren<Image>();

        float startTime = Time.realtimeSinceStartup;
        float endTime = startTime + 1f;
       
        while (endTime > Time.realtimeSinceStartup)
        {
            img.color = Color.Lerp(colorSource, colorDestination, (Time.realtimeSinceStartup - startTime) / fadeTime);
            yield return null;
        }
        Destroy(obj);
        Time.timeScale = 1f;
    }
}
