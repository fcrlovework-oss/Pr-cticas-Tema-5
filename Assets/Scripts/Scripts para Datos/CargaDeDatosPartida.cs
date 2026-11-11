using System.IO;
using UnityEngine;

public class CargaDeDatosPartida : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    [Header("Pulsalo si deseas cargar la ultima partida")]
    public bool cargarPartidaGuardada;

    private GuardadoDeDatosPartida accesoRutaArchivo;
    private GuardadoDeDatosPartida.DatosPartida.DatosJugador datosGuardadosCarga;
    private InstanciarPrefabs bolasInstancias;
    private PropiedadesBolas propiedadesRecargadas;

    //MÉTODOS BÁSICOS: -------------------------------------

    private void Awake()
    {
        accesoRutaArchivo = GetComponent<GuardadoDeDatosPartida>();
        bolasInstancias = GetComponent<InstanciarPrefabs>();
    }

    private void Update()
    {
        if(cargarPartidaGuardada)
        {
            LimpiandoListasActuales();
            CargarDeDatos();
            cargarPartidaGuardada = false;
        }
    }

    void CargarDeDatos()
    {
        if (File.Exists(accesoRutaArchivo.rutaArchivo))
        {
            string json = File.ReadAllText(accesoRutaArchivo.rutaArchivo);
            datosGuardadosCarga = JsonUtility.FromJson<GuardadoDeDatosPartida.DatosPartida.DatosJugador>(json);

            foreach (GuardadoDeDatosPartida.DatosPartida.DatosBolas dato in datosGuardadosCarga.listaBolasPartida)
            {
                CreateObject(dato);
            }

        }
        else Debug.LogWarning("No se encontro el archivo");
    }

    private void CreateObject(GuardadoDeDatosPartida.DatosPartida.DatosBolas dato)
    {
        GameObject bola = Instantiate(bolasInstancias.prefabBola, dato.posicion, Quaternion.identity);

        propiedadesRecargadas = bola.GetComponent<PropiedadesBolas>();

        bola.transform.localScale = dato.tamaño;
        propiedadesRecargadas.colorVariable.material.color = dato.color;
        propiedadesRecargadas.indicePropiedadElegida = dato.indicePropiedadElegida;
        propiedadesRecargadas.indicePropiedadContraida = dato.indicePropiedadAsociada;
        if (dato.indicePropiedadAsociada == 0)
        {
            propiedadesRecargadas.rbBola.useGravity = false;
            propiedadesRecargadas.rbBola.linearDamping = 1f;
        }
        bolasInstancias.AsociandoAListas(bola);
    }

    void LimpiandoListasActuales()
    {
        for(int i = 0; i < bolasInstancias.listasTotales.Length; i++)
        {
            for (int j = 0; j < bolasInstancias.listasTotales[i].Count; j++)
            {
                GameObject bolaActualEliminar = bolasInstancias.listasTotales[i][j];
                if(bolaActualEliminar != null) Destroy(bolaActualEliminar);

            }
            bolasInstancias.listasTotales[i].Clear();
        }
    }
}
