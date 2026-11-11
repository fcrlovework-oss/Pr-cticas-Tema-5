using UnityEngine;

public class MovimientoCañon : MonoBehaviour
{
    #region Atributos Públicos
    public GameObject cañon;
    #endregion

    #region Atributos Privados
    private InputSystem_Actions movimientoCañon;
    private float rotacionVerticalCañon;
    private float rotacionHorizontalCañon;
    private Vector3 rotacionOriginal;
    #endregion

    #region Métodos Básicos:
    private void Awake()
    {
        movimientoCañon = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        movimientoCañon.Enable();
    }

    private void OnDisable()
    {
        movimientoCañon.Disable();
    }
    private void Start()
    {
        rotacionOriginal = cañon.transform.localEulerAngles;
        rotacionVerticalCañon = rotacionOriginal.z;
        rotacionHorizontalCañon = rotacionOriginal.y;
    }

    private void Update()
    {
        RotacionCañon();
    }
    #endregion

    #region Métodos Personalizados :
    private void RotacionCañon()
    {
        //Esto rota el cañón con las teclas de movimiento asignadas en el Move.
        Vector2 movimiento = movimientoCañon.Player.Move.ReadValue<Vector2>();
        rotacionVerticalCañon += -movimiento.y;
        rotacionHorizontalCañon += movimiento.x;

        rotacionVerticalCañon = Mathf.Clamp(rotacionVerticalCañon, 25f, 126f); //la z.
        rotacionHorizontalCañon = Mathf.Clamp(rotacionHorizontalCañon, -52f, 60f); // la y.

        cañon.transform.localEulerAngles = new Vector3(rotacionOriginal.x, rotacionHorizontalCañon, rotacionVerticalCañon);

    }
    #endregion
}
