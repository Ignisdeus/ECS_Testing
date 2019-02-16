using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


class RotationSystem : ComponentSystem
{

    struct components
    {

        public Rotation rotation;
        public Transform tranform;


    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<components>())
        {


            e.tranform.Rotate(Vector3.up * e.rotation.speed * Time.deltaTime);

        }
    }


}