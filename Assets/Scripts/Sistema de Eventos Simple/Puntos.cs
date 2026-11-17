using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Puntos : MonoBehaviour
{
    #region Atributos Públicos:
	public int PuntosTotales
	{
		get
		{
			return _puntosTotales;
		}
		set
		{
			_puntosTotales = value;
			if (value < 0) _puntosTotales = 0;

        }
	}
    public int NivelActual
    {
        get { return _nivelActual;}
        set { _nivelActual = value;}    
    }

	public event Action AlGanarPuntos;
	public event Action AlSubirDeNivel;
	#endregion

	#region Atributos Privados:
    [SerializeField] private int _conteoPuntosNivel;
	private int _puntosTotales;
    private int _nivelActual;
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
        PuntosTotales = 0;
    }
    #endregion

    #region Métodos Personalizados Públicos:
    public void GanarPuntos(int puntos)
	{
		if (puntos < 0)
		{
			Debug.LogError("¡Se ha detectado un valor negativo al intentar gastar Monedas!");
            return;
		}

		PuntosTotales += puntos;
        _conteoPuntosNivel += puntos;

        if(_conteoPuntosNivel >= 50)
            ControlAumentoNivel();

        AlGanarPuntos?.Invoke();
    }
    public void ControlAumentoNivel()
    {
        while(_conteoPuntosNivel >= 50)
        {
            _nivelActual++;
            _conteoPuntosNivel -= 50;
        }
        AlSubirDeNivel?.Invoke();
        Debug.Log("¡Has Subido de Nivel!");

    }
    #endregion
}
