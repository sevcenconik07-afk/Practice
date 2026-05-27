using UnityEngine;
using R3;
public class GameState 
{
   private readonly SaveGameState _saveGameState;

   public GameState(SaveGameState saveGameState)
   {
        _saveGameState = saveGameState;
   }
}
