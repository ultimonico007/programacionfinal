using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject objectPrefab;     
    public float bulletForce = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
            GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation);

         
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * bulletForce; 
            }

         
            Destroy(bulletClone, 3f);

        
            
        }
    }
}