using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// 게임의 스테이지를 관리하고, 초기화하고, 게임 성공 or 실패 여부를 결정하는 class
public class GameManager : MonoBehaviour {

    public List<Stage> listStage;
    public List<Job> listJob; // 직업별 정보

    private Stage curStage; // 현재 Stage
    private Job.JOB jobNewSelected = Job.JOB.WARRIOR;// 선택한 직업
    private GameObject objPlayer; // 플레이어 오브젝트

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
    public void MoveStage(int index)
    {
        curStage = listStage[index];
        SceneManager.LoadScene(curStage.sceneName);
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
        MoveStage(0);
    }
}
