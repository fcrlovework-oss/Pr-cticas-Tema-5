using System;
using UnityEngine;

public class PropiedadesBolas : MonoBehaviour
{
    /*Cada prefab tiene una propiedad diferente, es decir, al tocar una bola la hacen desaparecer o la echan volando por los aires.
    o hacen que empiece a botar, o le dan un movimiento ocn una velocidad... esa propiedad se recibe de forma aleatoria y tiene un color propio.*/
    //ATRIBUTOS: --------------------------------------------------

    //Atributos privados Propiedades:
    private Action[] propiedades = new Action[6];
    private Renderer colorVariable;
    private InstanciarPrefabs instanciacionBolas;
    private ColisionesBolas deteccionColisiones;
    private Rigidbody rbBola;

    //Atributos publicos Propiedades:
    [HideInInspector]
    public int indicePropiedadElegida;
    [HideInInspector]
    public bool finAceleracion;
    [HideInInspector]
    public int? indicePropiedadContraida = null;
    public GameObject explosionBurbujas;
    public GameObject explosionGameOvers;
    public GameObject explosionExplosion;
    public GameObject explosionAceleracion;
    public GameObject explosionBotar;
    public GameObject explosionMovimientoExtra;
    public Action propiedadAsociada;

    //Atributos para registro de datos:
    private DataKPIPiscinaBolas KPIPropiedadesBolas;
   

    //MÉTODOS BÁSICOS: -------------------------------------
    private void Awake()
    {
        rbBola = GetComponent<Rigidbody>();
        instanciacionBolas = GameObject.Find("InputController").GetComponent<InstanciarPrefabs>();
        KPIPropiedadesBolas = GetComponent <DataKPIPiscinaBolas>();
        deteccionColisiones = GetComponent <ColisionesBolas>();
        colorVariable = GetComponent<Renderer>();
        AsignacionDePropiedades();
    }
    private void Start()
    {
        TamañoYColor();
    }

    private void Update()
    {
        AfeccionPropiedades();
        if(propiedadAsociada == AceleracionCreacionBolas) AceleracionCreacionBolas();
        if(propiedadAsociada == GameOver) GameOver();
    }

    //MÉTODOS AVANZADOS: -------------------------------------

    void TamañoYColor()
    {
        float tamañoBola = UnityEngine.Random.Range(1f, 3f);
        transform.localScale = new Vector3(tamañoBola, tamañoBola, tamañoBola);
        colorVariable.material.color = new Color32((byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), 255);
    }
     
    public void AsignacionDePropiedades()
    {
        propiedades[0] = PropiedadBurbuja;
        propiedades[1] = PropiedadExplosion;
        propiedades[2] = AceleracionCreacionBolas;
        propiedades[3] = Botar;
        propiedades[4] = MovimientoExtra;
        propiedades[5] = GameOver;

        indicePropiedadElegida = UnityEngine.Random.Range(0, propiedades.Length);
        propiedadAsociada = propiedades[indicePropiedadElegida];
        if (KPIPropiedadesBolas != null) DataRegistroPropiedades();

    }

    void AfeccionPropiedades()
    {
        if (indicePropiedadContraida == 1) PropiedadExplosion();
        if (indicePropiedadContraida == 2) AceleracionCreacionBolas();
        if (indicePropiedadContraida == 3) Botar();
        if (indicePropiedadContraida == 4) MovimientoExtra();
        if (indicePropiedadContraida == 5) GameOver();
    }

    void DataRegistroPropiedades() //KPIPropiedadesBolas.DatoRecibido(TipoKPI.BolasPropiedadBurbujaKPI);
    {
        if (indicePropiedadElegida == 0) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadBurbujaKPI);
        if (indicePropiedadElegida == 1) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadExplosionKPI);
        if (indicePropiedadElegida == 2) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadAceleracionKPI);
        if (indicePropiedadElegida == 3) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadBotarKPI);
        if (indicePropiedadElegida == 4) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadMovimientoExtraKPI);
        if (indicePropiedadElegida == 5) KPIPropiedadesBolas.DatoRecibidoPropiedad(TipoKPI.BolasPropiedadGameOverKPI);

    }

    //MÉTODOS AVANZADOS PROPIEDADES BOLAS: --------------------------------------------

    //toda bola que toque levitará:
    public void PropiedadBurbuja()
    {
        rbBola.useGravity = false;
        rbBola.linearDamping = 1f;
        rbBola.AddForce(Vector3.up * 15f,ForceMode.Impulse);
    }

    //Hace explotar las bolas que toca
    public void PropiedadExplosion()
    {
        if(indicePropiedadElegida == 0) Instantiate(explosionBurbujas, transform.position, Quaternion.identity);
        if(indicePropiedadElegida == 1) Instantiate(explosionExplosion, transform.position, Quaternion.identity);
        if(indicePropiedadElegida == 2) Instantiate(explosionAceleracion, transform.position, Quaternion.identity);
        if(indicePropiedadElegida == 3) Instantiate(explosionBotar, transform.position, Quaternion.identity);
        if(indicePropiedadElegida == 4) Instantiate(explosionMovimientoExtra, transform.position, Quaternion.identity);
        if(indicePropiedadElegida == 5) Instantiate(explosionGameOvers, transform.position, Quaternion.identity);
        instanciacionBolas.EliminacionBolasListas(this.gameObject);
        Destroy(this.gameObject);

    }

    //acelera el tiempo de creacion de bolas cuando pulsas sobre ella.
    void AceleracionCreacionBolas()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.rigidbody == rbBola)
                {
                    if(instanciacionBolas.AceleracionInstancias != true)
                    { 
                        instanciacionBolas.AceleracionInstancias = true;
                    }
                }
            }
        }
        if (finAceleracion)
        {
            PropiedadExplosion();
            VidaYRecompensas.dineroJuego -= 15;
            Debug.Log("Perdiste 15 monedas...");
        }
            
    }

    //hace botar la bola un tiempo:
    public void Botar()
    {
        if(deteccionColisiones.detectoSuelo == true)
        {
            float impulsoBote = UnityEngine.Random.Range(5f, 10f);
            rbBola.AddForce(Vector3.up * impulsoBote, ForceMode.Impulse);
            deteccionColisiones.detectoSuelo = false;
        }
    }

    //da un movimiento aleatorio constante y velocidad a las bolas que toca:
    void MovimientoExtra()
    {
        Vector3[] Vectores = {Vector3.forward, -Vector3.forward, Vector3.right, -Vector3.right};
        int VectorElegido = UnityEngine.Random.Range(0, Vectores.Length);
        Vector3 VectorAleatorio = Vectores[VectorElegido];
        rbBola.AddForce(VectorAleatorio * 5f, ForceMode.Force);
    }

    //si pulsas esta bola sin querer, pierdes una vida y hará explotar todas las bolas de la piscina, cuando tus vidas lleguen a cero, se acaba el juego.
    void GameOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.rigidbody == rbBola)
                {
                    Debug.Log("Has perdido una vida y 20 monedas, te quedan " + VidaYRecompensas.vidaJuego + " vidas y " + VidaYRecompensas.dineroJuego);
                    VidaYRecompensas.vidaJuego--;
                    VidaYRecompensas.dineroJuego -= 20;
                    PropiedadExplosion();
                }
            }
        }
    }

}
