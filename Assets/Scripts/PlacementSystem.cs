using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private GameObject [] towerPrefabs;
    private int towerIndex = 0;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private InputAction clickAction;

    public InputActionAsset inputActions;
    [SerializeField] private Grid grid;

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Click");
        Instantiate(towerPrefabs[towerIndex], cellIndicator.transform.position, Quaternion.identity);
    }

    private void Awake()
    {
        clickAction = inputActions.FindActionMap("Player").FindAction("Click");
        clickAction.performed += OnClickPerformed;
    }
    private void OnEnable()
    {
        inputHandler.OnTowerSelected += ChangeSelectedTower;
        clickAction.Enable();
    }

    private void OnDisable()
    {
        inputHandler.OnTowerSelected -= ChangeSelectedTower;
        clickAction.Disable();
    }

    private void ChangeSelectedTower(int index)
    {
        towerIndex = index;
    }


    private void Update()
    {
        Vector2 mousePosition = inputHandler.GetSelectedMapPosition();
        Vector3Int gridPos = grid.WorldToCell(new Vector3(mousePosition.x, mousePosition.y, 0));

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.GetCellCenterWorld(gridPos);
    }


}
