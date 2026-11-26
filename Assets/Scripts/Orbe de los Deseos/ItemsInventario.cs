using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace ItemsOrbeDeseos
{
    
    public class ItemsInventario : ItemsOrbe, IVenderItemOrbe, ICombinarItemOrbe
    {
        #region Atributos Públicos:
        [field: SerializeField] public int Precio { get; set; }
        [field: SerializeField] public bool Combinable { get; set; }
        [field: SerializeField] public ItemsInventario ObjetoCombible { get; set; }
        [field: SerializeField] public ItemsInventario ObjetoResultante { get; set; }



        #endregion

        #region Atributos Privados:
        private bool _confirmacionVenta;
        #endregion

        #region Métodos Básicos:

        #endregion

        #region Métodos Públicos:
        public void Vender(int precio, TextMeshProUGUI DescripcionVenta, ItemsOrbe nombreItem)
        {
            if(_confirmacionVenta == false)
            {
                DescripcionVenta.text = ("Puedes vender el objeto \"" + nombreItem.Nombre + "\" por " + precio + " monedas. si te interesa pulsa de nuevo \"Vender\"");
                _confirmacionVenta = true;
            }
            else
            {
                DescripcionVenta.text = ("Vendiste el objeto \"" + nombreItem.Nombre + "\", ¡has ganado " + precio + " monedas!");

            }
        }

        
        public void Combinar()
        {
            if (Combinable)
            {

            }
        }

        #endregion
    }
}

