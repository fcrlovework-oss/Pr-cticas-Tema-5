using System;
using UnityEngine;

namespace Inventario
{
	[Serializable]
	public class Item
	{
		#region Atributos Públicos:
		[field: SerializeField] public string Nombre { get; set; }
		[field: SerializeField] public string Descripcion { get; set; }
		[field: SerializeField] public Sprite Icono { get; set; }
		#endregion		
	}
}
