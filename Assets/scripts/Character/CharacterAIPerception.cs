using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAIPerception : MonoBehaviour
{
    CharacterAI brain;

    private void OnTriggerEnter(Collider other)
    {
        brain = GetComponent<CharacterAI>();

        if (other.gameObject != gameObject)
        switch (other.gameObject.layer)
        {
            case 8: //humanoid
                if(brain.hasGun || brain.hasGranade)
                {
                    Character c = other.GetComponent<Character>();
                    if (c)
                    {
                        if (c.Team ^ GetComponent<Character>().Team) //different teams
                        {
                            if (brain.target == null)
                                brain.target = other.transform;
                        }
                    }
                }
                
                break;
            case 6: //pickable
                switch (other.tag)
                {
                    case "Pistol":
                        if (!brain.hasGun && brain.target == null)
                            brain.target = other.transform;
                        break;
                    //case "Granade":
                    //    if (!brain.hasGranade && brain.target == null)
                    //        brain.target = other.transform;
                    //    break;
                }
                break;
        }

        

    }
}
