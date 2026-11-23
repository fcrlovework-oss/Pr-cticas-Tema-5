using Inventario;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Atributos Privados:    
    [SerializeField] private UIController _ui;
    [SerializeField] private InventorySystem _inventario;
    #endregion

    #region Métodos Básicos:
    private void Start()
    {
        _inventario.InicializandoItems();
        _ui.InicializandoUI(_inventario.ItemsTotales);
        SuscripcionesAEventos();
    }
    #endregion

    #region Métodos Personalizados Privados:
    private void SuscripcionesAEventos()
    {
        _ui.AlPulsarBotonItemInventario += AlAñadirItem;
        _inventario.AlSeleccionarItem += (ItemButton) => AlSeleccionarItem(ItemButton);
        _ui.AlpulsarBotonVenta += VendiendoItem;
        _ui.AlpulsarBotonUsar += UsandoItem;
        _inventario.AccionItemCompletada += AlCompletarAccionItems;
    }

    private void AlAñadirItem(ItemButton item)
    {
        _inventario.AñadirItem(item, _ui._panelDeInventario);
        _ui.ApagandoBotonesAcciones();
    }
    private void AlSeleccionarItem(ItemButton objetoActual)
    {
        _inventario.GuardandoItemSeleccionado(objetoActual);
        //si es vendible:
        if (objetoActual.ObjetoActual is IVendible)
        {
            _ui.Vendible = true;
        }
        else
        {
            _ui.Vendible = false;
        }

        //si es usable:
        if (objetoActual.ObjetoActual is IUsable)
        {
            _ui.Usable = true;
        }
        else
        {
            _ui.Usable = false;
        }
        _ui.ComprobacionBotones();
    }
    #endregion

    //Métodos de Acciones:
    private void VendiendoItem()
    {
        _inventario.VendiendoObjetoActual();
    }
    private void UsandoItem()
    {
        _inventario.UsandoObjetoActual();
    }
    private void AlCompletarAccionItems()
    {
        _ui.ApagandoBotonesAcciones();
    }
}
