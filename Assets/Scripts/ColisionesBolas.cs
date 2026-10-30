using UnityEngine;

public class ColisionesBolas : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    //Atributos para registro de datos:
    public DataKPIPiscinaBolas registroColision;

    //Atributos para colisiones bolas:
    private PropiedadesBolas datosBolaActual;
    private PropiedadesBolas datosBolaChocada;
    private InstanciarPrefabs datosBolaDestruida;

    private int indicePropiedad;

    [HideInInspector]
    public bool detectoSuelo;


    //int conteoColisiones;


    //MÉTODOS BÁSICOS: -------------------------------------

    private void Awake()
    {
        datosBolaActual = GetComponent<PropiedadesBolas>();
    }

    private void Start()
    {
        indicePropiedad = datosBolaActual.indicePropiedadElegida;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bola")
        {
            //if(gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            //{
            //    conteoColisiones++;
            //    Debug.Log("Hubo :" + conteoColisiones + " colisiones.");
            //    if (registroColision != null) registroColision.DatoRecibidoBasico();
            //}

            datosBolaChocada = collision.gameObject.GetComponent<PropiedadesBolas>();
            EfectoPropiedades();
            //datosBolaChocada.indicePropiedadContraida = indicePropiedad;

        }

        if (collision.gameObject.tag == "suelo")
        {
            detectoSuelo = true;
        }
    }

    void EfectoPropiedades()
    {
        if (indicePropiedad == 0)
        {
            datosBolaChocada.PropiedadBurbuja();
            datosBolaChocada.indicePropiedadContraida = 0;
        }
        if (indicePropiedad == 1) datosBolaChocada.PropiedadExplosion();
        if (indicePropiedad == 3) datosBolaChocada.indicePropiedadContraida = 3;
        if (indicePropiedad == 4) datosBolaChocada.indicePropiedadContraida = 4;
    }
        
}
