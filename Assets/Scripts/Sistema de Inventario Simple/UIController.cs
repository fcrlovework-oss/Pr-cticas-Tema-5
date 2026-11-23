using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Inventario;

public class UIController : MonoBehaviour
{
    #region Atributos Públicos:
    [Header("Paneles:")]
    public Transform _panelDeInventario;
    public Transform _panelDeItemsTotales;
    public event Action AlpulsarBotonVenta;
    public event Action AlpulsarBotonUsar;
    public event Action <ItemButton> AlPulsarBotonItemInventario;

    [HideInInspector]public bool Vendible;
    [HideInInspector]public bool Usable;

    #endregion

    #region Atributos Privados:
    [Header("Botones:")]
    [SerializeField] private ItemButton _botonDelItem;
    [SerializeField] private Button _botonVender;
    [SerializeField] private Button _botonUsar;
    #endregion

    #region Métodos Personalizados Públicos:
    public void InicializandoUI(List<Item> listaDeObjetos)
    {
        Debug.Log("Llegó a aqui 1");
        for (int i = 0; i < listaDeObjetos.Count; i++)
        {
            ItemButton nuevoBoton = Instantiate(_botonDelItem, _panelDeItemsTotales);
            nuevoBoton.ObjetoActual = listaDeObjetos[i];
            nuevoBoton.AlPulsarBoton += () =>AlPulsarBotonItemInventario?.Invoke(nuevoBoton);
        }
    }
    public void ComprobacionBotones()
    {
       
        if (Vendible)
        {
            _botonVender.gameObject.SetActive(true);
            _botonVender.onClick.AddListener(() =>AlpulsarBotonVenta?.Invoke());
        }
        else
        {
            _botonVender.gameObject.SetActive(false);
        }

        if (Usable)
        {
            _botonUsar.gameObject.SetActive(true);
            _botonUsar.onClick.AddListener(() => AlpulsarBotonUsar?.Invoke());
        }
        else
        {
            _botonUsar.gameObject.SetActive(false);
        }
    }
    public void ApagandoBotonesAcciones()
    {
        _botonVender.gameObject.SetActive(false);
        _botonUsar.gameObject.SetActive(false);
    }
    #endregion

    
}
