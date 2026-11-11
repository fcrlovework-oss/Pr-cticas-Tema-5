using UnityEngine;

public class VidaYRecompensas : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    //Atributos publicos:
    [HideInInspector]
    static public int vidaJuego = 5;
    [HideInInspector]
    static public int dineroJuego;

    //Atributos privados:
    PropiedadesBolas lecturaBolas;

    //MÉTODOS BÁSICOS: -------------------------------------

    private void Start()
    {
        Debug.Log("Consigue 100 monedas para ganar el juego");
        Debug.Log("Pistas: las bolas que hacen explotar, acelerar las instancias y perder  quitan dinero.");
    }

    private void Update()
    {
        AjusteVidasYMonedas();
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
                    Recompensas(lecturaBolas);
                }
            }
        }
    }

    public void Recompensas(PropiedadesBolas propiedad)
    {
        if(propiedad.indicePropiedadElegida == 0 || propiedad.indicePropiedadElegida == 3 || propiedad.indicePropiedadElegida == 4) //burbuja, Botar, movimientoExtra
        {
            dineroJuego += 10;
            Debug.Log("¡Has ganado 10 monedas!");
            propiedad.PropiedadExplosion();
        }

        if (propiedad.indicePropiedadElegida == 1) //Explosion
        {
            dineroJuego -= 5;
            Debug.Log("Perdiste 5 monedas...");
            propiedad.PropiedadExplosion();
        }
        Debug.Log("Tienes " + dineroJuego + " monedas.");
    }

    public void AjusteVidasYMonedas()
    {
        if (vidaJuego <= 0) Moriste();
        if (dineroJuego < 0) dineroJuego = 0;
        if (dineroJuego >= 100) Ganaste();
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
