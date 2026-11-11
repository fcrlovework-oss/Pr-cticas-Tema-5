using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColisionesBalas : MonoBehaviour
{
    #region Atributos Públicos:
    #endregion

    #region Atributos Privados:
    private VidaYRecompensas sistemaRecompensas;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        sistemaRecompensas = FindFirstObjectByType<VidaYRecompensas>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bola"))
        {
            GameObject bolaColisionada = collision.gameObject;
            PropiedadesBolas propiedadbolaActual = bolaColisionada.GetComponent<PropiedadesBolas>();

           
            //estas dos primeras condiciones son para las bolas con propiedad GameOver y Aceleracion ya que tienen ritmos distintos en sus efectos.
            if (propiedadbolaActual.indicePropiedadElegida == 2) propiedadbolaActual.AceleracionCreacionBolas();
            if (propiedadbolaActual.indicePropiedadElegida == 5) propiedadbolaActual.GameOver();
            else //cualquier bola con otra propiedad explotará aunque antes se dará la recompensa por ella.
            {
                if (sistemaRecompensas != null)
                {
                    sistemaRecompensas.Recompensas(propiedadbolaActual);
                }
                propiedadbolaActual.PropiedadExplosion();
                
            }
            Destroy(this.gameObject);



        }
        else Destroy(this.gameObject);
    }
    #endregion
}
