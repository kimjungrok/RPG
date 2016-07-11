using UnityEngine;
using System.Collections;

public class CharactorController : MonoBehaviour
{

    public float speed = 0f;                    //현재 이동속도
    public float runspeed = 7f;                 //달리는 이동속도
    public float jumplevel = 20f;               //점프레벨
    public float gravity = 50f;                 //중력제어
    public float turnspeed = 100f;              //player의 회전속도


    public int m_Hp = 100;                      //임시hp
    public int hpMax;                           //임시hpmax
    public int playerLevel = 20;                //임시레벨

    public Collider boxCol;                     //BoxCollider 
    public GameObject Smoke;                    //이동시 먼지흩날리는효과
    public GameObject Skill1;                   //스킬이펙트
    public GameObject Skill2;                   //스킬이펙트2
    public Transform transformWeapon;

    private CharacterController controller;     //캐릭터 컨트롤러
    private Vector3 lookDirection;              //input에 의해 정해진 현재방향
    private Vector3 jumPing;                    //jump를 위한 vector3할당

    //현재 animation상태 저장
    protected Animator anim;

    private AnimatorStateInfo currentBaseState;

    private float xx;
    private float zz;


    //layer.state를 hash로 변수정의
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int runState = Animator.StringToHash("Base Layer.Run");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int damageState = Animator.StringToHash("Base Layer.Damage");
    static int deadState = Animator.StringToHash("Base Layer.Dead");
    static int skill1State = Animator.StringToHash("Base Layer.Skill1");
    static int skill2State = Animator.StringToHash("Base Layer.Skill2");
    static int skill3State = Animator.StringToHash("Base Layer.Skill3");

    static int JumpAttack = Animator.StringToHash("Base Layer.JumpAttack");
    static int combo1State = Animator.StringToHash("Base Layer.Combo1");
    static int combo2State = Animator.StringToHash("Base Layer.Combo2");
    static int combo3State = Animator.StringToHash("Base Layer.Combo3");
    
    void Start()
    {
        boxCol.enabled = false;                                 // 충돌체 상시off
        controller = GetComponent<CharacterController>();       // controller 정의
        anim = GetComponent<Animator>();                        // meacanim   정의
    }
    
    void Update()
    {
        StateCheck();
        keyBoardInput();
        LookUpdate();

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    void keyBoardInput()
    {
        xx = Input.GetAxis("Vertical"); //전진&후진
        zz = Input.GetAxis("Horizontal");   //좌우

        //Z키를 받을 때 공격
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Combo1");
        }

        //x키를 받을 때  점프
        if (Input.GetKeyDown(KeyCode.X) && controller.isGrounded)
        {
            jumPing.y = jumplevel;
            anim.SetTrigger("Jump");
        }

        //c키를 받을 때 스킬사용
        if (Input.GetKeyDown(KeyCode.C) && playerLevel <= 10)
        {
            anim.SetTrigger("Skill1");

            //레벨에 따른 skill state변경
        }
        else if (Input.GetKeyDown(KeyCode.C) && playerLevel <= 20)
        {
            anim.SetTrigger("Skill2");
            Instantiate(Skill1, transformWeapon.position, Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.C) && playerLevel <= 30)
        {
            anim.SetTrigger("Skill3");
            Instantiate(Skill2, transformWeapon.position, Quaternion.identity);

        }

        //Up Down left Rightkey를 입력받을 시 이동 및 meacanim
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Run", true);
            lookDirection = xx * Vector3.forward + zz * Vector3.right;
            speed = runspeed;

            //LookDirection의 방향&거리로 Transform을 이동
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //controller내부 함수를 이용하여 중력구현
        gravity_time();
        controller.Move(jumPing * Time.deltaTime);
    }

    //중력처리
    void gravity_time()
    {
        jumPing -= new Vector3(0, gravity * Time.deltaTime, 0);
    }

    //캐릭터 회전
    void LookUpdate()
    {
        //From(Player) -> LookDirection방향으로 회전
        if (!lookDirection.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(lookDirection),
                turnspeed);
        }
    }

    void StateCheck()
    {

        //Idle상태일때 모두 초기화
        if (currentBaseState.fullPathHash == idleState)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Damage", false);
            anim.SetBool("Dead", false);
            anim.SetBool("JumpAttack", false);
            anim.ResetTrigger("Skill1");
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Combo1");
            anim.ResetTrigger("Combo2");
            anim.ResetTrigger("Combo3");
            boxCol.enabled = false;
        }
        //죽었을때 전부초기화
        if (currentBaseState.fullPathHash == deadState)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Damage", false);
            anim.SetBool("Dead", false);
            anim.SetBool("JumpAttack", false);
            anim.ResetTrigger("Skill1");
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Combo1");
            anim.ResetTrigger("Combo2");
            anim.ResetTrigger("Combo3");
        }
        //달리기 상태(smoke 생성) & 정지상태
        if (currentBaseState.fullPathHash == runState)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
            if (xx == 0 && zz == 0)
            {
                speed = 0f;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
            }
        }

        //점프공격
        if (currentBaseState.fullPathHash == jumpState && Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.ResetTrigger("Jump");
            anim.SetBool("JumpAttack", true);
            anim.ResetTrigger("Combo1");
        }

        //~콤보2
        if (currentBaseState.fullPathHash == combo1State && Input.GetKey(KeyCode.Z))
        {
            anim.SetTrigger("Combo2");
        }
        //~콤보3
        if (currentBaseState.fullPathHash == combo2State && Input.GetKey(KeyCode.Z))
        {
            anim.SetTrigger("Combo3");
        }
        //콤보공격중 
        if (currentBaseState.fullPathHash == combo1State || currentBaseState.fullPathHash == combo2State)
        {
            boxCol.enabled = true;
            Invoke("BoxBox", 1.7f);

        }
        //콤보3. 모션시간이 길어서 별도의 조건처리를 하였음
        if (currentBaseState.fullPathHash == combo3State)
        {
            boxCol.enabled = true;
        }
        //스킬공격 - none effect
        if (currentBaseState.fullPathHash == skill1State)
        {
            boxCol.enabled = true;
        }

        //스킬2(add effect)
        if (currentBaseState.fullPathHash == skill2State)
        {
            boxCol.enabled = true;
        }

        //스킬3(add effect)
        if (currentBaseState.fullPathHash == skill3State)
        {
            boxCol.enabled = true;
        }

        //점프공격
        if (currentBaseState.fullPathHash == JumpAttack)
        {
            boxCol.enabled = true;
        }
    }
    //invoke사용을 위한 메서드
    void BoxBox()
    {
        boxCol.enabled = false;
    }

    ////////////////////////////////////충돌처리구간///////////////////////////////////////////////
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Monster")) // 몬스터 타격시
        {
            if(currentBaseState.fullPathHash == combo1State ||
                currentBaseState.fullPathHash == combo2State ||
                currentBaseState.fullPathHash == combo3State)
            col.gameObject.GetComponent<MonsterManager>().MonsterCurrentHP -= GetComponent<Player>().attackPower;

            else if(currentBaseState.fullPathHash == skill1State)
            {

            }
        }

        //죽음
        if (m_Hp <= 0)
        {
            anim.SetBool("Dead", true);
        }

        //피격시
        if (col.gameObject.tag == "Bullet")
        {
            //HP_UI.fillAmount = m_Hp / hpMax;
            m_Hp -= 0; // monsterWeapon
            anim.SetBool("Damage", true);
        }
    }
}