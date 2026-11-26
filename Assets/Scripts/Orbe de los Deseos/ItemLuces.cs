using TMPro;
using UnityEngine;

namespace ItemsOrbeDeseos
{
    [CreateAssetMenu(fileName = "Nuevo Item", menuName = "La Orbe de los Deseos/Crear Luces Ingrediente")]
    public class ItemLuces : ItemsOrbe, IComprar
    {
        #region Atributos Públicos:
        [field: SerializeField] public int PrecioDeCompra { get; set; }
        [field: SerializeField] public Sprite IconoMezcla { get; set; }
        #endregion

        #region Métodos Públicos:
        public void Comprar()
        {
        
        }

        #endregion
    }

}
