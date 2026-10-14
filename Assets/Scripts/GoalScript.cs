using UnityEngine;

public class GoalScript : MonoBehaviour
{
	bool _reached = false;

	private void OnTriggerEnter(Collider other)
	{
		if (_reached) return;
		if (other.CompareTag("Player"))
		{
			if (gameManager.Instance.collectedPickups != gameManager.Instance?.totalPickups) return;
			_reached = true;
			gameManager.Instance?.onGoalReached();
		}
	}
}
