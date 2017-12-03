// IInteractable interface, classes implementing this are able to be interacted with by calling the Interact() function
public interface IInteractable {
	// Function to implement what to do when object is interacted with
	void Interact();

	// Function to implement what to do when interactable range around object is entered
	void RangeEntered();

	// Function to implement what to do when interactable range around object is exited
	void RangeExited();
}

