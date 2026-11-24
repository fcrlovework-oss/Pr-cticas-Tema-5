using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Inventario;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI _textoDescripcion;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        _botonVender.onClick.AddListener(() => AlpulsarBotonVenta?.Invoke());
        _botonUsar.onClick.AddListener(() => AlpulsarBotonUsar?.Invoke());
    }
    #endregion

    #region Métodos Personalizados Públicos:
    public void InicializandoUI(List<Item> listaDeObjetos)
    {
        for (int i = 0; i < listaDeObjetos.Count; i++)
        {
            ItemButton nuevoBoton = Instantiate(_botonDelItem, _panelDeItemsTotales);
            nuevoBoton.ObjetoActual = listaDeObjetos[i];
            nuevoBoton.AlPulsarBoton += () =>AlPulsarBotonItemInventario?.Invoke(nuevoBoton);
        }
    }

    public void TextoDescripcionItem(string texto)
    {
        _textoDescripcion.text = texto;
    }

    public void ComprobacionBotones()
    {
       
        if (Vendible)
        {
            _botonVender.interactable = true;
        }
        else
        {
            _botonVender.interactable = false;
        }

        if (Usable)
        {
            _botonUsar.interactable = true;
        }
        else
        {
            _botonUsar.interactable = false;
        }
    }

    public void ApagandoBotonesAcciones()
    {
        _botonVender.interactable = false;
        _botonUsar.interactable = false;
    }
    #endregion

    
}
