using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosuelook : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_unlock = true;

    [SerializeField]
    private float mouseSensitivity = 5f ;

    [SerializeField]
    private int smooth_steps =10;

    [SerializeField]
    private float smooth_weight = 0.4f;

    [SerializeField]
    private float roll_angel = 10f;

    [SerializeField]
    private float roll_speed = 3f;

    [SerializeField]
    private Vector2 default_look_lim = new Vector2(-70f, 80f);

    private Vector2 look_angles;
    private Vector2 current_mouse_look;
    private Vector2 smooth_move;

    private float current_roll_angle;
    private int last_look_frame;
    
    //float xRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();
        if(Cursor.lockState ==  CursorLockMode.Locked)
        {
            LookAround();
        }
    }
    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState =  CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void LookAround()
    {
        current_mouse_look = new Vector2( Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        look_angles.x += current_mouse_look.x * mouseSensitivity * ( invert ? 1f: -1f);
        look_angles.y += current_mouse_look.y * mouseSensitivity;

        look_angles.x = Mathf.Clamp(look_angles.x, default_look_lim.x, default_look_lim.y);

        current_roll_angle =  
            Mathf.Lerp(current_roll_angle,Input.GetAxisRaw("Mouse X") * roll_angel,
             Time.deltaTime * roll_speed);

        lookRoot.localRotation = Quaternion.Euler(look_angles.x, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f,look_angles.y,0f ); 
    }  
}
