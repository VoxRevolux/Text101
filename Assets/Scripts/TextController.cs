using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;

    private enum States {
        menu, cell, sheets_0, lock_0,
        mirror, cell_1, sheets_1, lock_1,
        corridor_0, stairs_0, closet_door, floor,
        corridor_1, stairs_1, in_closet,
        corridor_2, stairs_2, corridor_3, courtyard, sleep
    }

    private States myState;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        print(myState);

        if( myState == States.menu )                        menu_state();
        if( myState == States.sleep )                       sleep_state();
        else if( myState == States.cell )                   cell_state();
        else if( myState == States.cell_1 )                 cell_1_state();
        else if( myState == States.sheets_0 )               sheets_0_state();
        else if( myState == States.lock_0 )                 lock_0_state();
        else if( myState == States.mirror )                 mirror_state();
        else if( myState == States.lock_1 )                 lock_1_state();
        else if( myState == States.sheets_1 )               sheets_1_state();
        else if( myState == States.corridor_0 )             corridor_0_state();
        else if( myState == States.stairs_0 )               stairs_0_state();
        else if( myState == States.closet_door )            closet_door_0_state();
        else if( myState == States.floor )                  floor_0_state();
        else if( myState == States.corridor_1 )             corridor_1_state();
        else if( myState == States.stairs_1 )               stairs_1_state();
        else if( myState == States.in_closet )              in_closet_state();
        else if( myState == States.corridor_2 )             corridor_2_state();
        else if( myState == States.stairs_2 )               stairs_2_state();
        else if( myState == States.corridor_3 )             corridor_3_state();
        else if( myState == States.courtyard )              courtyard_state();
    }

    void menu_state() {
        text.text = "PRESS SPACE TO BEGIN YOUR JOURNEY";
        if( Input.GetKeyDown(KeyCode.Space) ) myState = States.cell;
    }

    void cell_state() {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view Sheets, M to view Mirror, L to view Lock or B to sleep on Bed.";

        if( Input.GetKeyDown(KeyCode.S) ) myState = States.sheets_0;
        else if( Input.GetKeyDown(KeyCode.M) ) myState = States.mirror;
        else if( Input.GetKeyDown(KeyCode.L) ) myState = States.lock_0;
        else if( Input.GetKeyDown(KeyCode.B) ) myState = States.sleep;
    }

    void sheets_0_state() {
        text.text = "Some pretty dirty sheeeeeeeeeeeeeeeeeeets. Nothing special.\n\n" +
                    "Press R to Return to cell";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.cell;
    }

    void mirror_state() {
        text.text = "An old, but pretty reflexible mirror.\n\n" +
                    "Press T to Take the mirror or R to Return to the cell";

        if( Input.GetKeyDown(KeyCode.T) ) myState = States.cell_1;
        else if( Input.GetKeyDown(KeyCode.R) ) myState = States.cell;
    }

    void cell_1_state() {
        text.text = "It's your cell again!\nYou have a mirror in your pocket\n\n" +
                    "Press S to see the Sheets reflected or L to see the Lock button using the mirror.";

        if( Input.GetKeyDown(KeyCode.S) ) myState = States.sheets_1;
        else if( Input.GetKeyDown(KeyCode.L) ) myState = States.lock_1;
    }

    void lock_0_state() {
        text.text = "It's the lock of your cell. You can't see it properly from this side.\n\n" +
                    "Press R to Return to cell";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.cell;
    }

    void lock_1_state() {
        text.text = "It's the lock of your cell. From the reflex you can see the key in the lock outside the cell!\n\n" +
                    "Press K to turn the Key or R to Return to the cell.";

        if( Input.GetKeyDown(KeyCode.K) ) myState = States.corridor_0;
        else if( Input.GetKeyDown(KeyCode.R) ) myState = States.cell_1;
    }

    void sheets_1_state() {
        text.text = "The same useless sheets you saw without using the mirror. What did you think would change?\n\n" +
                    "Press R to Return to the cell";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.cell_1;
    }

    void corridor_0_state() {
        text.text = "Wow! You turned the key and the door opened! Now there are stairs going up on your " +
                    "left and a closet on your right.\n\n" +
                    "Press S to go up the stairs to the courtyard, C to check the Closet or F to look for something on the Floor.";

        if( Input.GetKeyDown(KeyCode.S) ) myState = States.stairs_0;
        else if( Input.GetKeyDown(KeyCode.C) ) myState = States.closet_door;
        else if( Input.GetKeyDown(KeyCode.F) ) myState = States.floor;
    }

    void stairs_0_state() {
        text.text = "If you go this way, the guards will know you escaped." +
                    "\n\n" +
                    "Press R to Return to the corridor.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_0;
    }

    void closet_door_0_state() {
        text.text = "The door is locked. Maybe you can find the key somewhere arround. " +
                    "\n\n" +
                    "Press R to Return to the corridor.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_0;
    }

    void floor_0_state() {
        text.text = "Looking on the floor, you can see a hairclip, which can be used for clipping your hair " +
                    "or for lockpicking, but only dirty people do this.\n\n" +
                    "Press T to take the hairclip or R to Return to the corridor.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_0;
        else if( Input.GetKeyDown(KeyCode.T) ) myState = States.corridor_1;
    }

    void corridor_1_state() {
        text.text = "You're back in the corridor. Now there are stairs going up on your " +
                    "left and a closet on your right. You now have a hairclip.\n\n" +
                    "Press S to go up the stairs to the courtyard or C to check the Closet.";

        if( Input.GetKeyDown(KeyCode.S) ) myState = States.stairs_1;
        else if( Input.GetKeyDown(KeyCode.C) ) myState = States.in_closet;
    }

    void stairs_1_state() {
        text.text = "If you go up the stairs, the guards will still find you. Are you stupid?" +
                    "\n\n" +
                    "Press R to Return to the corridor.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_1;
    }

    void in_closet_state() {
        text.text = "You used the hairclip to lockpick the closet. There are some officer clothes in there." +
                    "\n\n" +
                    "Press R to Return to the corridor or D to dress up.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_2;
        else if( Input.GetKeyDown(KeyCode.D) ) myState = States.corridor_3;
    }

    void corridor_2_state() {
        text.text = "You're back in the corridor. Now there are stairs going up on your " +
                    "left and the open closet on your right." +
                    "\n\n" +
                    "Press S to climb up the Stairs or C to go in the closet.";

        if( Input.GetKeyDown(KeyCode.S) ) myState = States.stairs_2;
        else if( Input.GetKeyDown(KeyCode.C) ) myState = States.in_closet;
    }

    void stairs_2_state() {
        text.text = "Are you kidding me? Are you trying to kill yourself? Haven't you understood you can't go to the courtyard" +
                            "if you want to stay alive? Now go back to the corridor and don't ever come back." +
                            "without a proper plan!\n\n" +
                            "Press R to Return to the corridor.";

        if( Input.GetKeyDown(KeyCode.R) ) myState = States.corridor_2;
    }

    void corridor_3_state() {
        text.text = "You're back in the corridor. Now there are stairs going up on your " +
                    "left and the open closet on your right, with no more clothes." +
                    "\n\n" +
                    "Press C to get into the Closet or S to climb up the Stairs to the courtyard..";

        if( Input.GetKeyDown(KeyCode.C) ) myState = States.in_closet;
        else if( Input.GetKeyDown(KeyCode.S) ) myState = States.courtyard;

    }

    void courtyard_state() {
        text.text = "You're now in the courtyard. There are many guards arround you, but they don't seem to notice " +
                            "you have just escaped your cell, since you're wearing their uniforms. " +
                            "You just walk pass them and get out of the prision for ever." +
                            "\n" +
                            "Well done! You just escaped the prision like a master!\n" +
                            "Press ENTER to star this epic journey all over again, in case you have been " + 
                            "arrested once again!";

        if( Input.GetKeyDown(KeyCode.C) ) myState = States.in_closet;
        else if( Input.GetKeyDown(KeyCode.S) ) myState = States.courtyard;
        else if( Input.GetKeyDown(KeyCode.Return) ) myState = States.cell;
    }

    void sleep_state() {
        text.text = "You decided to go to sleep instead of escaping the prision. " +
                    "Well done! Not everyone can take the stress of getting out of " +
                    "such a guarded place.\n\n" +
                    "Press W to wake up and start this epic journey all over again or S to keep sleeping.";

        if( Input.GetKeyDown(KeyCode.W) ) myState = States.cell;
    }

}