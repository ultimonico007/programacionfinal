using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{

    public int cantidadMonedas = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // condicional para saber si es la moneda el objeto recogido
        if (collision.CompareTag("Player") && gameObject.CompareTag("moneda"))
        {
            Debug.Log("Moneda recogida por el jugador");

            //suma de moneda al contador
            controler controler = FindObjectOfType<controler>();
            if (controler != null)
            {
                controler.AddCoin(cantidadMonedas);
            }

            Destroy(gameObject); // destruye la moneda tras recogerla
        }
    }
}