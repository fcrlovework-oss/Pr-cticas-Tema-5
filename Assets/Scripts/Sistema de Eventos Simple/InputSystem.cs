using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
	//¿Quizas estas variables deberian tene rotro tipo de nombres?
    #region Atributos Públicos:
	public event Action AlGanarVidaEnter;
	public event Action AlPerderVidaSpace;
	public event Action AlGanarPuntosLetraM;
    #endregion
   
    #region Métodos Básicos:
    private void Update()
    {
        DeteccionInputsTeclado();
    }
    #endregion
        
    #region Métodos Personalizados Privados:
    private void DeteccionInputsTeclado()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
                AlGanarVidaEnter?.Invoke();

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                AlPerderVidaSpace?.Invoke();

            if (Keyboard.current.mKey.wasPressedThisFrame)
                AlGanarPuntosLetraM?.Invoke();
        }
    }
    #endregion
}
