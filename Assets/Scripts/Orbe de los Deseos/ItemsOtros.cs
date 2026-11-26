using ItemsOrbeDeseos;
using UnityEngine;

public class ItemsOtros : ItemsInventario, IUsarItemOrbe
{
    #region Atributos Públicos:
    [field: SerializeField] public bool Usable { get; set; }
    #endregion

    #region Atributos Privados:

    #endregion

    #region Métodos Básicos:

    #endregion

    #region Métodos Públicos:
    public void Usar()
    {
        if(Usable)
        {

        }
    }
    #endregion
}
