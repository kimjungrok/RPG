using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject player; // 플레이어오브젝트
	public GameObject ThisMonster; //이 몬스터

	//public Ray ray;

	float patternRegTime = 5f; // 다음 행동까지 대기시간
	float NextPattern = 0f; //다음패턴까지 대기시간

	float random; //움직이는 랜덤방향

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

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		aniCon = GetComponent<Animator> ();
		Movepoint = LivingZone.transform;
		StartCoroutine (RunAway(10));

		//ray = new Ray (ThisMonster.transform.position, ThisMonster.transform.forward);

	}

	IEnumerator RunAway(float time){

		yield return new WaitForSeconds (time);
		Movepoint.position = new Vector3 (Random.Range (-30, 30), 0, Random.Range (-30, 30));
		StartCoroutine (RunAway (10));
	}

	IEnumerator ItemDrop(){
		yield return new WaitForSeconds (1);
	}


	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.transform.position, ThisMonster.transform.position) <= 20.0f) {
			isChase = true;
		} else {
			isChase = false;

			agent.SetDestination (Movepoint.position);
			agent.Resume ();
		}

		if (isChase) {
			//agent.Stop();

			agent.SetDestination (player.transform.position);
			agent.Resume ();

			if (Vector3.Distance (player.transform.position, this.transform.position) <= 10.0f) {

				AttackTpyeONEorTwo = Random.Range (1, 2);

				if (AttackTpyeONEorTwo == 1) {
					aniCon.SetBool ("IsStabAttack", true);
					NextPattern = Time.time + AttackColltime; // 공격후일정시간뒤에도 그공격범위내에 플레이어가 존재시
					if (Vector3.Distance (player.transform.position, this.transform.position) <= 5.0f &&
						Mathf.Abs (Vector3.Angle (player.transform.forward, ThisMonster.transform.position - player.transform.position)) <= 7.5f) {
						//playerHP -= AttackPower; // player 가 몬스터의 공격력 만큼 대미지를 입음
					} else {
						//player가 대미지 피해 없음
					}

				} else if (AttackTpyeONEorTwo == 2) {
					aniCon.SetBool ("IsWieldAttack", true);
					NextPattern = Time.time + AttackColltime;
					if (Vector3.Distance (player.transform.position, this.transform.position) <= 5.0f &&
						Mathf.Abs (Vector3.Angle (player.transform.forward, ThisMonster.transform.position - player.transform.position)) <= 35.0f) {
						//playerHP -= AttackPower; // player 가 몬스터의 공격력 만큼 대미지를 입음
					} else {
						//player가 대미지 피해 없음
					}
				} else {
					aniCon.SetBool ("IsStabAttack", false);
					aniCon.SetBool ("IsWieldAttack", false);
				}
			}



		} else {
			
			isChase = false;

			agent.SetDestination (Movepoint.position);
			agent.Resume ();

		}

		if (MonsterCurrentHP <= 0){
			//new WaitForSeconds (5f);

			agent.Stop();

			Instantiate (DropItem, ThisMonster.transform.position, ThisMonster.transform.rotation); // 2페이즈보스생성 실제로는 dropitem에 넣

			enabled = false; // 아이템을 한번만 생성하게
			NextPattern = Time.time + patternRegTime;
			Destroy(gameObject, 10f);


			//Instantiate (ThisMonster, LivingZone.transform.position, LivingZone.transform.rotation); // 리스폰
			//enabled = false;
		}
			
	}
}
