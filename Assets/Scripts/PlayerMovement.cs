using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
[SerializeField]
    public float jumpforce = 1000f;
    private Rigidbody2D playerRB;
    public LayerMask groundMask;
    public bool grounded;
    public float speed = 1000f;
    [SerializeField] private float runningSpeed = 2f;
    Vector3 startPosition;

    public bool gameover = false;
    public float velCaida;
    public float increVel;
    public float lapsoNvl;
    public float increLapso;
    public float tiempo;

    public GameObject Player;
    public GameManager GM;
    public AudioSource GMAudio;
    public AudioSource CoinAudio;

    [SerializeField] private float cantPuntos;
    [SerializeField] private Coins coin;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        startPosition = this.transform.position;

    }

    public void StartGame()
    {
        this.transform.position = startPosition;
        this.playerRB.velocity = Vector2.zero;
    }

    private void Update()
    {
        
        

        Debug.DrawRay(this.transform.position, Vector2.down * 2.0f, Color.red);

        tiempo = Time.timeSinceLevelLoad;
        if (tiempo > lapsoNvl)
        {
            runningSpeed += increVel;
            lapsoNvl += increLapso;
        }

    }

     void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump();
        }
        if(playerRB.velocity.x < runningSpeed)
        {
            playerRB.velocity = new Vector2(runningSpeed, playerRB.velocity.y);
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            //movement.Die();
            GMAudio.Play();
            Debug.Log("MORISTE");
            GM.GameOver();

        }

        if (collision.tag == "Coin")
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();

            CoinAudio.Play();
            Debug.Log("MONEDA");
            coin = FindAnyObjectByType<Coins>();
            //puntaje.SumarPuntos(cantPuntos);
            coin.SMRPNTS();

        }

    }


    

}
