using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

class PlayerControle_Behaviour : ComponentSystem{

    struct components{

        public Transform pos;
        public PlayerControle_Data player; 

    }



    protected override void OnUpdate()
    {
        float vert = Input.GetAxisRaw("Vertical");
        
        foreach(var p in GetEntities<components>()){

            p.pos.position += (Vector3.forward * p.player.speed * vert * Time.deltaTime);  


        } 

    }


}