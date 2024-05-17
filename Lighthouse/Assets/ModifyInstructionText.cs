using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyInstructionText : MonoBehaviour
{
    public TMP_Text instructionText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.illusionType== "End") {
            instructionText.text = "You've now finished the experiment. \n\n Thanks for your participation! \n\n Please remove the headset and check in with the experimenter before you leave." ;

        } 
        else if (MainManager.Instance.sceneCounter == 0 && MainManager.Instance.illusionCounter == 0) 
        { 
            //instructionText.text = "Welcome to the experiment!\n In the next scene you'll see two spheres and will need to adjust the scene until the two spheres look identical in size." ;
            instructionText.text = "Welcome to the experiment!\n In the next scene you'll see two spheres and will have to decide which sphere looks bigger.\n\nThe instructions in the next scene will be visible on your right." ;
        } 
        else if (MainManager.Instance.sceneCounter == 0 && MainManager.Instance.illusionType == "AdjustDemo") 
        { 
            instructionText.text = "If you need to, please take a break!\n When you're ready you'll continue with a different task. The next scene will show two spheres and you'll need to use the A and B buttons on your controller to adjust the scene until the two spheres look identical in size." ;
        } 
        else if (MainManager.Instance.sceneCounter == 0 &&  !MainManager.Instance.Adjust) 
        {
            if (MainManager.Instance.illusionType == "Phantom") 
            { 
            instructionText.text = "Let's move to a different kind of scene!\nIn the next scene you'll see a moving beam and will have to decide whether the source of the beam is in front of you or behind you. The source of the beam may be moving or stationary. Only part of the beam is visible, and you won't be able to see the part that extends behind your back." ;
            } else if (MainManager.Instance.illusionType == "BentBeam") {
            instructionText.text = "Let's move to a different kind of scene!\n In the next scene you'll see a stationary beam and will have to decide whether the beam is tilted up or down. Only part of the beam is visible, and you won't be able to see the parts of the beam on the right or on the far left." ;
            } else {
            instructionText.text = "Let's move to a different kind of scene!\n In the next scene you'll see a stationary beam and have to decide whether the beam is tilted towards you or away from you. Only part of the beam is visible, and you won't be able to see the parts of the beam on the right or on the far left." ;
            }
        } 
        else if (MainManager.Instance.sceneCounter == 0  && MainManager.Instance.Adjust) 
        {
            if (MainManager.Instance.illusionType == "Phantom") 
            { 
            instructionText.text = "Let's move to a different kind of scene!\n In the next scene you'll see a moving beam and will adjust the scene until the beam looks as if it is sweeping horizontally over your head." ;
            } else if (MainManager.Instance.illusionType == "BentBeam") {
            instructionText.text = "Let's move to a different kind of scene!\n In the next scene you'll see a stationary beam and will adjust the scene until the beam looks horizontal." ;
            } else {
            instructionText.text = "Let's move to a different kind of scene!\n In the next scene you'll see a stationary beam and will adjust the scene until the beam is neither tilting towards you nor away from you." ;
            }
        } 
        else
        {
            instructionText.text = "Great! Press next to view another similar scene.\n\n" ;
        }
    }
}
