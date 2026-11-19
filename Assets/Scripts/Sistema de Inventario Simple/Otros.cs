using System;
using UnityEngine;

namespace Inventario
{
    [Serializable]
    public class Otros : Item, IVendible
    {
        #region Atributos Públicos:
        [field: SerializeField] public int PrecioVenta { get; set; }
        #endregion

        #region Métodos Personalizados Públicos:
        public float Venta()
        {
            Debug.Log("¡Ganaste " + PrecioVenta + " monedas");
            return PrecioVenta;
        }
        #endregion
        //
    }
}
