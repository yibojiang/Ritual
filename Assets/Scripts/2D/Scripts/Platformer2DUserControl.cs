using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public Mob mob;

        private void Awake()
        {
            mob=GetComponent<Mob>();
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) ){
                if (!mob.ContainsColor(ColorEnum.Red) ){
                    mob.AbsorbColor(ColorEnum.Red);
                }
                else{
                    mob.RemoveColor(ColorEnum.Red);
                }
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) ){
                if (!mob.ContainsColor(ColorEnum.Green) ){
                    mob.AbsorbColor(ColorEnum.Green);
                }
                else{
                    mob.RemoveColor(ColorEnum.Green);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) ){
                if (!mob.ContainsColor(ColorEnum.Blue) ){
                    mob.AbsorbColor(ColorEnum.Blue);
                }
                else{
                    mob.RemoveColor(ColorEnum.Blue);
                }
            }

            // if(CrossPlatformInputManager.GetButtonDown("Fire2") ){
            //     // Debug.Log("Fire");
            //     Vector2 p1=transform.position;
            //     Vector2 p2=transform.position;
            //     p2+=new Vector2(0, -1.5f);
            //     // Debug.Log("p1: "+p1+" - "+p2);
            //     Debug.DrawLine(p1,p2,Color.red,1f);
            //     int layerMask=1<<LayerMask.NameToLayer("Splash");
            //     // Debug.Log("layer mask: "+layerMask);
            //     RaycastHit2D hit=Physics2D.Linecast(p1,p2,layerMask);
            //     if (hit.collider!=null){
            //         Debug.Log(hit.collider.name);    
            //         Splash splash=hit.collider.GetComponent<Splash>();
                    
            //         if (mob.AbsorbColor(splash.color) ){
            //             // Debug.Log("destroy: "+hit.collider.name);    
            //             Destroy(splash.gameObject);
            //         }
            //     }
            // }

            if(CrossPlatformInputManager.GetButton("Fire1") ){
                ColorEnum releaseCol=ColorEnum.White;
                if (mob.GetReleaseColor(out releaseCol) ){
                // if (mob.ReleaseColor(out releaseCol) ){
                    GameObject dropPrefab=Resources.Load<GameObject>("Prefab/ColorDrop");
                    GameObject dropObj=(GameObject)Instantiate(dropPrefab, transform.position,Quaternion.identity);    
                    dropObj.GetComponent<ColorDrop>().color=releaseCol;
                    
                    // GameManager gm=GameManager.Instance();
                    // dropObj.GetComponent<ColorDrop>().SetColor( gm.GetColor(releaseCol));
                }
                
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            // bool boost = Input.GetKey(KeyCode.LeftShift);
            // Debug.Log("input boost: "+boost);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }
    }
}
