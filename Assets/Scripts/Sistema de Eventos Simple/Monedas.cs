using System;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    #region Atributos Públicos:
	public int MonedasTotales
	{
		get
		{
			return _monedasTotales;
		}
		set
		{
			_monedasTotales = value;
			if (value < 0) _monedasTotales = 0;

        }
	}

	public event Action AlGanarMonedas;
	public event Action AlGastarMonedas;
	#endregion

	#region Atributos Privados:
	private int _monedasTotales;

	#endregion

	#region Métodos Básicos:

	#endregion

	#region Métodos Personalizados Públicos:
	public void GanarMonedas(int monedas)
	{
		if (monedas < 0)
		{
			Debug.LogError("¡Se ha detectado un valor negativo o nulo  al intentar gastar Monedas!");
            return;
		}

		MonedasTotales += monedas;

		AlGanarMonedas?.Invoke();
    }

    public void GastarMonedas(int monedas)
    {
        if (monedas <= 0)
        {
            Debug.LogError("¡Se ha detectado un valor negativo o nulo  al intentar gastar Monedas!");
            return;
        }
        MonedasTotales -= monedas;

		AlGastarMonedas?.Invoke();
    }

    #endregion

    #region Métodos Personalizados Privados:

    #endregion
}
