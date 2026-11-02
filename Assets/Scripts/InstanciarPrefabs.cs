using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPrefabs : MonoBehaviour
{
    //Aqui intanciamos bolas en el campo, en una zona aleatoria.
    //ATRIBUTOS: -----------------------------------

    //Atributos para registro de datos:
    public DataKPIPiscinaBolas KPIBolasTotales;
    private CargaDeDatosPartida anulacionTemporalInstancia;

    //Atributos Públicos:
    [HideInInspector]
    public bool AceleracionInstancias;
    [HideInInspector]
    public GameObject prefabBola;

    public List<GameObject> BolasPropiedadBurbuja = new List<GameObject>();
    public List<GameObject> BolasPropiedadExplosion = new List<GameObject>();
    public List<GameObject> BolasPropiedadAceleracionCreacionBolas = new List<GameObject>();
    public List<GameObject> BolasPropiedadBotar = new List<GameObject>();
    public List<GameObject> BolasPropiedadMovimientoExtra = new List<GameObject>();
    public List<GameObject> BolasPropiedadGameOver = new List<GameObject>();
    public List<GameObject> BolasTotales = new List<GameObject>();

    public List<GameObject>[] listasTotales;

    //Atributos Privados:
    private GameObject BolaActual;
    private Vector3 posicionAleatoria;
    private PropiedadesBolas metodoBola;






    //MÉTODOS BÁSICOS: -------------------------------------

    private void Awake()
    {
        listasTotales = new List<GameObject>[]
        {
            BolasPropiedadBurbuja,
            BolasPropiedadExplosion,
            BolasPropiedadAceleracionCreacionBolas,
            BolasPropiedadBotar,
            BolasPropiedadMovimientoExtra,
            BolasPropiedadGameOver,
            BolasTotales,
        };
        anulacionTemporalInstancia = FindFirstObjectByType<CargaDeDatosPartida>();
    }

    private void Start()
    {
        if(anulacionTemporalInstancia.cargarPartidaGuardada == false) StartCoroutine(AparicionBolas());
    }


    //MÉTODOS AVANZADOS: -------------------------------------
    public void AsociandoAListas(GameObject bola)
    {
        metodoBola = bola.GetComponent<PropiedadesBolas>();
        BolasTotales.Add(bola);
        if (metodoBola.indicePropiedadElegida == 0) BolasPropiedadBurbuja.Add(bola);
        if (metodoBola.indicePropiedadElegida == 1) BolasPropiedadExplosion.Add(bola);
        if (metodoBola.indicePropiedadElegida == 2) BolasPropiedadAceleracionCreacionBolas.Add(bola);
        if (metodoBola.indicePropiedadElegida == 3) BolasPropiedadBotar.Add(bola);
        if (metodoBola.indicePropiedadElegida == 4) BolasPropiedadMovimientoExtra.Add(bola);
        if (metodoBola.indicePropiedadElegida == 5) BolasPropiedadGameOver.Add(bola);
    }

    public void EliminacionBolasListas(GameObject bolaDestruida)
    {
        BolasPropiedadBurbuja.Remove(bolaDestruida);
        BolasPropiedadExplosion.Remove(bolaDestruida);
        BolasPropiedadAceleracionCreacionBolas.Remove(bolaDestruida);
        BolasPropiedadBotar.Remove(bolaDestruida);
        BolasPropiedadMovimientoExtra.Remove(bolaDestruida);
        BolasPropiedadGameOver.Remove(bolaDestruida);
        BolasTotales.Remove(bolaDestruida);
    }

   

    //CORRUTINAS: -------------------------------------
    IEnumerator AparicionBolas()
    {
        while (true)
        {
            posicionAleatoria = new Vector3(Random.Range(-7.41f, 6.07f), Random.Range(1.24f, 5f), Random.Range(-8.21f, 7.57f));

            BolaActual = Instantiate(prefabBola, posicionAleatoria, Quaternion.identity);
            if (KPIBolasTotales != null) KPIBolasTotales.DatoRecibidoBasico();
            AsociandoAListas(BolaActual);
            if (AceleracionInstancias) //esta variable se activa desde una de las propiedades.
            {
                yield return new WaitForSeconds(0f);
                StartCoroutine(AceleracionBolas());
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }

            while(BolasTotales.Count >= 30)
            {
                yield return null;
            }
        }
    }

    IEnumerator AceleracionBolas()
    {
        yield return new WaitForSeconds(1f);
        AceleracionInstancias = false;
        metodoBola.finAceleracion = true;
    }
    
}
