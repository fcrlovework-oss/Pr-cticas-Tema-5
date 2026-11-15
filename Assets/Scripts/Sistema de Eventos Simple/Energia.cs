using System;
using UnityEngine;

public class Energia : MonoBehaviour
{
	#region Atributos Públicos:
	public int EnergiaActual { 
		get //get muestra lo que se va a leer al llamar a la variable
		{ 
			return _energiaActual;
		} 
		set 
		{
            _energiaActual = value;

            if (value < 0)
			{
                _energiaActual = 0;
				Morir();
			}
			if (value > _energiaMaxima) _energiaActual = _energiaMaxima;

        } 
	}

	public event Action AlAumentarEnergia;
	public event Action AlReducirEnergia;
	public event Action AlMorir;
	#endregion

	#region Atributos Privados:
	[SerializeField] private int _energiaMaxima = 100;
	private int _energiaActual;
	private bool _die = false;
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
		EnergiaActual = _energiaMaxima;

		//Listener, asi te suscribes al evento:
		AlAumentarEnergia += () => Debug.Log("Energia: " + EnergiaActual);
        AlMorir += () => Debug.Log("¡Has muerto!");

		AumentoEnergia(10);
    }
    #endregion

    #region Métodos Personalizados Públicos:
    public void AumentoEnergia(int energia)
	{
		EnergiaActual += energia;

		//Evento Emisor:
		AlAumentarEnergia?.Invoke();
    }

	public void Reduccionenergia(int energia)
	{
        EnergiaActual -= energia;

        //Evento Emisor:
        AlReducirEnergia?.Invoke();
    }
    #endregion

    #region Métodos Personalizados Privados:
	private void Morir()
	{
        if(!_die)
		{
            _die = true;
			//Evento Emisor:
			AlMorir?.Invoke();
        }
    }
    #endregion
}
