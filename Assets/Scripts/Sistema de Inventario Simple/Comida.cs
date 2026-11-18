using System;
using UnityEngine;

[Serializable]
public class Comida : Item
{
    #region Atributos Públicos:
    [field: SerializeField] public int EnergiaAportada { get; set; }
	#endregion

	#region Atributos Privados:

	#endregion

	#region Métodos Básicos:

	#endregion

	#region Métodos Personalizados Públicos:
	public void AumentarEnergía()
	{
		Debug.Log("Has recuperado energía.");
	}
	#endregion
}
