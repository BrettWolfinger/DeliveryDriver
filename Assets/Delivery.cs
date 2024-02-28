using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.5f;
    [SerializeField] Color32 hasPackageColor  = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer; 

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision Detected");
        //Colliding with world object drops package
        if(hasPackage)
        {
            Debug.Log("Package Dropped!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //package pickup
        if(other.tag == "Package" && !hasPackage) 
        {
            Debug.Log("Package Collected");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,delay);
        }
        //package delivery
        if(other.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
