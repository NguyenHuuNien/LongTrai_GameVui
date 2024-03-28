using Unity.VisualScripting;

public interface State{
    OnBeginDrag();
    OnExecute();
    OnExit();
}