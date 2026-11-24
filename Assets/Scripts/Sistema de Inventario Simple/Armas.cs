using System;
using UnityEngine;

namespace Inventario
{
    [Serializable]
    public class Armas : Item, IUsable
    {
        #region Atributos Públicos:
        [field: SerializeField] public int Daño { get; set; }
        #endregion

        #region Métodos Personalizados Públicos:
        public void Ataque(int dañoEnergia)
        {

        }

        public void Usar()
        {
            Ataque(Daño);
            Debug.Log("Has sufrido " + Daño + " puntos de daño...");
        }

        #endregion //Puedes lanzarla con un arco.
    }
}
