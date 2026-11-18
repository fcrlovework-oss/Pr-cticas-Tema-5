using UnityEngine;

public interface IVendible
{
    #region Atributos Públicos
    public int PrecioVenta { get; set; }
    #endregion

    #region Métodos Personalizados Públicos:
    public float Venta();

	#endregion
}
