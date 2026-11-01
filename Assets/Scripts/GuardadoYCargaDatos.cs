using System.Collections.Generic;
using UnityEngine;

public class GuardadoYCargaDatos : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    public struct DatosPartida
    {
        public struct DatosBolas
        {
            public Vector3 tamaño;
            public Color32 color;
            public Vector3 posicion;
            public int indicePropiedadElegida;
            public int indicePropiedadAsociada;
        }

        public struct DatosJugador
        {
            public List<DatosBolas> listaBolasPartida;
            public int vidas;
            public int monedas;
        }
    }

    DatosPartida registroBolasBucket;
    InstanciarPrefabs bolasPartida;

    //MÉTODOS: -------------------------------------

    private void Awake()
    {
        bolasPartida = FindFirstObjectByType<InstanciarPrefabs>();
    }

    void GuardadoDeBolas()
    {
        for (int i = 0; i < bolasPartida.BolasTotales.Count; i++)
        {
            DatosPartida.DatosBolas registro = new DatosPartida.DatosBolas();
            registro.tamaño = bolasPartida.BolasTotales[i].transform.localScale;
            registro.color = bolasPartida.BolasTotales[i].GetComponent<Renderer>().material.color;
            registro.posicion = bolasPartida.BolasTotales[i].transform.position;


        }
    }

}

