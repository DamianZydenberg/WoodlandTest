using UnityEngine;

namespace WoodlandTest
{
    public class CoinManager : MonoBehaviour
    {
        int pickedUpCoins;
        int allCoinsCount;

        void OnEnable() => GameEventsMain.CoinPickedUp += PickCoinFromScene;
        void OnDisable() => GameEventsMain.CoinPickedUp -= PickCoinFromScene;

        void Awake()
        {
            allCoinsCount = GetComponentsInChildren<Coin>().Length;
            Debug.Log(allCoinsCount);
        }

        void PickCoinFromScene(Coin _coin)
        {
            _coin.gameObject.SetActive(false);
            pickedUpCoins++;

            if (pickedUpCoins == allCoinsCount)
            {
                Debug.Log("GGWP");
            }
        }
    }
}
