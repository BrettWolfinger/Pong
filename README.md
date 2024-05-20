### 20 Games Challenge: 1/20 Pong

## Gameplay Instructions
* Player 1 controls the right paddle using the keyboard (up and down arrows to move, left and right arrows to rotate)
* The left paddle is either controlled by the AI or a second player using a gamepad (up and down on d-pad to move, left and right to rotate)
* Selecting the enable modifications checkbox in the main menu will add:
  * The ability to rotate the paddle for additional control and decision making when trying to angle the ball's bounce
  * Small thrusters on either side of the paddle to add a fun graphical element to the rotation

## Things Learned
* Setting up input systems for multiplayer (turns out unity doesn't like you sharing a keyboard natively)
* Finding objects that extend an interface using LINQ to call all of the interface specified methods in one loop (IResetable)

* I could use events a lot more in this project to cut down on the number of script references

https://github.com/BrettWolfinger/Pong/assets/117947355/d1bf6d14-d983-47c3-9758-cc2f3df913ef
