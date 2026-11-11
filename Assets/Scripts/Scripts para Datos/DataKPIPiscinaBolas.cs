using UnityEngine;

public enum TipoKPI
{
    BolasTotalesKPI,
    ColisionesTotalesBolasKPI,
    //DineroMaximoGenerado,

    BolasPropiedadBurbujaKPI,
    BolasPropiedadExplosionKPI,
    BolasPropiedadAceleracionKPI,
    BolasPropiedadBotarKPI,
    BolasPropiedadMovimientoExtraKPI,
    BolasPropiedadGameOverKPI,

    //BolasAfectadasBurbujaKPI,
    //BolasAfectadasExplosionKPI,
    //BolasAfectadasAceleracionKPI,
    //BolasAfectadasBotarKPI,
    //BolasAfectadasMovimientoExtraKPI,
    //BolasAfectadasGameOverKPI,

}
public class DataKPIPiscinaBolas : MonoBehaviour
{
    public TipoKPI datoRecogido;
    private DataControllerPiscinaBolas archivoDatos;

    private void Awake()
    {
        archivoDatos = FindFirstObjectByType<DataControllerPiscinaBolas>();
    }

    public void DatoRecibidoBasico()
    {
        if (archivoDatos != null)
        {
            archivoDatos.TomaDeDatosBasicos(datoRecogido);
        }
    }

    public void DatoRecibidoPropiedad(TipoKPI datoEnum)
    {
        if (archivoDatos != null)
        {
            archivoDatos.TomaDeDatosPropiedades(datoEnum);
        }
    }
}
