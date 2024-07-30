using UnityEngine;
using Other.Advertisment;

public class MenuAdvHandler : MonoBehaviour
{
    [SerializeField] ShopController shopController;
    IAdvertismentManager advertismentManager;
    private void Awake()
    {
        advertismentManager = new TestAdvertismentManager();
    }
    private void OnEnable()
    {
        advertismentManager.RewardedVideoClosedAction += RewardedAdvClose;
    }
    private void OnDisable()
    {
        advertismentManager.RewardedVideoClosedAction -= RewardedAdvClose;
    }
    void RewardedAdvClose(int rewardKey, AdvertismentResultType rewardResult)
    {
        if(rewardResult == AdvertismentResultType.FullShowed)
        {
            RewardType rewardType = (RewardType)rewardKey;
            switch (rewardType)
            {
                case RewardType.UnlockProduct:
                    shopController.UnlockLastOpenedSkin();
                        break;
            }
        }
    }
    public void ShowRewAdv(RewardType rewType)
    {
        advertismentManager.ShowRewardedAdv((int)rewType);
    }
}
