using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    //variables para controlar la velocidad, el rigidbody, la fuerza y el sprite del jugador.
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 ultimaFuerza;
    private bool puederecibirfuerza = true;
    private SpriteRenderer spriteRenderer;
    // declara una action
    public static Action<string> AlActivarPowerUp;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        //movimiento basico
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movimiento = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movimiento * velocidad;
        // Voltea el sprite del jugador según la dirección
        if (horizontal > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (horizontal < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //colision y estabilidad del personaje
        if (collision.gameObject.CompareTag("enemy") && puederecibirfuerza)
        {
            Vector2 direccion = (transform.position - collision.transform.position).normalized;
            ultimaFuerza = direccion * 5f;
            rb.AddForce(ultimaFuerza, ForceMode2D.Impulse);
            StartCoroutine(CooldownFuerza(1f));
        }
    }
    private IEnumerator CooldownFuerza(float duracion)
    {
        puederecibirfuerza = false;
        yield return new WaitForSeconds(duracion);
        puederecibirfuerza = true;
    }
    public void ActivarPowerUpVelocidad(float multiplicador, float duracion)
    {
        StartCoroutine(PowerUpVelocidad(multiplicador, duracion));
    }

    // corrutina para el power-up de velocidad.
    private IEnumerator PowerUpVelocidad(float multiplicador, float duracion)
    {
        // aumenta la velocidad
        velocidad *= multiplicador;
        // notifica su activacion
        AlActivarPowerUp?.Invoke("¡Velocidad aumentada!");

        yield return new WaitForSeconds(duracion);

        // vuelve a la velocidad normal
        velocidad /= multiplicador;
        // notifica nuevamente
        AlActivarPowerUp?.Invoke("Velocidad normal.");
    }
}