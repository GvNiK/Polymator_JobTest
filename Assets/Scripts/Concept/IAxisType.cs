using UnityEngine;
using UnityEngine.Animations;

namespace DefaultNamespace.Concept
{
    public interface IAxisType
    {
        Axis Axis { get; set; }
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
    }
}