using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//base class that can be extended by other components to get a reference to the controller
public class ControllerElement : MonoBehaviour
{
    public Controller controller { get { return GetComponent<Controller>(); }}
}

//Top level container and caller for all behavior implementations for the game.
public class Controller : MonoBehaviour
{
    //type of input we will be using, AI or player
    //changeable via code, unity inspector doesn't allow assignment by interface
    public IInput input;
    //all current behavior scripts
    public MoveBehavior move;
    public RotateBehavior rotate;
    //tuneable parameters for behaviors
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    //other necessary references 
    public Rigidbody2D rb;
    Vector3 originalPosition;
    Quaternion originalRotation;
    bool modsEnabled = false;

    void Start()
    {
        //default to player input
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
    }
    private void OnEnable() {
        GameManager.ResetState += Reset;
        MainMenu.ToggleClicked += EnableMods;
    }

    private void OnDisable() {
        GameManager.ResetState -= Reset;
        MainMenu.ToggleClicked -= EnableMods;
    }

    private void FixedUpdate() {
        move.Move(input.MoveInput);
        if(modsEnabled)
        {
            rotate.Rotate(input.RotateInput);
        }
    }

    void EnableMods(bool state)
    {
        modsEnabled = state;
    }

    private void Reset() 
    {
        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;
    }
}