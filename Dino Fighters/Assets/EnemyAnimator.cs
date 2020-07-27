using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    private Animator animator_;


    void Awake()
    {
        animator_ = GetComponent<Animator>();
    }
    
    public void walk(bool walk)
    {
        animator_.SetBool(AnimationTags.WALK_PARAMETER, walk);
    } 

    public void run(bool run)
    {
        animator_.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    
    public void Attack()
    {
        animator_.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }

    public void Dead()
    {
        animator_.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }








}
