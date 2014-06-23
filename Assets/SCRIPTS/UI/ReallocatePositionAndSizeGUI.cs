using UnityEngine;
using System.Collections;

public class ReallocatePositionAndSizeGUI : MonoBehaviour
{

         
        void Start()
        {
                        
        }

        public Vector2 ReadjustGUIPosition(float originalPosX, float originalPosY, float originalWidth, float originalHeight)
        {
            Vector2 newPos = new Vector2(originalPosX * Screen.width / originalWidth, originalPosY * Screen.height / originalHeight);
            return newPos;
        }

        public Vector2 ReadjustGUISize(float originalSizeX, float originalSizeY, float originalWidth, float originalHeight)
        {
            Vector2 newPos = new Vector2(originalSizeX * Screen.width / originalWidth, originalSizeY * Screen.height / originalHeight);

            return newPos;
        }
    
}
