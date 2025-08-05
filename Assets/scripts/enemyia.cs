using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// la clase 'enemyia' hereda de la clase abstracta 'enemy'
// esto es herencia y polimorfismo
public class enemyia : enemy
{
    public float rangoDeteccion = 5f;
    public float rangoAtaque = 1.5f;
    public enum Estado { Patrullando, Persiguiendo, Atacando }
    public Estado estadoActual;

    // sobreescribe el método 'Update' de la clase abstracta 'enemy'
    protected override void Update()
    {
        base.Update();
        // calcula la distancia entre el enemigo y el jugador
        float distancia = Vector2.Distance(transform.position, jugador.position);
        // lógica para cambiar el estado del enemigo según la distancia
        if (distancia <= rangoAtaque)
            estadoActual = Estado.Atacando;
        else if (distancia <= rangoDeteccion)
            estadoActual = Estado.Persiguiendo;
        else
            estadoActual = Estado.Patrullando;
    }

    // sobreescribe el método 'Mover' de la clase abstracta 'enemy'
    protected override void Mover()
    {
        switch (estadoActual)
        {
            case Estado.Patrullando:
                // movimiento de patrulla
                rb.velocity = new Vector2(Mathf.Sin(Time.time) * velocidad, rb.velocity.y);
                break;
            case Estado.Persiguiendo:
                // calcula la dirección hacia el jugador y se mueve en esa dirección
                Vector2 dir = (jugador.position - transform.position).normalized;
                rb.velocity = dir * velocidad;
                // voltea el sprite del enemigo según la dirección del movimiento
                transform.localScale = new Vector3(dir.x > 0 ? 1 : -1, 1, 1);
                break;
            case Estado.Atacando:
                // se detiene para atacar
                rb.velocity = Vector2.zero;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // logica de daño por bala
        if (other.CompareTag("bullet"))
        {
            RecibirDano(1);
            Destroy(other.gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // logica de daño por colision al player
        if (collision.gameObject.CompareTag("Player"))
            FindObjectOfType<controler>().RestarVida(20);
    }
}
