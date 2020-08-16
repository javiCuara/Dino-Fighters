using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    // [SerializeField]
    private AudioSource footstep_sound;

    [SerializeField]
    private AudioClip[] footstep_clip;

    private CharacterController character_controller;

    [HideInInspector]
    public float volume_min, volume_max;

    public float accumulated_distance;

    [HideInInspector]
    public float step_distance;

    // Start is called before the first frame update
    void Awake()
    {
        footstep_sound = GetComponent<AudioSource>();
        character_controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootSteps();
    }
    void CheckToPlayFootSteps()
    {
        if (!character_controller.isGrounded)
        {
            return;
        }

        // Test if we are moving

        if (character_controller.velocity.sqrMagnitude > 0)
        {
            accumulated_distance += Time.deltaTime;
            if (accumulated_distance > step_distance)
            {
                footstep_sound.volume = Random.Range(volume_min, volume_max);
                footstep_sound.clip = footstep_clip[Random.Range(0, footstep_clip.Length)];

                footstep_sound.Play();

                accumulated_distance = 0f;
            }
        }
        else
        {
            accumulated_distance = 0f;
        }

    }
}
