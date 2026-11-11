using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColisionesBalas : MonoBehaviour
{
    #region Atributos Públicos:
    #endregion

    #region Atributos Privados:
    #endregion

    #region Métodos Básicos:


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bola"))
        {
            GameObject bolaColisionada = collision.gameObject;
            PropiedadesBolas propiedadbolaActual = bolaColisionada.GetComponent<PropiedadesBolas>();
            propiedadbolaActual.PropiedadExplosion();
            Destroy(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
    #endregion
}
