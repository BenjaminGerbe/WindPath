

 using UnityEngine;

 interface BonusObject
 {
     public string getName();

     public Sprite getCover();
     
     public void LoadEffect(Transform go);
     public void Starteffect(Transform go);

     public void DisableEffect(Transform go);



 }
