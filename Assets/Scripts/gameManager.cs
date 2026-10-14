using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

	[Header("Pickup")]
    public int totalPickups = 5;
    public int collectedPickups = 0;

	[Header("UI Elements")]
	public TMP_Text itemDisplay;
    public GameObject winPanel;

	bool _gameOver = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

		Instance = this;

        //use if uou want game manager to persists between scebes
        DontDestroyOnLoad(gameObject);
	}

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        if (itemDisplay == null)
		{
			UpdateUI();
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickupCollected()
    {
        if (_gameOver) return;
        collectedPickups++;
        UpdateUI();

	}

    public void onGoalReached()
    {
        if (_gameOver) return;
        _gameOver = true;

        if (winPanel != null)
        {
            winPanel.SetActive(false);
            winPanel.GetComponentInChildren<TMP_Text>().text = $"Yay you did it! You grabbes all of the {collectedPickups} items!";
		}
    }

    void UpdateUI()
    {
        if (itemDisplay != null)
        {
			itemDisplay.text = $"Items: {collectedPickups}/{totalPickups}";
		}
    }
}
