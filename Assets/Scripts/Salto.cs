using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public Rigidbody2D rbd;
    public float Fuerza;
    public bool TocandoSuelo;
    public AudioSource fx00;

    [Header("Salto")]
    private Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        //animator.SetFloat("Horizontal", Mathf.Abs(Salto));
        Saltar();
       

    }

    private void OnCollisionEnter2D(Collision2D LaCosa)
    {
        if (LaCosa.gameObject.tag == "Ground")
        {
            TocandoSuelo = true;
        }
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo == true)
        {
            rbd.AddForce(Vector2.up * Fuerza, ForceMode2D.Impulse);
            TocandoSuelo = false;
            fx00.Play();
        }
    }

}
