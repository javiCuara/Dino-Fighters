using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private WeaponMannager weapon_manager;
    public float fire_rate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;




    void Awake() {
        weapon_manager = GetComponent<WeaponMannager>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
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
                    
                }

            }

        }
    }

























}
