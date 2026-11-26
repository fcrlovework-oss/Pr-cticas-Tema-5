
using TMPro;

namespace ItemsOrbeDeseos
{
    public interface IUsarItemOrbe
    {
        #region Métodos Públicos
        public void Usar();
        #endregion
    }
    public interface IVenderItemOrbe
    {
        #region Métodos Públicos
        public void Vender(int precio, TextMeshProUGUI DescripcionVenta, ItemsOrbe nombreItem);
        #endregion
    }
    public interface ICombinarItemOrbe
    {
        #region Métodos Públicos
        public void Combinar();
        #endregion
    }
    public interface IComprar
    {
        #region Métodos Públicos
        public void Comprar();
        #endregion
    }
}

