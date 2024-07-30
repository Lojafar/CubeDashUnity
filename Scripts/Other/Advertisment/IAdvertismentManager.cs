using System;
namespace Other.Advertisment
{
    public interface IAdvertismentManager
    {
        public Action<int, AdvertismentResultType> RewardedVideoClosedAction { get; set; }
        public void ShowRewardedAdv(int rewardKey);
    }
}
