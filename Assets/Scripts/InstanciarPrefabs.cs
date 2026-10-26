using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPrefabs : MonoBehaviour
{
    //Aqui intanciamos bolas en el campo, en una zona aleatoria.
    //ATRIBUTOS: -----------------------------------

    //Atributos para las bolas:
    public GameObject prefabBola;
    private Vector3 posicionAleatoria;
    private GameObject BolaActual;
    private PropiedadesBolas metodoBola;

    //Atributos para guardar las bolas:
    public List<GameObject> BolasPropiedadBurbuja = new List<GameObject>();
    public List<GameObject> BolasPropiedadExplosion = new List<GameObject>();
    public List<GameObject> BolasPropiedadAceleracionCreacionBolas = new List<GameObject>();
    public List<GameObject> BolasPropiedadBotar = new List<GameObject>();
    public List<GameObject> BolasPropiedadMovimientoExtra = new List<GameObject>();
    public List<GameObject> BolasPropiedadGameOver = new List<GameObject>();
    public List<GameObject> BolasTotales = new List<GameObject>();

    //MÉTODOS BÁSICOS: -------------------------------------
    
    private void Start()
    {
        StartCoroutine(AparicionBolas());
    }
        
    //MÉTODOS AVANZADOS: -------------------------------------
    void AsociandoAListas()
    {
        metodoBola = BolaActual.GetComponent<PropiedadesBolas>();
        BolasTotales.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 0) BolasPropiedadBurbuja.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 1) BolasPropiedadExplosion.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 2) BolasPropiedadAceleracionCreacionBolas.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 3) BolasPropiedadBotar.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 4) BolasPropiedadMovimientoExtra.Add(BolaActual);
        if (metodoBola.indicePropiedadElegida == 5) BolasPropiedadGameOver.Add(BolaActual);
    }

    //CORRUTINAS: -------------------------------------
    IEnumerator AparicionBolas()
    {
        while(true)
        {
            posicionAleatoria = new Vector3(Random.Range (-7.41f, 6.07f), Random.Range(1.24f, 5f), Random.Range(-8.21f, 7.57f));
            BolaActual = Instantiate(prefabBola, posicionAleatoria, Quaternion.identity);
            AsociandoAListas();
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    
}
