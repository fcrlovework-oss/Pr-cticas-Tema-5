using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Disparo : MonoBehaviour
{
    #region Atributos Públicos:
    public GameObject bala;
    public Transform puntoDeTiro;
    #endregion

    #region Atributos Privados:
    private GameObject BalaCreada;
    #endregion

    #region Métodos Básicos:
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame) ActivacionDisparo();
    }
    #endregion

    #region Métodos Personalizados:  
    private void ActivacionDisparo()
    {
        BalaCreada = Instantiate(bala, puntoDeTiro.position, Quaternion.identity);
        BalaCreada.GetComponent<Rigidbody>().AddForce(puntoDeTiro.right * 70f, ForceMode.Impulse);
        if (BalaCreada != null) Destroy(BalaCreada, 4f);
    }
    #endregion
}
