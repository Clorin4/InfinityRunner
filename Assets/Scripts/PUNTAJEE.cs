using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PUNTAJEE : MonoBehaviour
{
    private float puntos;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        puntos += Time.deltaTime;  // si sumas cosas pasan cosas
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }

}
