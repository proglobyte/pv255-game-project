public class GameManager : Singleton<GameManager> {
  protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
  public int numberOfLaps = 3;
}
