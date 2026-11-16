using UnityEngine;

public class ControlEventos : MonoBehaviour
{
	#region Atributos Públicos:

	#endregion

	#region Atributos Privados:
	[SerializeField] private Energia _energiaJugador;
	[SerializeField] private Monedas _monedas;
	[SerializeField] private UIControles _ui;
	[SerializeField] private SonidoControles _sonido;
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
        //Listener, asi te suscribes al evento:
        _energiaJugador.AlAumentarEnergia += AlAumentarEnergia;
        _energiaJugador.AlReducirEnergia += AlReducirEnergia;
        _energiaJugador.AlMorir += AlMorir;
    }

    #endregion

    #region Métodos Personalizados Públicos:

    #endregion

    #region Métodos Personalizados Privados:
    private void AlAumentarEnergia()
    {
        _sonido.SonidoAumentoEnergia();
        _ui.ActualizacionBarraDeEnergia(_energiaJugador.EnergiaActual);
    }

    private void AlReducirEnergia()
    {
        _sonido.SonidoReduccionEnergia();
        _ui.ActualizacionBarraDeEnergia(_energiaJugador.EnergiaActual);
    }

    private void AlMorir()
    {
        _sonido.SonidoMuerte();
        Debug.Log("Acabas de morir...");
    }
    #endregion
}
