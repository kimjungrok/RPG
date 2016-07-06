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
    public List<Job> listJob;

    private Stage curStage; // 현재 Stage
    private Job.JOB jobNewSelected = Job.JOB.WARRIOR;// 선택한 직업
    private GameObject objPlayer;   // 생성한 플레이어 오브젝트
    private GameObject objBarUI;    // 생성한 Bar UI;
    private float fadeTime = 0.5f;

    private static GameManager m_instance;
    public static GameManager instance
    {
        //싱글톤, 오직 한개의 인스턴스(생성)만 가지도록 한다.
        get
        {
            if (m_instance == null)
            {
                // 이미 존재하는 GameManager를 찾는다.
                m_instance = FindObjectOfType<GameManager>();
                if(m_instance == null)
                {
                    // 없으면 새 오브젝트에 추가한다.
                    GameObject newObject = new GameObject("Logic");         
                    GameObject objLogic = Instantiate(newObject);
                    m_instance = objLogic.AddComponent<GameManager>();
                }
            }
            return m_instance;
        }
    }

    void Awake()
    {      
        DontDestroyOnLoad(gameObject); // 삭제하지 않음
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
        GameObject prefab = getCurrentJobInfo().jopPrefab;
        objPlayer = Instantiate(prefab);
        DontDestroyOnLoad(objPlayer);
    }
    public void MoveStage(int indexStage, Transform transStartPos)
    {
        curStage = listStage[indexStage];
        StartCoroutine(LoadStage(curStage.sceneName, transStartPos));
    }
    public Job getCurrentJobInfo() // 직업에 해당하는 정보를 반환
    {
        return listJob[(int)jobNewSelected];
    }
    public GameObject getObjPlayer()
    {
        return objPlayer;
    }
    public void StartNewGame() // 새 게임 시작
    {
        CreateNewPlayer();
        objBarUI = Instantiate(prefabBarUI);
        objBarUI.SetActive(false);
        DontDestroyOnLoad(objBarUI);
        MoveStage(0, transStartPosInNewGame);
    }

    public void ExitGame() // 게임 종료
    {
        Application.Quit(); 
    }

    IEnumerator LoadStage(string sceneName, Transform transPlayerPos)
    {
        Time.timeScale = 0f;
        objBarUI.SetActive(false);
        GameObject objFadeCanvas = Instantiate(preSceneFade);
        DontDestroyOnLoad(objFadeCanvas);
        Image img = objFadeCanvas.GetComponentInChildren<Image>();

        yield return FadeEffect(FADE.OUT, img);


        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        while (!ao.isDone)
        { 
            yield return null;
        }
        objPlayer.transform.position = transPlayerPos.position;
        yield return FadeEffect(FADE.IN, img);

        objBarUI.SetActive(true); 
               
        Destroy(objFadeCanvas);
        Time.timeScale = 1f;
    }
    IEnumerator FadeEffect(FADE mode, Image img)
    {
        Color colorSource;      // 초기 색상
        Color colorDestination; // 끝 색상

        if(mode == FADE.IN) // 점점 맑아지는 효과
        {
            colorSource = Color.black;
            colorDestination = Color.clear; 
        }
        else // 점점 어두워지는 효과
        {
            colorSource = Color.clear;
            colorDestination = Color.black;            
        }        
        float startTime = Time.realtimeSinceStartup; // 시작시간
        float endTime = startTime + fadeTime;       // 끝 시간
       
        while (endTime > Time.realtimeSinceStartup) 
        {
            img.color = Color.Lerp(colorSource, colorDestination, (Time.realtimeSinceStartup - startTime) / fadeTime);
            yield return null;
        }        
        
    }
}
