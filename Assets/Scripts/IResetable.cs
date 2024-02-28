/*
Interface extended by all scripts that control state of a gameobject.
Used so that the game manager can reset everything back to its original
state for a new game. 

Could probably avoid using this if I did multiple scenes but for
this project I wanted to try doing it this way.
*/
public interface IResetable
{
    public void Reset();
}
