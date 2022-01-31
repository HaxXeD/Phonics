using UnityEngine;

namespace Haxxed{
    public class DeactivateColliders : MonoBehaviour
    {
        GameObject[] letter;

        public void DisableClicks()
        {
            for(int i = 0; i < letter.Length; i++)
            {
                letter[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        public void EnableClicks()
        {
            for (int i = 0; i < letter.Length; i++)
            {
                letter[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        void Update()
        {
            letter = GameObject.FindGameObjectsWithTag("box");
        }
    }
}
