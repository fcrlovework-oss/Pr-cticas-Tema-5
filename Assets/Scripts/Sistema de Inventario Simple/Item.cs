using System;
using UnityEngine;

[Serializable]
public class Item 
{
	#region Atributos Públicos:
	[field: SerializeField] public string Nombre { get; set; }
    [field: SerializeField] public int PrecioVenta { get; set; }
    [field: SerializeField] public int DificultadObtencion { get; set; } //del 1 al 3?
    [field: SerializeField] public int Descripcion { get; set; }
	#endregion

	#region Atributos Privados:

	#endregion

	#region Métodos Básicos:

	#endregion

	#region Métodos Personalizados:

	#endregion
}
