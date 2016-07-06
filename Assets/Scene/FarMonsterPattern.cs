using UnityEngine;
using System.Collections;

public class FarMonsterPattern : MonoBehaviour {

	NavMeshAgent agent;
	GameObject player; // 플레이어오브젝트
	public GameObject ThisMonster; //이 몬스터
	//public BoxCollider col;

	public Vector3 Dir;

	public float LookDistan; //시야

	//public Ray ray;

	public float random; //움직이는 랜덤방향

	Animator aniCon;

	int AttackTpyeONEorTwo; //1번공격인지 2번공격인지


	public GameObject LivingZone; // 해당몬스터의 행동영역
	Transform Movepoint;// 해당 몬스터의 이동지점

	public float MonsterMaxHP; //몬스터의 HP
	public float MonsterCurrentHP;
	public GameObject DropItem; //몬스터가 드랍하는 아이템
	public int KillExp; //죽였을시 얻는 경험치
	public float AttackPower; //몬스터의 공격력

	public float AttackColltime = 0.3f; //몬스터가 공격후 플레이어가 대미지 판정을 처리하기까지의 시간
	//public int MoveSpeed; // naviMeshAgent에서 관리하므로 필요 없음
	public bool isChase = false;

	public float Respawntime;
	public GameObject RespawnMonster;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponent<NavMeshAgent> ();
		aniCon = GetComponent<Animator> ();
		Movepoint = LivingZone.transform;
		StartCoroutine (RunAway(10));

		enabled = true;

		//col.enabled = false;

		//ray = new Ray (ThisMonster.transform.position, ThisMonster.transform.forward);

	}
	IEnumerator Respawn(float Respawntime){
		yield return new WaitForSeconds (Respawntime);
		Instantiate (RespawnMonster, LivingZone.transform.position, LivingZone.transform.rotation);
	}

	IEnumerator RunAway(float time){

		yield return new WaitForSeconds (time);
		Movepoint.position = new Vector3 (LivingZone.transform.position.x + Random.Range (-random, random), LivingZone.transform.position.y, ThisMonster.transform.position.z + Random.Range (-random, random));
		StartCoroutine (RunAway (10));
	}

	IEnumerator ItemDrop(){
		yield return new WaitForSeconds (1);

	}



	// Update is called once per frame
	void Update () {

		Dir = player.transform.position - this.gameObject.transform.position;

		if (Vector3.Distance (player.transform.position, ThisMonster.transform.position) <= LookDistan) {
			isChase = true;
		} else {
			isChase = false;

			agent.SetDestination (Movepoint.position);
			aniCon.SetBool ("IsRun", true);
			agent.Resume ();
			if (Vector3.Distance (Movepoint.position, ThisMonster.transform.position) <= 10) {
				aniCon.SetBool ("IsRun", false);
				aniCon.SetBool ("IsIdle", true);

				agent.Stop (); //idle 모션이다시나오게
				//col.enabled = false;
			}
		}

		if (isChase) {
			//agent.Stop();
			//aniCon.SetBool ("IsRun", true);
			agent.SetDestination (player.transform.position);
			agent.Resume ();

			if (Vector3.Distance (player.transform.position, this.transform.position) <= 15) {
				aniCon.SetBool ("IsRun", false);
				agent.Stop ();

				aniCon.SetBool ("IsFarAttack", true);
				//col.enabled = true;


				Vector3 vecLookPos = player.transform.position;
				vecLookPos.y = transform.position.y;
				transform.LookAt (vecLookPos);

				//Instantiate (Bullet, ThisMonster.transform.position, ThisMonster.transform.rotation); //원거리공격

				/*
				//NextPattern = Time.time + AttackColltime; // 공격후일정시간뒤에도 그공격범위내에 플레이어가 존재시
				if (Vector3.Distance (player.transform.position, this.transform.position) <= 5.0f &&
					Mathf.Abs (Vector3.Angle (player.transform.forward, ThisMonster.transform.position - player.transform.position)) <= 7.5f) {
					//playerHP -= AttackPower; // player 가 몬스터의 공격력 만큼 대미지를 입음
				} else {
					//player가 대미지 피해 없음
				}*/

			} else {
				aniCon.SetBool ("IsRun", true);
				aniCon.SetBool ("IsFarAttack", false);
				//col.enabled = false;
			}



		} else {

			isChase = false;
			//col.enabled =false;
			agent.SetDestination (Movepoint.position);
			//agent.SetDestination (this.transform.position.x + Random.Range(-random,random),this.transform.position.y, this.transform.position.z + Random.Range(-random,random));
			agent.Resume ();

		}

		if (MonsterCurrentHP <= 0){
			//new WaitForSeconds (5f);
			//col.enabled = false;
			agent.Stop();
			aniCon.SetBool ("IsIdle", false);
			aniCon.SetBool ("IsFarAttack", false);
			aniCon.SetBool ("IsRun", false);
			aniCon.SetBool ("IsDie", true);
			StartCoroutine(Respawn(Respawntime));
			Instantiate (DropItem, ThisMonster.transform.position, ThisMonster.transform.rotation); // 2페이즈보스생성 실제로는 dropitem에 넣

			enabled = false; // 아이템을 한번만 생성하게
			//NextPattern = Time.time + patternRegTime;
			Destroy(gameObject, 10f);


			//Instantiate (ThisMonster, LivingZone.transform.position, LivingZone.transform.rotation); // 리스폰
			//enabled = false;
		}

	}
}
