using System;
using UnityEngine;

public class PropiedadesBolas : MonoBehaviour
{
    /*Cada prefab tiene una propiedad diferente, es decir, al tocar una bola la hacen desaparecer o la echan volando por los aires.
    o hacen que empiece a botar, o le dan un movimiento ocn una velocidad... esa propiedad se recibe de forma aleatoria y tiene un color propio.*/
    //ATRIBUTOS: -----------------------------------

    //Atributos propiedades bolas:
    private Action[] propiedades = new Action[5];
    private Renderer colorVariable;

    //MÉTODOS: -------------------------------------
    private void Awake()
    {
        colorVariable = GetComponent<Renderer>();
        AsignacionDePropiedades();
    }
    private void Start()
    {
        Tamaño();
        ColorBola();
    }

    void Tamaño()
    {
        float tamañoBola = UnityEngine.Random.Range(1f, 3f);
        transform.localScale = new Vector3(tamañoBola, tamañoBola, tamañoBola);
    }

    void ColorBola()
    {
        colorVariable.material.color = new Color32((byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), 255);
    }

    void AsignacionDePropiedades()
    {
        propiedades[0] = PropiedadBurbuja;
        propiedades[1] = PropiedadExplosion;
        propiedades[2] = AceleracionCreacionBolas;
        propiedades[3] = Botar;
        propiedades[4] = MovimientoExtra;
        propiedades[5] = GameOver;
    }

    //MÉTODOS PROPIEDADES BOLAS: --------------------------------------------

    //toda bola que toque levitará:
    void PropiedadBurbuja()
    {

    }

    //Hace explotar las bolas que toca
    void PropiedadExplosion()
    {

    }

    //acelera el tiempo de creacion de bolas cuando pulsas sobre ella.
    void AceleracionCreacionBolas()
    {

    }

    //hace botar la bola un tiempo:
    void Botar()
    {

    }

    //da un movimiento aleatorio constante y velocidad a las bolas que toca:
    void MovimientoExtra()
    {

    }

    //si pulsas esta bola sin querer, pierdes una vida y hará explotar todas las bolas de la piscina, cuando tus vidas lleguen a cero, se acaba el juego.
    void GameOver()
    {

    }

    //hare que si un bola con x propiedad toca a otra con x propiedad o y propiedad, ganas x o y dinero. quiero poder registrar el dinero maximo ganado en cada partida.
    void Recompensas() //quiero pensar en si debo hacer este metodo en un script diferente.
    {

    }

}
