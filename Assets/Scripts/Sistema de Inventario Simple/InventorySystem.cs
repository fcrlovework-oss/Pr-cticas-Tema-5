using System.Collections.Generic;
using UnityEngine;

namespace Inventario
{
    public class InventorySystem : MonoBehaviour
    {
        #region Atributos Públicos:

        #endregion

        #region Atributos Privados:
        [Header("Referencias de UI")]
        [SerializeField] private ItemButton _botonDelItem;
        [SerializeField] private Transform _panelDeInventario;

        [Header("Arrays de Objectos")]
        [SerializeField] private Armas[] _armas;
        [SerializeField] private Comida[] _comida;
        [SerializeField] private Otros[] _otros;

        [Header("Piscina de Objetos")]
        [SerializeField] private List<Item> _items = new List<Item>();

        [Header("Item Seleccionado")]
        [SerializeField] private Item _itemActualSeleccionado;

        #endregion

        #region Métodos Básicos:
        private void Start()
        {
            InicializandoItems();
            InicializandoUI();
        }


        #endregion

        #region Métodos Personalizados Privados:
        private void InicializandoItems()
        {
            //Armas
            for (int i = 0; i < _armas.Length; i++)
            {
                _items.Add(_armas[i]);
            }

            //Comidas
            for (int i = 0; i < _comida.Length; i++)
            {
                _items.Add(_comida[i]);
            }

            //Otros
            for (int i = 0; i < _otros.Length; i++)
            {
                _items.Add(_otros[i]);
            }
        }
        private void InicializandoUI()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                ItemButton nuevoBoton = Instantiate(_botonDelItem, _botonDelItem.transform.parent);
                nuevoBoton.ObjetoActual = _items[i];
                nuevoBoton.AlPulsarBoton += () => AñadirItem(nuevoBoton);
            }
            _botonDelItem.gameObject.SetActive(false);
        }
        #endregion

        #region Métodos Personalizados Públicos:
        public void AñadirItem(ItemButton botonNuevo)
        {
            ItemButton nuevoItem = Instantiate(botonNuevo, _panelDeInventario);
            nuevoItem.AlPulsarBoton += () => ItemSeleccionado(nuevoItem.ObjetoActual);
        }

        public void ItemSeleccionado(Item objetoActual)
        {
            _itemActualSeleccionado = objetoActual;
            //LogicaControlDeBotones de acciones.
        }
        #endregion
    }
}
