using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlEventos : MonoBehaviour
{
	#region Atributos Privados:
	[SerializeField] private Energia _energiaJugador;
	[SerializeField] private Puntos _puntos;
	[SerializeField] private UIControles _ui;
	[SerializeField] private SonidoControles _sonido;
	[SerializeField] private InputSystem _inputSystem;
	
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
        SuscripcionesAEventos();
    }
    #endregion

    #region Métodos Privados:

        #region Suscripciones a Eventos:
        private void SuscripcionesAEventos()
        {
            _energiaJugador.AlAumentarEnergia += AlAumentarEnergia;
            _energiaJugador.AlReducirEnergia += AlReducirEnergia;
            _energiaJugador.AlMorir += AlMorir;
            _puntos.AlGanarPuntos += AlGanarPuntos;
            _inputSystem.AlGanarVidaEnter += AlGanarVidaEnter;
            _inputSystem.AlPerderVidaSpace += AlPerderVidaSpace;
            _inputSystem.AlGanarPuntosLetraM += AlGanarPuntosLetraM;
            _puntos.AlSubirDeNivel += AlSubirDeNivel;
        }
        #endregion

        #region Métodos Energía:
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

        #region Métodos Inputs:
        private void AlGanarVidaEnter()
        {
            _energiaJugador.AumentoEnergia(10);

        }
        private void AlPerderVidaSpace()
        {
            _energiaJugador.Reduccionenergia(20);
        }
        private void AlGanarPuntosLetraM()
        {
            _puntos.GanarPuntos(30);
        }
        #endregion

        #region Métodos Puntos:
        private void AlGanarPuntos()
        {
            _ui.ActualizacionPuntos(_puntos.PuntosTotales);
        }
        private void AlSubirDeNivel()
        {
            _ui.ActualizacionNivel(_puntos.NivelActual);
        }
        #endregion

    #endregion
}
