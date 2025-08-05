using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class shoot : MonoBehaviour
{
    
    public GameObject objectPrefab;
    public float bulletForce = 10f;

    
    void Start()
    {
        // bloquea el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // disparo con click izq
        if (Input.GetMouseButtonDown(0))
        {
            // crea la bala en la posición y rotación del objeto actual.
            GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * bulletForce;
            }

            // destruye la bala despues de 3 segundos
            Destroy(bulletClone, 3f);
        }
    }
}
