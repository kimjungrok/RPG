using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
    private List<SaveInfo> listSaveInfo;
    private const string SAVE_PATH = "/Save";
    private const string SAVE_EXTENTION = "sav";
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
    public Job getJobInfo(Job.JOB job)
    {
        return listJob[(int)job];
    }
    public Job getCurrentJobInfo() // 직업에 해당하는 정보를 반환
    {
        return listJob[(int)jobNewSelected];
    }
    public GameObject getObjPlayer()
    {
        return objPlayer;
    }
    public void StartNewGame(int indexStage = 0) // 새 게임 시작
    {
        if(objPlayer != null)
        {
            Destroy(objPlayer);
            objPlayer = null;
        }
        CreateNewPlayer();
        objBarUI = Instantiate(prefabBarUI);
        objBarUI.SetActive(false);
        DontDestroyOnLoad(objBarUI);
        MoveStage(indexStage, transStartPosInNewGame);
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

        float startTime = Time.realtimeSinceStartup;    // 시작시간
        float endTime = startTime + fadeTime;           // 끝 시간
       
        while (endTime > Time.realtimeSinceStartup) 
        {
            img.color = Color.Lerp(colorSource, colorDestination, (Time.realtimeSinceStartup - startTime) / fadeTime);
            yield return null;
        }
    }
    public SaveInfo getSaveInfo() // 현재 플레이어의 정보를  저장정보로 얻기
    {
        return null;
    }
    public List<SaveInfo> getAllSaveInfo() // 플레이어 정보 리스트 불러오기
    {
        listSaveInfo = new List<SaveInfo>();
        DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath + "/Save");
        FileInfo[] fileInfos = d.GetFiles();

        foreach(FileInfo file in fileInfos)
        {
            if (file.Extension.Equals(SAVE_EXTENTION))
            {
                SaveInfo info = new SaveInfo();
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = file.Open(FileMode.Open);
                SaveInfo newInfo = (SaveInfo)bf.Deserialize(fs);
                fs.Close();
                listSaveInfo.Add(info);
            }
        }  
        return listSaveInfo;
    }

    public void RemoveSaveInfo(SaveInfo info) // 저장 정보 제거
    {
        int index = listSaveInfo.IndexOf(info);
        if (index != -1)
        {
            listSaveInfo.RemoveAt(index);
            File.Delete(info.saveName);
        }       
    }

    public void SaveGame(SaveInfo info) // 저장 정보 저장
    {      
        BinaryFormatter bf = new BinaryFormatter();        
        FileStream file = File.Create(Application.persistentDataPath + "/Save/"+ info.saveName +".sav");
        bf.Serialize(file, info);
        file.Close();
    }

    public bool LoadGame(SaveInfo info) // 불러오기,  게임 다시 시작
    {        
        return false;
    }
}