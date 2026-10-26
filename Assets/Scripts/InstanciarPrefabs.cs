using System.Collections;
using UnityEngine;

public class InstanciarPrefabs : MonoBehaviour
{
    //Aqui intanciamos bolas en el campo, en una zona aleatoria.
    //ATRIBUTOS: -----------------------------------

    //Atributos para las bolas:
    public GameObject prefabBola;
    private Vector3 posicionAleatoria;

    //MÉTODOS: -------------------------------------

    private void Start()
    {
        StartCoroutine(AparicionBolas());
    }

    IEnumerator AparicionBolas()
    {
        while(true)
        {
            posicionAleatoria = new Vector3(Random.Range (-7.41f, 6.07f), Random.Range(1.24f, 5f), Random.Range(-8.21f, 7.57f));
            Instantiate(prefabBola, posicionAleatoria, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    
}
