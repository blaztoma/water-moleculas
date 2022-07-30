using WebXR;
using Zinnia.Action;
using Unity;

public class WebFloatY : FloatAction
{

    public WebXRController controller;
    private float yAxis;

    // Update is called once per frame
    void Update()
    {
        var vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick).normalized;
        yAxis = vector2.y;
        Receive(yAxis);
    }
}