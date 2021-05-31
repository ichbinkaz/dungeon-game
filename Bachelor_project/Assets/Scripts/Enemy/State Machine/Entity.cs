using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FinateStateMachine stateMachine;

    public D_Entity entityData;

    public int facingDirection { get; private set; }
    

    public Rigidbody2D rb { get; private set; }

    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;


    private float currentHealth;
    
   
    private Vector2 velocityWorkspace;

    
    protected bool isDead;
                 
    public virtual void Start()
    {
        facingDirection = 1;
        currentHealth = entityData.maxHealth;
        

        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        atsm = aliveGO.GetComponent<AnimationToStateMachine>();

        stateMachine = new FinateStateMachine();

    }
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();

        
    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
        
    }
    

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }
    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGround);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }
    public virtual void DamageHop (float velocity)
    {
        velocityWorkspace.Set(rb.velocity.x, velocity);
        rb.velocity = velocityWorkspace;
    }
    

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
      
        currentHealth -= attackDetails.damageAmount;
        

        DamageHop(entityData.damageHopSpeed);

        if(attackDetails.position.x>aliveGO.transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }
      
        if(currentHealth <= 0)
        {
            isDead = true;
            ScoreCounter.scoreValue++;
        }

    }
    
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);

    }
    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }

}
