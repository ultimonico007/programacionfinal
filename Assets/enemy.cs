using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxVida; 
    private int vidaActual;
    public float velocidad; 
    public GameObject drop;
    private Rigidbody2D rb;

    
    public enum Estado { Patrullando, Persiguiendo, Atacando }
    public Estado estadoActual;

    public Transform jugador; 
    public float rangoDeteccion = 5f; 
    public float rangoAtaque = 1.5f; 

    void Start()
    {
        vidaActual = maxVida;
        rb = GetComponent<Rigidbody2D>();
        estadoActual = Estado.Patrullando;

       
        if (jugador == null)
            jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        switch (estadoActual)
        {
            case Estado.Patrullando:
                Patrullar();
                break;

            case Estado.Persiguiendo:
                Perseguir();
                break;

            case Estado.Atacando:
                Atacar();
                break;
        }

        
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

        if (distanciaAlJugador <= rangoAtaque)
        {
            estadoActual = Estado.Atacando;
        }
        else if (distanciaAlJugador <= rangoDeteccion)
        {
            estadoActual = Estado.Persiguiendo;
        }
        else
        {
            estadoActual = Estado.Patrullando;
        }
    }

    void Patrullar()
    {
        rb.velocity = new Vector2(Mathf.Sin(Time.time) * velocidad, rb.velocity.y);
    }

    void Perseguir()
    {
        
        Vector2 direccion = (jugador.position - transform.position).normalized;
        rb.velocity = direccion * velocidad;
        if (direccion.x > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else if (direccion.x < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
    }

    void Atacar()
    {
        
        rb.velocity = Vector2.zero; 
    }

    public void RecibirDano(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        controler controler = FindObjectOfType<controler>();
        if (controler != null)
        {
          
            controler.Addkill(100); 
        }

        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("bullet"))
        {
            RecibirDano(1); 
            Destroy(other.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controler controler = FindObjectOfType<controler>();
            if (controler != null)
            {
                controler.RestarVida(20); 
            }
        }
    }


}
