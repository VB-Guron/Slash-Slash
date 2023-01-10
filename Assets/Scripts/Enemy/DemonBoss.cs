using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    [SerializeField] private float detectionRange, attackRange, retreatRange, roamRange, moveSpeed, attackSpeed, spawnRate;
    [SerializeField] private GameObject attack;

    private Spawner spawner;
    private SpriteRenderer sprite;
    private Transform player;
    private float shootTime, spawnTime;
    private Rigidbody2D rb;
    private Vector3 startingPosition, roamPosition, center;
    private Vector2 movement;
    private State state;

    private enum State
    {
        Roam, Aggro
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        spawner = GetComponent<Spawner>();
        startingPosition = transform.position;
        roamPosition = GetRoamPosition();

        state = State.Roam;
    }

    private void FixedUpdate()
    {
        center = transform.position;
        switch (state)
        {
            case State.Roam:
                SetDirection(roamPosition);

                if (Vector2.Distance(center, roamPosition) < .1f)
                {
                    roamPosition = GetRoamPosition();
                }

                FindPlayer();
                break;

            case State.Aggro:
                if (!InAttackRange())
                    SetDirection(player.position);
                else if (InAttackRange())
                {
                    SetDirection(center);
                    Attack();
                    Spawn();

                    if (Vector3.Distance(player.position, center) < retreatRange)
                    {
                        SetDirection(-player.position);
                    }

                }

                break;

        }
        Move(movement);
    }

    private void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void SetDirection(Vector3 dir)
    {
        dir = dir - center;

        movement = dir.normalized;

       
            if (dir.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
     


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
        Vector2 diff = player.position - center;
        float sign = (player.position.y < center.y)? -1f : 1f;

        float angle = (Vector2.Angle(Vector2.right, diff) * sign) - 90;
        if (shootTime <= 0)
        {
            Instantiate(attack, center, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            shootTime = 1 / attackSpeed;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        if (spawnTime <= 0)
        {
            StartCoroutine(spawner.SpawnEnemy());
            spawnTime = 1 / spawnRate;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
    private bool InDetectRange()
    {
        return Vector3.Distance(player.position, center) < detectionRange;
    }

    private bool InAttackRange()
    {
        return Vector3.Distance(player.position, center) < attackRange;
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

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, attackRange);

        Gizmos.DrawWireSphere(roamPosition, .1f);
    }
}
