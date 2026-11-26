using System;
using UnityEngine;

namespace ItemsOrbeDeseos
{
	public class ItemsOrbe : ScriptableObject
	{
		#region Atributos Públicos:
		[field: SerializeField] public string Nombre { get; set; }
		[field: SerializeField] public string Descripcion { get; set; }
		[field: SerializeField] public Sprite Icono { get; set; }
		[field: SerializeField] public string Dificultad { get; set; }
		
		#endregion
	}
}
