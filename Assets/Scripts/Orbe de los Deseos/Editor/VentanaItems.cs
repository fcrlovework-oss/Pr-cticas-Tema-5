using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer;
using ItemsOrbeDeseos;
using System;
using UnityEditor;
using UnityEngine;

public class VentanaItems : EditorWindow
{
    #region Propiedades:
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public Sprite Icono { get; set; }
    public string Dificultad 
    {
        get
        {
            return _dificultadFinal;
        }
        set
        {
            _dificultadFinal = value;
            _dificultadFinal = _dificultades[_dificultad];
        }
        
    }
    #endregion

    #region Campos:
    private string _dificultadFinal;
    private int _dificultad;
    private string[] _dificultades = { "Baja", "Media", "Alta" };
    private int TipoItemSeleciconado;
    private string[] _tiposDeItem = { "Luces", "Comida", "Arma", "Contenedor", "Otros" };
    #endregion

    #region Métodos Personalizados Públicos:
    [MenuItem("Window/ Items Orbe Deseos")]
    public static void MostrarVentana()
    {
        GetWindow<VentanaItems>("Creacion Item Orbe Deseos");
    }
    #endregion

    #region Métodos Personalizados Públicos:
    private void OnGUI()
    {
        //Titulo y tipo de Item:

        GUILayout.Label ("Vamos a crear un Item...", EditorStyles.boldLabel);
        TipoItemSeleciconado = EditorGUILayout.Popup("Tipo de Item", TipoItemSeleciconado, _tiposDeItem);

        //Definimos detalles del Item

        Nombre = EditorGUILayout.TextField("Nombre", Nombre);
        Descripcion = EditorGUILayout.TextField("Descripcion", Descripcion);
        Icono = (Sprite)EditorGUILayout.ObjectField("Icono", Icono, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        _dificultad = EditorGUILayout.Popup("Difucultad", _dificultad, _dificultades);

        EditorGUILayout.Space();
        if(TipoItemSeleciconado == 0) //Luces
        {
            ItemLuces nuevoItemLuces = ScriptableObject.CreateInstance<ItemLuces>();
            nuevoItemLuces.Nombre = Nombre;
            nuevoItemLuces.Descripcion = Descripcion;
            nuevoItemLuces.Icono = Icono;
            nuevoItemLuces.Dificultad = Dificultad;

            nuevoItemLuces.PrecioDeCompra = EditorGUILayout.IntField("Precio de Compra", nuevoItemLuces.PrecioDeCompra);
            nuevoItemLuces.IconoMezcla = (Sprite)EditorGUILayout.ObjectField("Icono", nuevoItemLuces.IconoMezcla, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        }

        if (TipoItemSeleciconado == 1) //Comida
        {
            ItemsComida nuevoItemComida = ScriptableObject.CreateInstance<ItemsComida>();
            nuevoItemComida.Nombre = Nombre;
            nuevoItemComida.Descripcion = Descripcion;
            nuevoItemComida.Icono = Icono;
            nuevoItemComida.Dificultad = Dificultad;

            nuevoItemComida.Energia = EditorGUILayout.IntField("Energía", nuevoItemComida.Energia);
            nuevoItemComida.Precio = EditorGUILayout.IntField("Precio de Venta", nuevoItemComida.Precio);
            nuevoItemComida.Combinable = EditorGUILayout.Toggle("Combinable", nuevoItemComida.Combinable);

            if(nuevoItemComida.Combinable == true)
            {
                nuevoItemComida.ObjetoCombible = (ItemsInventario)EditorGUILayout.ObjectField("Objeto Combinable",nuevoItemComida.ObjetoCombible, typeof(ItemsInventario), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                nuevoItemComida.ObjetoResultante = (ItemsInventario)EditorGUILayout.ObjectField("Objeto Resultante",nuevoItemComida.ObjetoResultante, typeof(ItemsInventario), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
            }
        }


    }
    #endregion
}
