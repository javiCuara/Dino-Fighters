using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM,
}

public enum WeaponFireType
{
    SINGLE,
    MULTI
}

public enum WeaponBulletType
{
    BULLET,
    ARROW,
    SPEAR,
    NONE
}


public class WeaponHandler : MonoBehaviour
{
    private Animator ani;

    public WeaponAim weapon_aim;

    [SerializeField]
    private GameObject muzzelFlash;

    [SerializeField]    
    private AudioSource shootSound, reload_sound;

    public WeaponFireType fireType;
    public WeaponBulletType bullet_type;
    public GameObject attack_point;


    void Awake() {
        ani = GetComponent<Animator>();    
    }

    public void ShoootAnimation(){
        ani.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aime(bool canAim){
        ani.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void Turn_on_MuzzelFlash(){
        muzzelFlash.SetActive(false);
    }

    void Play_Shoot_Sounds()
    {
        shootSound.Play();

    }

    void  Play_ReloadSound()
    {
        reload_sound.Play();
    }
    void  Turn_on_AttackPoin()
    {
        attack_point.SetActive(true);
    }
    void  Turn_off_AttackPoin()
    {
        if(attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);
        }
    }





}
