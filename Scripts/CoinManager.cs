using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public TextMeshProUGUI coinText;
    public int coins = 0;
    public float passiveIncomePerMinute = 30f; // sama dengan sheet Economy
    private float timer;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        UpdateUI();
    }

    void Update()
    {
        timer += Time.deltaTime * passiveIncomePerMinute / 60f;
        if (timer >= 1f)
        {
            int add = Mathf.FloorToInt(timer);
            timer -= add;
            AddCoin(add);
        }
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null) coinText.text = "Coin: " + coins;
    }
}