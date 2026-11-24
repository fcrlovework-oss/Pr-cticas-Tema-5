using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventario
{
    public class InventorySystem : MonoBehaviour
    {
        #region Atributos Públicos:
        [Header("Lista Completa de Objetos")]
        public List<Item> ItemsTotales = new List<Item>();

        

        //Eventos    
        public event Action <ItemButton> AlSeleccionarItem;
        public event Action AccionItemCompletada;
        #endregion

        #region Atributos Privados:
        [Header("Arrays de Objectos")]
        [SerializeField] private Armas[] _armas;
        [SerializeField] private Comida[] _comida;
        [SerializeField] private Otros[] _otros;

        [Header("Item Seleccionado")]
        [SerializeField] private ItemButton ItemActualSeleccionado;
        #endregion

        #region Métodos Personalizados Públicos:
        public void InicializandoItems()
        {
            //Armas
            for (int i = 0; i < _armas.Length; i++)
            {
                ItemsTotales.Add(_armas[i]);
            }

            //Comidas
            for (int i = 0; i < _comida.Length; i++)
            {
                ItemsTotales.Add(_comida[i]);
            }

            //Otros
            for (int i = 0; i < _otros.Length; i++)
            {
                ItemsTotales.Add(_otros[i]);
            }
        }

        public void AñadirItem(ItemButton ItemAAñadir, Transform panelInventario)
        {
            ItemButton nuevoBotonDeItem = Instantiate(ItemAAñadir, panelInventario);
            nuevoBotonDeItem.ObjetoActual = ItemAAñadir.ObjetoActual;
            nuevoBotonDeItem.AlPulsarBoton += () => AlSeleccionarItem?.Invoke(nuevoBotonDeItem);
        }

        public void GuardandoItemSeleccionado(ItemButton item)
        {
            ItemActualSeleccionado = item;
        }

        public void UsandoObjetoActual()
        {
            (ItemActualSeleccionado.ObjetoActual as IUsable).Usar();
            if (ItemActualSeleccionado.ObjetoActual is IConsumible)
            {
                Consumir(ItemActualSeleccionado);
            }
        }

        public void VendiendoObjetoActual()
        {
            (ItemActualSeleccionado.ObjetoActual as IVendible).Venta();
            Destroy(ItemActualSeleccionado.gameObject);
            AccionItemCompletada?.Invoke();
        }
        #endregion

        #region Métodos Personalizados Privados:
        private void Consumir(ItemButton objetoSeleccionado)
        {
            Destroy(objetoSeleccionado.gameObject);
            objetoSeleccionado = null;
            AccionItemCompletada?.Invoke();
        }
        #endregion
    }
}
