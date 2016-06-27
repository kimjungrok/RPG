using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class JobInfo : MonoBehaviour {
    // 모든 직업 정보 정의 클래스 
    
    public List<Job> listJob;       // 직업별 정보

    public Job getJobInfo(Job.JOB job) // 직업에 해당하는 정보를 반환
    {
        return listJob[(int)job];
    }

}
