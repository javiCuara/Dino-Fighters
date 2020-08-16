using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public float damage = 2f;
    public float radi = 1f;

    public LayerMask layer_mask;

    // Update is called once per frame
    void Update()
    {
        // print("Updating Attack Point Logger");
        Collider[] hits = Physics.OverlapSphere(transform.position, radi, layer_mask);

        if(hits.Length > 0)
        {
            
            print("WE touched: " + hits[0].gameObject.tag);
            gameObject.SetActive(false);
        }
        else
        {
            print("Collier array empty");
        }
    }





}
