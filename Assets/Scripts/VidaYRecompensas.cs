using UnityEngine;
using UnityEngine.Rendering;

public class VidaYRecompensas : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    //Atributos publicos:
    [HideInInspector]
    static public int vidaJuego = 5;


    //Atributos privados:
    int dineroJuego;
    PropiedadesBolas lecturaBolas;

    //MÉTODOS BÁSICOS: -------------------------------------

    private void Start()
    {
        Debug.Log("Consigue 100 monedas para ganar el juego");
    }

    private void Update()
    {
        if (vidaJuego <= 0) Moriste();
        if (dineroJuego < 0) dineroJuego = 0;
        if (dineroJuego >= 100) Ganaste();
        DeteccionBola();
    }



    //MÉTODOS AVANZADOS: -------------------------------------

    void DeteccionBola()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("bola"))
                {
                    lecturaBolas = hit.collider.gameObject.GetComponent<PropiedadesBolas>();
                    Recompensas();
                }
            }
        }
    }

    void Recompensas()
    {
        if(lecturaBolas.indicePropiedadElegida == 0) //burbuja
        {
            dineroJuego += 10;
            Debug.Log("¡Has ganado 10 monedas!");
        }

        if (lecturaBolas.indicePropiedadElegida == 1) //Explosion
        {
            dineroJuego -= 5;
            Debug.Log("Perdiste 5 monedas...");
        }

        if (lecturaBolas.indicePropiedadElegida == 2) //Aceleracion
        {
            dineroJuego -= 15;
            Debug.Log("Perdiste 15 monedas...");
        }

        if (lecturaBolas.indicePropiedadElegida == 3) //Botar
        {
            dineroJuego += 10;
            Debug.Log("¡Has ganado 10 monedas!");
        }

        if (lecturaBolas.indicePropiedadElegida == 4) //movimientoExtra
        {
            dineroJuego += 10;
            Debug.Log("¡Has ganado 10 monedas!");
        }

        if (lecturaBolas.indicePropiedadElegida == 5) //GameOver
        {
            dineroJuego -= 20;
            Debug.Log("Perdiste 20 monedas...");
        }

        lecturaBolas.PropiedadExplosion();
        Debug.Log("Tienes " + dineroJuego + " monedas.");
    }

    void Moriste()
    {
        PropiedadesBolas[] bolasTotalesPiscina = FindObjectsByType<PropiedadesBolas>(FindObjectsSortMode.None);

        for(int i = 0; i <  bolasTotalesPiscina.Length; i++)
        {
            bolasTotalesPiscina[i].PropiedadExplosion();
        }
        dineroJuego = 0;
        Debug.Log("Perdiste");
        vidaJuego = 5;

    }

    void Ganaste()
    {
        Debug.Log("¡Felicidades!, ¡Lo has conseguido!");
        Debug.Log("Subiste de nivel...");
        Time.timeScale = 0f;
    }

}
