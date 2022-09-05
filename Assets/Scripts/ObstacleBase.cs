using UnityEngine;
using ObstacleTypes;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private ObstacleType obstacleType;

    private Renderer objRenderer;
    private MaterialPropertyBlock propertBlock;

    void Awake()
    {
        propertBlock = new MaterialPropertyBlock();
        objRenderer = GetComponent<Renderer>();

        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                ChangeColor(Color.white);
                break;
            case ObstacleType.Positive:
                ChangeColor(Color.blue);
                break;
            case ObstacleType.Hazardous:
                ChangeColor(Color.red);
                break;
            case ObstacleType.Fixed:
                ChangeColor(Color.grey);
                break;
            default:
                ChangeColor(Color.cyan);
                break;
        }
    }

    protected void ChangeColor(Color newColor)
    {
        // Get the current value of the material properties in the renderer.
        objRenderer.GetPropertyBlock(propertBlock);
        // Assign the new color.
        propertBlock.SetColor("_Color", newColor);
        // Apply the edited values to the renderer.
        objRenderer.SetPropertyBlock(propertBlock);
    }
}
