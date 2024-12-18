using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public int cantidadMonedas = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Moneda recogida por el jugador");
            controler controler = FindObjectOfType<controler>();
            if (controler != null)
            {
                controler.AddCoin(cantidadMonedas);
            }

            
            Destroy(gameObject);
        }
    }
}
