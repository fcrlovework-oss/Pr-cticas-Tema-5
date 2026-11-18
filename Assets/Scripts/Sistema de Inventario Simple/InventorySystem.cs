using System.Collections.Generic;
using UnityEngine;


public class InventorySystem : MonoBehaviour
{
	#region Atributos Públicos:

	#endregion

	#region Atributos Privados:
	[Header("Arrays de Objectos")]
	[SerializeField] private Armas[] _armas;
	[SerializeField] private Comida[] _comida;
	[SerializeField] private Otros[] _otros;

    [Header("Piscina de Objetos")]
	[SerializeField] private List<Item> _items = new List<Item> ();
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
        //Armas
        for(int i = 0;  i < _armas.Length; i++)
        {
            _items.Add(_armas[i]);
        }

        //Comidas
        for(int i = 0;  i < _comida.Length; i++)
        {
            _items.Add(_comida[i]);
        }

        //Otros
        for(int i = 0;  i < _otros.Length; i++)
        {
            _items.Add(_otros[i]);
        }
    }
    #endregion

    #region Métodos Personalizados:

    #endregion
}
