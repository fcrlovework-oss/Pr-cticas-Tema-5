using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControles : MonoBehaviour
{
	#region Atributos Privados:
	[SerializeField] private Slider _barraDeEnergia;
	[SerializeField] private TextMeshProUGUI _textoPuntos;
	[SerializeField] private TextMeshProUGUI _textoNiveles;
	#endregion

	#region Métodos Personalizados Públicos:
	public void ActualizacionBarraDeEnergia(int energia)
	{
        _barraDeEnergia.value = energia;

    }
	public void ActualizacionPuntos(int puntos)
	{
        _textoPuntos.text = puntos.ToString();
    }
	public void ActualizacionNivel(int nivel)
	{
        _textoNiveles.text = nivel.ToString();
    }
	#endregion
}
