using UnityEngine;

public class SonidoControles : MonoBehaviour
{
    #region Atributos Públicos:

    #endregion

    #region Atributos Privados:
    [SerializeField] private AudioClip _sonidoReduccionEnergia;
    [SerializeField] private AudioClip _sonidoAumentoEnergia;
    [SerializeField] private AudioClip _sonidoMuerte;
    private AudioSource _reproductorDeSonido;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        _reproductorDeSonido = GetComponent<AudioSource>();
    }
    #endregion

    #region Métodos Personalizados Públicos:
    public void SonidoReduccionEnergia()
    {
        _reproductorDeSonido.clip = _sonidoReduccionEnergia;
        _reproductorDeSonido.Play();
    }
    public void SonidoAumentoEnergia()
    {
        _reproductorDeSonido.clip = _sonidoAumentoEnergia;
        _reproductorDeSonido.Play();
    }

    public void SonidoMuerte()
    {
        _reproductorDeSonido.clip = _sonidoMuerte;
        _reproductorDeSonido.Play();
    }

    #endregion

    #region Métodos Personalizados Privados:

    #endregion
}
