using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private WeaponMannager weapon_manager;
    public float fire_rate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAni;
    private bool zoomed;
    private bool is_aiming;

    private Camera mainCamera;
    private GameObject chrosshair;

    void Awake() {
        
        weapon_manager = GetComponent<WeaponMannager>();  
        
        zoomCameraAni = transform.Find(Tags.LOOK_ROOT)
            .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>(); 

        chrosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomIn_and_Out();
    }

    void WeaponShoot(){
        if(weapon_manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTI)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                 nextTimeToFire = Time.time + 1f / fire_rate;

                 weapon_manager.GetCurrentSelectedWeapon().ShoootAnimation();
                 // BulletFired();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weapon_manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_manager.GetCurrentSelectedWeapon().ShoootAnimation();
                }

                if(weapon_manager.GetCurrentSelectedWeapon().bullet_type == WeaponBulletType.BULLET)
                {
                    weapon_manager.GetCurrentSelectedWeapon().ShoootAnimation();
                    //BulletFired();
                }
                else
                {
                    if(is_aiming)
                    {
                        weapon_manager.GetCurrentSelectedWeapon().ShoootAnimation();
                        if(weapon_manager.GetCurrentSelectedWeapon().bullet_type
                            == WeaponBulletType.ARROW)
                        {
                            // Do something
                        }
                        else if(weapon_manager.GetCurrentSelectedWeapon().bullet_type
                            == WeaponBulletType.SPEAR)
                        {
                            // Do something
                        }
                            
                    }
                }

            }

        }
    }

    void ZoomIn_and_Out()
    {

        if(weapon_manager.GetCurrentSelectedWeapon().weapon_aim == WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomCameraAni.Play(AnimationTags.ZOOM_IN_ANIM);
                chrosshair.SetActive(false);
            }

            if(Input.GetMouseButtonUp(1))
            {
                zoomCameraAni.Play(AnimationTags.ZOOM_OUT_ANIM);
                chrosshair.SetActive(true);
            }
        }


        if(weapon_manager.GetCurrentSelectedWeapon().weapon_aim == WeaponAim.SELF_AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().Aime(true);
                is_aiming =true;
            }

            if(Input.GetMouseButtonUp(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().Aime(false);
                is_aiming =false;
            }
        }

    }





















































}
