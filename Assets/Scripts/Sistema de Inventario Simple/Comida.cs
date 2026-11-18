using System;
using UnityEngine;

[Serializable]
public class Comida : Item, IUsable, IVendible
{
    #region Atributos Públicos:
    [field: SerializeField] public int EnergiaAportada { get; set; }
    [field: SerializeField] public int PrecioVenta { get; set; }
    
    #endregion

    #region Atributos Privados:

    #endregion

    #region Métodos Básicos:

    #endregion

    #region Métodos Personalizados Públicos:
    public void AumentarEnergía(int energia)
	{
		Debug.Log("Has recuperado energía.");
	}

	public void Usar()
	{
		AumentarEnergía(EnergiaAportada);

    }

    public float Venta()
	{
        Debug.Log("¡Ganaste " + PrecioVenta + " monedas");
        return PrecioVenta;
    }
    #endregion
}
