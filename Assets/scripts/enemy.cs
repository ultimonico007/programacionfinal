using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// define la clase base 'enemy' como abstracta
public abstract class enemy : MonoBehaviour
{
    public int maxVida = 3;
    protected int vidaActual;
    public float velocidad = 3f;
    public GameObject drop;
    protected Rigidbody2D rb;
    protected Transform jugador;
    //metodo virtual lo que permite que las clases derivadas lo sobrescriban
    protected virtual void Start()
    {
        vidaActual = maxVida;
        rb = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //tambien es virtual para poder ser sobreescrito
    protected virtual void Update()
    {
        Mover();
    }

    // metodo virtual para recibir daño
    public virtual void RecibirDano(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
            Morir();
    }
    protected virtual void Morir()
    {
        // suma puntos al controlador y crea un objeto de 'drop' si existe
        FindObjectOfType<controler>()?.Addkill(100);
        if (drop != null)
            Instantiate(drop, transform.position, Quaternion.identity);

        // destruye el objeto del enemigo
        Destroy(gameObject);
    }

    // metodo 'abstracto' sin implementación,las derivadas lo utilizaran
    protected abstract void Mover();
}