using System;
namespace Other.Advertisment
{
    public class TestAdvertismentManager : IAdvertismentManager
    {
        public Action<int, AdvertismentResultType> RewardedVideoClosedAction { get ; set ; }

        void OnRewardedVideoShowed(int rewardKey)
        {
            RewardedVideoClosedAction?.Invoke(rewardKey, AdvertismentResultType.FullShowed);
        }
        public void ShowRewardedAdv(int rewardKey)
        {
            OnRewardedVideoShowed(rewardKey);
        }

    }
}
