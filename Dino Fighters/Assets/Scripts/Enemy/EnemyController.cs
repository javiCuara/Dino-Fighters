using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}
public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemy_ani;
    private NavMeshAgent nav_agent;
    private EnemyState enemy_state;

    public float walk_speed = 0.5f;
    public float run_speed = 4f;
    public float chase_distance = 7f;
    private float current_chase_distance;
    public float attack_distance = 1.8f;
    public float chase_after_attack_distance = 2f;

    public float patrol_rad_min = 20f, patrol_rad_max = 60f;
    public float patrol_for_this_time = 15f;
    private float patrol_timer;
    public float wait_before_attack = 2f;
    public float attack_timer;
    private Transform target;

    void Awake()
    {
        enemy_ani = GetComponent<EnemyAnimator>();
        nav_agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        enemy_state = EnemyState.PATROL;
        patrol_timer = patrol_for_this_time;
        attack_timer = wait_before_attack;

        current_chase_distance = chase_distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_state == EnemyState.PATROL)
        {
            Patrol();
        }
        if (enemy_state == EnemyState.CHASE)
        {
            Chase();
        }
        if (enemy_state == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Patrol()
    {
        nav_agent.isStopped = false;
        nav_agent.speed = walk_speed;
        patrol_timer += Time.deltaTime;

        if (patrol_timer > patrol_for_this_time)
        {
            SetNewRandomDestination();
            patrol_timer = 0f;
        }

        // if moving then we need to animate
        if (nav_agent.velocity.sqrMagnitude > 0)
        {
            enemy_ani.walk(true);
        }
        else
        {
            enemy_ani.walk(false);
        }

        // Test Platey enemy distance
        if (Vector3.Distance(transform.position, target.position) <= chase_distance)
        {
            enemy_ani.walk(false);
            enemy_state = EnemyState.CHASE;
            // play spotted audio

            Chase();
        }
    }
    void Chase()
    {

        nav_agent.isStopped = false;
        nav_agent.speed = run_speed;

        // Set target Destination
        nav_agent.SetDestination(target.position);

        if (nav_agent.velocity.sqrMagnitude > 0)
        {
            enemy_ani.run(true);
        }
        else
        {
            enemy_ani.run(false);
        }


        if (Vector3.Distance(transform.position, target.position) <= attack_distance)
        {
            enemy_ani.run(false);
            enemy_ani.walk(false);
            enemy_state = EnemyState.ATTACK;

            if (chase_distance != current_chase_distance)
            {
                chase_distance = current_chase_distance;
            }

        }
        else if (Vector3.Distance(transform.position, target.position) > chase_distance)
        {
            enemy_ani.run(false);
            enemy_state = EnemyState.PATROL;

            patrol_timer = patrol_for_this_time;

            if (chase_distance != current_chase_distance)
            {
                chase_distance = current_chase_distance;
            }



        }
        else
        {

        }
    }
    void Attack()
    {
        nav_agent.velocity = Vector3.zero;
        nav_agent.isStopped = true;
        attack_timer += Time.deltaTime;

        if (attack_timer > wait_before_attack)
        {
            enemy_ani.Attack();
            attack_timer = 0f;

            // play attack sound
        }
        if (Vector3.Distance(transform.position, target.position) > attack_distance + chase_after_attack_distance)
        {
            enemy_state = EnemyState.CHASE;
        }
 
    }

    void SetNewRandomDestination()
    {
        float rand_radi = Random.Range(patrol_rad_min, patrol_rad_max);
        Vector3 randDir = Random.insideUnitSphere * rand_radi;

        randDir += transform.position;
        // NavMeshHit nav_hit;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, rand_radi, -1);

        nav_agent.SetDestination(navHit.position);
    }









}//class
