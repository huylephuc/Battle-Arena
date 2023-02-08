using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public enum PlayerType
    {
        HUMAN, AI
    }
    public static float maxHealth = 100f;
    public float life = 100f;
    public string fighterName;
    public Fighter opponent;

    public PlayerType player;
    public FighterState currentState = FighterState.Idle;

    protected Animator animator;
    private Rigidbody myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void UpdateHumanInput()
    {
        if(Input.GetAxis("Horizontal")> 0.1)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("WalkBack", true);
        }
        else
        {
            animator.SetBool("WalkBack", false);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("LeftPunch");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("RightPunch");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("LeftKick");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("RightKick");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
    void Update()
    {
        animator.SetFloat("Health", lifePercent);

        if (player == PlayerType.HUMAN)
        {
            UpdateHumanInput();
        }

        if (opponent != null)
        {
            animator.SetFloat("OppHealth", opponent.lifePercent);
        }
        else
        {
            animator.SetFloat("OppHealth", 1);
        }

        if (life <= 0 && currentState != FighterState.KnockOut)
        {
            animator.SetTrigger("KnockOut");
        }
    }

    public bool attacking
    {
        get 
        { 
            return currentState == FighterState.Attack; 
        }
    }

    public virtual void hurt(float damage)
    {
        if (life >= damage)
        {
            life -= damage;
        }
        else
        {
            life = 0;
        }
        if (life > 0)
        {
            animator.SetTrigger("TakeHit");
        }
    }
    public float lifePercent
    {
        get
        {
            return life / maxHealth;
        }
    }

    public Rigidbody body
    {
        get
        { 
            return myBody; 
        }
    }
}
