using Inventario;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    #region Atributos Públicos:
    public Item ObjetoActual
    {
        get
        {
            return _objetoActual;
        }
        set
        {
            _objetoActual = value;
            _textoBoton.text = ObjetoActual.Nombre;
            _iconoItem.sprite = ObjetoActual.Icono;

        }
    }

    public event Action AlPulsarBoton;
    #endregion

    #region Atributos Privados:
    private TextMeshProUGUI _textoBoton;
    private Item _objetoActual;
    private Button _boton;
    private Image _iconoItem;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        _boton = GetComponent<Button>();
        _textoBoton = GetComponentInChildren<TextMeshProUGUI>();
        _iconoItem = transform.Find("Icono Item").GetComponentInChildren<Image>();
        _boton.onClick.AddListener(() => AlPulsarBoton?.Invoke());
    }
    #endregion
}
