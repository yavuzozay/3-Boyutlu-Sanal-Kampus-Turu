

public interface IInteractable
{
    float MaxRange { get; }
    void OnInteract();
    void OnEndHover();
    void OnStartHover();
}
