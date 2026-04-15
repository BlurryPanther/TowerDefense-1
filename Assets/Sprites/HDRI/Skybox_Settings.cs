using UnityEngine;

public class Skybox_Settings : MonoBehaviour
{
    [SerializeField] private float Velocity;
    [SerializeField] private Material skyMaterial;

    private void Start()
    {
        RenderSettings.skybox = skyMaterial;
    }
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Velocity);
    }
}
