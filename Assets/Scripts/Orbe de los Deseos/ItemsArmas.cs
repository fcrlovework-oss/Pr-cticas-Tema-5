using UnityEngine;

namespace ItemsOrbeDeseos
{
    [CreateAssetMenu(fileName = "Nuevo Item", menuName = "La Orbe de los Deseos/Crear Item Inventario/Armas")]
    public class ItemsArmas : ItemsInventario, IUsarItemOrbe
    {
        #region Atributos Públicos:
        [field: SerializeField] public int Energia { get; set; }
        [field: SerializeField] public int Daño { get; set; }
        #endregion

        #region Atributos Privados:

        #endregion

        #region Métodos Básicos:

        #endregion

        #region Métodos Públicos:
        public void Usar()
        {

        }
        #endregion
    }

}
