using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class controler : MonoBehaviour
{
    // Start is called before the first frame update
    public int kills;
    public int totalenemies;
    public int monedas;
    public int vidajugador = 100;
    public int puntuacion;
    public float defeatTimer = 60f;
    public TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI killstext;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI wintext;
    [SerializeField] private TextMeshProUGUI losetext;
    [SerializeField] private TextMeshProUGUI menutext;
    [SerializeField] private TextMeshProUGUI vidatext;


    private bool gameEnd = false;
    void Start()
    {

        wintext.enabled = false;
        losetext.enabled = false;
        menutext.enabled = false;
        totalenemies = GameObject.FindGameObjectsWithTag("enemy").Length;
        UpdateUI();
        timeText.text = defeatTimer.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = defeatTimer.ToString("F1");
        if (gameEnd && Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
        if (defeatTimer > 0)
        {
            defeatTimer -= Time.deltaTime;
        }
        else
        {
            Gameover();
        }

    }
    public void Addkill(int puntosporenemigo)
    {
        kills++;
        puntuacion += puntosporenemigo;
        UpdateUI();
        if (kills >= totalenemies)
        {
            Time.timeScale = 0;
            wintext.enabled = true;
            menutext.enabled = true;
            gameEnd = true;
        }

    }
    public void AddCoin(int cantidad)
    {
        monedas += cantidad;
        UpdateUI();
    }
    public void RestarVida(int cantidad)
    {
        vidajugador -= cantidad;
        UpdateUI();
        if (vidajugador <= 0)
        {
            Gameover(); 
        }
    }
    public void Gameover()
    {
        losetext.enabled = true;
        menutext.enabled = true;
        Time.timeScale = 0;
        gameEnd = true;
    }
    public void UpdateUI()
    {
        killstext.text = kills.ToString() + "/" + totalenemies.ToString();
        coinText.text = "Monedas: " + monedas;
        scoreText.text = "Puntos: " + puntuacion;
        vidatext.text = "Vida: " + vidajugador;
    }
}