using UnityEngine;
using UnityEngine.UI;

public class UIControles : MonoBehaviour
{
	#region Atributos Públicos:

	#endregion

	#region Atributos Privados:
	[SerializeField] private Slider _barraDeEnergia;
	#endregion

	#region Métodos Básicos:

	#endregion

	#region Métodos Personalizados Públicos:
	public void ActualizacionBarraDeEnergia(int energia)
	{
        _barraDeEnergia.value = energia;

    }

	#endregion
}
