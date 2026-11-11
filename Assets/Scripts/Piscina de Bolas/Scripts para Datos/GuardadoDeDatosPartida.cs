using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GuardadoDeDatosPartida : MonoBehaviour
{
    //ATRIBUTOS PÚBLICOS: -----------------------------------
    [Header("Pulsa este boton para guardar tu partida")]
    public bool guardar;

    [HideInInspector]
    public string rutaArchivo;

    public struct DatosPartida
    {
        [System.Serializable]
        public struct DatosBolas
        {
            public Vector3 tamaño;
            public Color32 color;
            public Vector3 posicion;
            public int indicePropiedadElegida;
            public int indicePropiedadAsociada;
        }

        [System.Serializable]
        public struct DatosJugador
        {
            public List<DatosBolas> listaBolasPartida;
            public int vidas;
            public int monedas;

            public void SavePartida(string path)
            {
                string JsonString = JsonUtility.ToJson(this, true);
                File.WriteAllText(path, JsonString);
            }
        }

        
    
    }

    //ATRIBUTOS PRIVADOS: -----------------------------------
    private DatosPartida.DatosJugador registroBolasBucketLista;
    private InstanciarPrefabs bolasPartida;

    


    //MÉTODOS: -------------------------------------

    private void Awake()
    {
        bolasPartida = FindFirstObjectByType<InstanciarPrefabs>();
        registroBolasBucketLista = new DatosPartida.DatosJugador(); //ponemos esto aqui arriba para que la lista siga funcionando.
        registroBolasBucketLista.listaBolasPartida = new List<DatosPartida.DatosBolas>();
        CreacionRuta();
    }

    private void Update()
    {
        if(guardar)
        {
            GuardadoDeBolas();
            DineroYVidas();
            GuardadoDeDatos();
            Debug.Log("Datos guardados.");
            guardar = false;
        }

    }

    void CreacionRuta()
    {
        string carpeta = Application.dataPath + "/Datos Partida";
        Directory.CreateDirectory(carpeta);
        rutaArchivo = carpeta + "/DatosPiscinaBolas.json";
    }


    void GuardadoDeDatos()
    {
        registroBolasBucketLista.SavePartida(rutaArchivo);
    }

    void GuardadoDeBolas()
    {
        registroBolasBucketLista.listaBolasPartida.Clear();
        for (int i = 0; i < bolasPartida.BolasTotales.Count; i++)
        {
            if (bolasPartida.BolasTotales[i] != null)
            { 
                DatosPartida.DatosBolas registro = new DatosPartida.DatosBolas();
                registro.tamaño = bolasPartida.BolasTotales[i].transform.localScale;
                registro.color = bolasPartida.BolasTotales[i].GetComponent<Renderer>().material.color;
                registro.posicion = bolasPartida.BolasTotales[i].transform.position;
                registro.indicePropiedadElegida = bolasPartida.BolasTotales[i].GetComponent<PropiedadesBolas>().indicePropiedadElegida;
                registro.indicePropiedadAsociada = bolasPartida.BolasTotales[i].GetComponent<PropiedadesBolas>().indicePropiedadContraida;
                registroBolasBucketLista.listaBolasPartida.Add(registro);
            }
        }
        Debug.Log("2 Destroy");
    }

    void DineroYVidas()
    {
        registroBolasBucketLista.monedas = VidaYRecompensas.dineroJuego;
        registroBolasBucketLista.vidas = VidaYRecompensas.vidaJuego;
        Debug.Log("3 Destroy");
    }

}

