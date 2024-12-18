using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public float velocidad = 5f;          
    private Rigidbody2D rb;
    private Vector2 ultimaFuerza;       
    private bool puederecibirfuerza = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movimiento * velocidad;
        if (horizontal > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (horizontal < 0) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && puederecibirfuerza)
        {
            
            Vector2 direccion = (transform.position - collision.transform.position).normalized;
            ultimaFuerza = direccion * 5f; 
            rb.AddForce(ultimaFuerza, ForceMode2D.Impulse);

            
            StartCoroutine(CooldownFuerza(1f));
        }
    }

    private System.Collections.IEnumerator CooldownFuerza(float duracion)
    {
        puederecibirfuerza = false;
        yield return new WaitForSeconds(duracion);
        puederecibirfuerza = true;
    }
}
