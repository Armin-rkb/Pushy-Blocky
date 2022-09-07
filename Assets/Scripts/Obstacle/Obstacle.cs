using UnityEngine;
using ObstacleTypes;

public class Obstacle : MonoBehaviour
{
    // Layermask
    public const string positiveLayerMask = "Positive Obstacle";
    public const string hazardousLayerMask = "Hazardous Obstacle";
    public const string neutralLayerMask = "Neutral Obstacle";
    public const string fixedLayerMask = "Fixed Obstacle";

    [SerializeField]
    private ObstacleType obstacleType;

    [SerializeField]
    private Rigidbody rb;

    private Renderer objRenderer;
    private MaterialPropertyBlock propertBlock;

    private void Awake()
    {
        propertBlock = new MaterialPropertyBlock();
        objRenderer = GetComponent<Renderer>();

        SetObstacleType(obstacleType);
    }

    public void SetObstacleType(ObstacleType newObstacleType)
    {
        obstacleType = newObstacleType;
        SetCurrentObstacleTypeColor();
    }

    private void SetCurrentObstacleTypeColor()
    {
        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                ChangeColor(Color.white);
                gameObject.layer = LayerMask.NameToLayer(neutralLayerMask);
                break;
            case ObstacleType.Positive:
                ChangeColor(Color.blue);
                gameObject.layer = LayerMask.NameToLayer(positiveLayerMask);
                break;
            case ObstacleType.Hazardous:
                ChangeColor(Color.red);
                gameObject.layer = LayerMask.NameToLayer(hazardousLayerMask);
                break;
            case ObstacleType.Fixed:
                ChangeColor(Color.grey);
                gameObject.layer = LayerMask.NameToLayer(fixedLayerMask);
                break;
            default:
                ChangeColor(Color.cyan);
                Debug.LogError("Invalid Object Type");
                break;
        }
    }

    private void ChangeColor(Color newColor)
    {
        // Get the current value of the material properties in the renderer.
        objRenderer.GetPropertyBlock(propertBlock);
        // Assign the new color.
        propertBlock.SetColor("_Color", newColor);
        // Apply the edited values to the renderer.
        objRenderer.SetPropertyBlock(propertBlock);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Player")) return;

        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                Debug.Log("Nothing!");
                break;
            case ObstacleType.Positive:
                Debug.Log("Push!");
                break;
            case ObstacleType.Hazardous:
                Debug.LogError("Player Dead!");
                break;
            case ObstacleType.Fixed:
                Debug.LogWarning("Immovable!");
                break;
            default:
                ChangeColor(Color.cyan);
                break;
        }
    }

    private void SetToPlayerColor()
    {
        SetObstacleType(ObstacleType.Positive);
    }

    private void SwitchType()
    {
        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                SetObstacleType(ObstacleType.Fixed);
                break;
            case ObstacleType.Positive:
                SetObstacleType(ObstacleType.Hazardous);
                break;
            case ObstacleType.Hazardous:
                SetObstacleType(ObstacleType.Positive);
                break;
            case ObstacleType.Fixed:
                SetObstacleType(ObstacleType.Neutral);
                break;
            default:
                break;
        }
    }

    private void OnEnable()
    {
        SwitchPickup.OnObstacleSwitch += SwitchType;
        PositivePickup.OnPositivePickup += SetToPlayerColor;
    }

    private void OnDisable()
    {
        SwitchPickup.OnObstacleSwitch -= SwitchType;
        PositivePickup.OnPositivePickup -= SetToPlayerColor;
    }
}