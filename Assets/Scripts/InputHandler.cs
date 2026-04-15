using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask placementMask;
    private Vector2 mouseScreenPosition;

    [Header("Towers")]
    [SerializeField] private InputActionReference TowerA_Action;
    [SerializeField] private InputActionReference TowerB_Action;
    [SerializeField] private InputActionReference TowerC_Action;

    public event Action <int> OnTowerSelected;

    private void OnEnable()
    {
        TowerA_Action.action.performed += ctx => OnTowerSelected?.Invoke(0);
        TowerA_Action.action.performed += ctx => OnTowerSelected?.Invoke(1);
        TowerA_Action.action.performed += ctx => OnTowerSelected?.Invoke(2);

        TowerA_Action.action.Enable();
        TowerB_Action.action.Enable();
        TowerC_Action.action.Enable();
    }

    private void OnDisable()
    {
        TowerA_Action.action.performed -= ctx => OnTowerSelected?.Invoke(0);
        TowerA_Action.action.performed -= ctx => OnTowerSelected?.Invoke(1);
        TowerA_Action.action.performed -= ctx => OnTowerSelected?.Invoke(2);

        TowerA_Action.action.Disable();
        TowerB_Action.action.Disable();
        TowerC_Action.action.Disable();
    }

    public Vector2 GetSelectedMapPosition()
    {
        mouseScreenPosition = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = sceneCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, sceneCamera.nearClipPlane));
        return mouseWorldPos;
    }
}
