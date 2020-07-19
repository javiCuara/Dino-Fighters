using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charater_controller;
    private Vector3 move_dir;
    public float speed = 5f;
    public float gravity = 9.81f;

    public float jump = 10f;

    private float v_velocity;
    void Awake(){
        charater_controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        move_dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move_dir = transform.TransformDirection(move_dir);
        move_dir *= speed * Time.deltaTime;
        PlayerGravity();
        charater_controller.Move(move_dir);
    }
    void PlayerGravity(){
        v_velocity -= gravity * Time.deltaTime;
        PlayerJump();
        move_dir.y = v_velocity * Time.deltaTime;
    }
    void PlayerJump(){
        if(charater_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            v_velocity = jump;
        }
    }
}
