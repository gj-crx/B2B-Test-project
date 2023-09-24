using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public interface IMovementControlsInput
    {
        Vector3 MovementDirection { get; }
    }
}
