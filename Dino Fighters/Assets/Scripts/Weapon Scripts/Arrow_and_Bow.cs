using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_and_Bow : MonoBehaviour
{


    private Rigidbody myBody;
    public float speed = 30f;
    public float deactivate_timer = 3f;
    public float damage = 15;




    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_timer);
    }

    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;
        transform.LookAt(transform.position + myBody.velocity);

    }
    void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider target)
    {

    }
}






































