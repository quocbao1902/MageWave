using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yellow : MonoBehaviour
{
    private Animator m_Animator;
    private DamageDealer DamageDealer;
    private AudioSource audioSource;

    //-------------------------------------------------------------------------------------------------------
    //Move
    public float MoveSpeed;
    private Vector3 MoveInput;
    private Rigidbody2D rb;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    //-------------------------------------------------------------------------------------------------------
    //Dash
    public float DashBoost;
    public float DashTime;
    private float _DashTime;
    private bool isDashing = false;

    public KeyCode DashKey;

    //-------------------------------------------------------------------------------------------------------   
    //hit colliders
    public GameObject AttackCollider;
    public Transform AttackSpawnPoint;
    public GameObject SkillAttackCollider;
    public Transform SkillAttackSpawnPoint;

    //-------------------------------------------------------------------------------------------------------   
    //attack
    public KeyCode AttackKey;
    public float AttackTime;
    private float _AttackTime;
    private bool isAttacking = false;
    public AudioClip AttackSound;

    //-------------------------------------------------------------------------------------------------------
    //attack skill
    public KeyCode AttackSkillKey;
    public float AttackSkillTime;
    private float _AttackSkillTime;
    private bool isAttackingSkill = false;
    public GameObject Skill;
    public AudioClip attackSkillSound;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dash();
        Attacks();
        AttackSkill();

    }

    //-------------------------------------------------------------------------------------------------------

    void Move()
    {
        Vector3 MoveInput = Vector3.zero;

        if (Input.GetKey(upKey))
        {
            MoveInput.y += 1f;
        }
        if (Input.GetKey(downKey))
        {
            MoveInput.y -= 1f;
        }
        if (Input.GetKey(leftKey))
        {
            MoveInput.x -= 1f;
        }
        if (Input.GetKey(rightKey))
        {
            MoveInput.x += 1f;
        }

        // Normalize movement to prevent faster diagonal movement
        rb.velocity = MoveInput.normalized * MoveSpeed;
        m_Animator.SetFloat("isRunning", MoveInput.sqrMagnitude);

        if (MoveInput.x != 0)
        {
            if (MoveInput.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //-------------------------------------------------------------------------------------------------------

    void Dash()
    {
        if (Input.GetKeyDown(DashKey) && _DashTime <= 0 && isDashing == false)
        {
            MoveSpeed += DashBoost;
            _DashTime = DashTime;
            isDashing = true;
        }

        if (_DashTime <= 0 && isDashing == true)
        {
            MoveSpeed -= DashBoost;
            isDashing = false;
        }
        else
            _DashTime -= Time.deltaTime;
    }

    //-------------------------------------------------------------------------------------------------------

    void Attacks()
    {
        //Attack
        if (Input.GetKeyDown(AttackKey) && _AttackTime <= 0 && isAttacking == false)
        {
            if (AttackCollider != null && AttackSpawnPoint != null)
            {
                GameObject ThunderShot = Instantiate(AttackCollider, AttackSpawnPoint.position, AttackSpawnPoint.rotation);
                Rigidbody2D rb = ThunderShot.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    //rb.velocity = ThunderShotSpawnPoint.up * 0.5f;
                    Vector2 direction = new Vector2(-transform.localScale.x, 0);
                    rb.velocity = direction.normalized * 2f;
                }
            }

            if (AttackSound != null)
            {
                audioSource.PlayOneShot(AttackSound);
            }

            _AttackTime = AttackTime;
            isAttacking = true;
            m_Animator.SetTrigger("isAttacking");
        }

        if (_AttackTime <= 0 && isAttacking == true)
        {
            isAttacking = false;
        }
        else
            _AttackTime -= Time.deltaTime;
    }

    //-------------------------------------------------------------------------------------------------------

    void AttackSkill()
    {
        if (Input.GetKeyDown(AttackSkillKey) && _AttackSkillTime <= 0 && isAttackingSkill == false)
        {
            if (SkillAttackCollider != null && SkillAttackSpawnPoint != null)
            {
                GameObject LightningStrike = Instantiate(SkillAttackCollider, SkillAttackSpawnPoint.position, SkillAttackSpawnPoint.rotation);                
            }

            if (attackSkillSound != null)
            {
                audioSource.PlayOneShot(attackSkillSound);
            }

            _AttackSkillTime = AttackSkillTime;
            isAttackingSkill = true;
            Skill.SetActive(false);
            m_Animator.SetTrigger("isAttackingSkill");
        }

        if (_AttackSkillTime <= 0 && isAttackingSkill == true)
        {
            isAttackingSkill = false;
            Skill.SetActive(true);
        }
        else
            _AttackSkillTime -= Time.deltaTime;
    }
}