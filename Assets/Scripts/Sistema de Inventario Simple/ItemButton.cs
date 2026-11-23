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

        }
    }

    public event Action AlPulsarBoton;
    #endregion

    #region Atributos Privados:
    private TextMeshProUGUI _textoBoton;
    private Item _objetoActual;
    private Button _boton;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        _boton = GetComponent<Button>();
        _textoBoton = GetComponentInChildren<TextMeshProUGUI>();
        _boton.onClick.AddListener(() => AlPulsarBoton?.Invoke());
    }
    #endregion
}
