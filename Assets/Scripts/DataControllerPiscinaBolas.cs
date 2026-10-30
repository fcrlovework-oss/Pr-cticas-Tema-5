using System.IO;
using UnityEngine;

public class DataControllerPiscinaBolas : MonoBehaviour
{
    [System.Serializable]
    public struct DataBucket
    {
        public int CountBolasTotalesKPI;
        public int CountColisionesTotalesBolasKPI;
        //public int CountDineroMaximoGenerado;

        public int CountBolasPropiedadBurbujaKPI;
        public int CountBolasPropiedadExplosionKPI;
        public int CountBolasPropiedadAceleracionKPI;
        public int CountBolasPropiedadBotarKPI;
        public int CountBolasPropiedadMovimientoExtraKPI;
        public int CountBolasPropiedadGameOverKPI;

        //public int CountBolasAfectadasBurbujaKPI;
        //public int CountBolasAfectadasExplosionKPI;
        //public int CountBolasAfectadasAceleracionKPI;
        //public int CountBolasAfectadasBotarKPI;
        //public int CountBolasAfectadasMovimientoExtraKPI;
        //public int CountBolasAfectadasGameOverKPI;

        public void Save(string path)
        {
            string JsonString = JsonUtility.ToJson(this,true);
            File.WriteAllText(path, JsonString);
        }
    }

    public DataBucket bucket;

    private void Start()
    {
        bucket.CountBolasTotalesKPI = 0;
    }

    private void OnDestroy()
    {
        bucket.Save(Application.dataPath + "/DatosPiscinaBolas.json");
    }

    public void TomaDeDatosBasicos (TipoKPI tipoDato)
    {
        switch (tipoDato)
        {
            case TipoKPI.BolasTotalesKPI:
                bucket.CountBolasTotalesKPI++;
                break;

            case TipoKPI.ColisionesTotalesBolasKPI:
                bucket.CountColisionesTotalesBolasKPI++;
                break;

            
        }
    }

    public void TomaDeDatosPropiedades(TipoKPI tipoDato)
    {
        switch (tipoDato) 
        {
            case TipoKPI.BolasPropiedadBurbujaKPI:
                bucket.CountBolasPropiedadBurbujaKPI++;
                break;

            case TipoKPI.BolasPropiedadExplosionKPI:
                bucket.CountBolasPropiedadExplosionKPI++;
                break;

            case TipoKPI.BolasPropiedadAceleracionKPI:
                bucket.CountBolasPropiedadAceleracionKPI++;
                break;

            case TipoKPI.BolasPropiedadBotarKPI:
                bucket.CountBolasPropiedadBotarKPI++;
                break;

            case TipoKPI.BolasPropiedadMovimientoExtraKPI:
                bucket.CountBolasPropiedadMovimientoExtraKPI++;
                break;

            case TipoKPI.BolasPropiedadGameOverKPI:
                bucket.CountBolasPropiedadGameOverKPI++;
                break;
        }
    }


}
