using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that must be implemented by any input system (in this game just the AI and player)
public interface IInput
{
    //1D axis for determining the direction of movement and rotation
    float RotateInput {get;}
    float MoveInput {get;}
}
