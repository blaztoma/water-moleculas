using WebXR;
using Zinnia.Action;
using Unity;

public class WebFloatX : FloatAction
{

    public WebXRController controller;
    private float xAxis;

    // Update is called once per frame
    void Update()
    {
        var vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick).normalized;
        xAxis = vector2.x;
        Receive(xAxis);
    }
}