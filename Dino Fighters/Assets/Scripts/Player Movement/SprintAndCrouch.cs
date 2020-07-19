using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintAndCrouch : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement PlayerMovement;
    private Transform lookRoot;

    private float stand_height = 1.6f;
    private float crouch_height = 1f;
    
    public float sprint_speed = 10f;
    public float move_speed = 5f;
    public float crouch_speed = 2f;

    private bool isCrouching;

    private PlayerFootSteps player_FootSteps;
    private float sprint_volume = 1f;
    private float crouch_voulume = 0.1f;
    private float walk_volume_min = 0.2f, walk_volume_max = 0.6f;
    private float walk_step_distance = 0.4f;
    private float sprint_step_distance = 0.25f;
    private float crouch_step_distance = 0.5f;
    private void Awake() {
        PlayerMovement = GetComponent<PlayerMovement>();
        lookRoot = transform.GetChild(0);

        player_FootSteps = GetComponentInChildren<PlayerFootSteps>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player_FootSteps.volume_min = walk_volume_min;
        player_FootSteps.volume_max = walk_volume_max;
        player_FootSteps.step_distance = walk_step_distance;

    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }
    void Sprint(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            PlayerMovement.speed = sprint_speed;
            
            player_FootSteps.step_distance = sprint_step_distance;
            player_FootSteps.volume_min =  sprint_volume;
            player_FootSteps.volume_max = sprint_volume;

        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            PlayerMovement.speed = move_speed;

            player_FootSteps.step_distance = walk_step_distance;
            player_FootSteps.volume_min =  walk_volume_min;
            player_FootSteps.volume_max = walk_volume_max;
            
        }
    }

    void Crouch(){
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(isCrouching)
            {
                lookRoot.localPosition = new Vector3(0f, stand_height, 0f);
                PlayerMovement.speed = move_speed; 
                isCrouching = false;
            }
            else
            {
                lookRoot.localPosition = new Vector3(0f, crouch_height, 0f);
                PlayerMovement.speed = crouch_speed;
                
                player_FootSteps.step_distance = crouch_step_distance;
                player_FootSteps.volume_min =  crouch_voulume;
                player_FootSteps.volume_max = crouch_voulume;

                isCrouching = true;
            }
        }
    }
}
