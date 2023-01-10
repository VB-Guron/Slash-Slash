using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBoss : MonoBehaviour
{
    [SerializeField] private float detectionRange, retreatRange, roamRange, moveSpeed;

    private SpriteRenderer sprite;
    private Transform player;
    private float shootTime, timeBeforeAttack = 3;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 startingPosition, roamPosition, center, target;
    private Vector2 movement;
    private State state;
    private bool lockedOn = false;

    private enum State
    {
        Roam, Aggro
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        roamPosition = GetRoamPosition();
        anim = GetComponent<Animator>();

        state = State.Roam;
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
        center = transform.position;
        switch (state)
        {
            case State.Roam:
                SetDirection(roamPosition);

                if (Vector2.Distance(center, roamPosition) < .1f)
                {
                    roamPosition = GetRoamPosition();
                }
                Move(movement);
                FindPlayer();
                break;

            case State.Aggro:

                Attack();
                break;

        }
    }

    private void UpdateAnimation()
    {
        if (movement == new Vector2(0,0))
        {
            anim.SetInteger("State", 0);
        }
        else if (lockedOn == true)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 1);
        }
    }

    private void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void Move(Vector2 direction, float speed)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void SetDirection(Vector3 dir)
    {
        dir = dir - center;

        movement = dir.normalized;

        if (state != State.Aggro)
        {
            if (dir.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement == new Vector2(0,0))
        {
            if ((player.position - center).x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
      


    }

    private void FindPlayer()
    {
        if (InDetectRange())
        {
            state = State.Aggro;
            SetDirection(player.position);
        }
    }

    private void Attack()
    {
        if (shootTime <= 0)
        {
            lockedOn = false;
        }

        if (lockedOn == false)
        {
            target = GetTarget();
            lockedOn = true;
            shootTime = timeBeforeAttack;
        }

        SetDirection(target);

        if (Vector2.Distance(center, target) < .1f)
        {
            SetDirection(center);
            shootTime -= Time.deltaTime;
        }

        Move(movement, moveSpeed * 3);
    }

    private Vector2 GetTarget()
    {

        return new Vector2(player.position.x, player.position.y);

    }

    private bool InDetectRange()
    {
        return Vector3.Distance(player.position, center) < detectionRange;
    }

    private Vector2 GetRoamPosition()
    {
        Vector2 random = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        return ((Vector2)startingPosition + random * Random.Range(0, roamRange));
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center, detectionRange);

        Gizmos.DrawWireSphere(center, retreatRange);

        Gizmos.DrawWireSphere(roamPosition, .1f);
    }
}
