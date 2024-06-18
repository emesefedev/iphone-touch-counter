using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Image filledImage;

    private float totalHoldingTime = 3;
    private float holdingTime;
    private bool hasGameStarted;

    private void Start()
    {
        StarGame();
    }

    private void Update()
    {
        if (hasGameStarted)
        {
            if (holdingTime >= 0)
            {
                // Test in unity Editor
                if (Input.GetMouseButton(0))
                {
                    holdingTime -= Time.deltaTime;
                    filledImage.fillAmount = 1 - holdingTime / totalHoldingTime;

                }

                // Mobile logic
                if (Input.touchCount > 0)
                {
                    Touch touchInfo = Input.GetTouch(0);
                    if (touchInfo.phase == TouchPhase.Stationary)
                    {
                        holdingTime -= Time.deltaTime;
                        filledImage.fillAmount = 1 - holdingTime / totalHoldingTime;
                    }
                }
            }
            else
            {
                hasGameStarted = false;
                Invoke("StarGame", 3);
            }
        }
    }

    private void StarGame()
    {
        holdingTime = totalHoldingTime;
        filledImage.fillAmount = 0;
        hasGameStarted = true;
    }
}
