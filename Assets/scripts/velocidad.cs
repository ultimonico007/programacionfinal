using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocidad : MonoBehaviour,Ipowerup
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    // metodo que implementa la interfaz
    public void Activate(GameObject player)
    {
        mov controlador = player.GetComponent<mov>();
        if (controlador != null)
        {
            controlador.ActivarPowerUpVelocidad(speedMultiplier, duration);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Activate(other.gameObject);
            // se destruye despues de usarse
            Destroy(gameObject);
        }
    }
}
