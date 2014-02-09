namespace Hotel.Src
{
    public class Hotel
    {
        private int _rating;
        private int _regularWeekDayCost;
        private int _regularWeekendDayCost;
        private int _rewardWeekDayCost;
        private int _rewardWeekendkDayCost;
        public string Name;
        public Hotel SetRating(int rating)
        {
            _rating = rating;
            return this;
        }
        public Hotel SetRegularWeekDayCost(int regularWeekDayCost)
        {
            _regularWeekDayCost = regularWeekDayCost;
            return this;
        }
        public Hotel SetRegularWeekendDayCost(int regularWeekendDayCost)
        {
            _regularWeekendDayCost = regularWeekendDayCost;
            return this;
        }
        public Hotel SetRewardWeekDayCost(int rewardWeekDayCost)
        {
            _rewardWeekDayCost = rewardWeekDayCost;
            return this;
        }
        public Hotel SetRewardWeekendkDayCost(int rewardWeekendkDayCost)
        {
            _rewardWeekendkDayCost = rewardWeekendkDayCost;
            return this;
        }

        public int GetRatting()
        {
            return _rating;
        }
        public int GetRegularWeekDayCost()
        {
            return _regularWeekDayCost;
        }

        public int GetRegularWeekendDayCost()
        {
            return _regularWeekendDayCost;
        }

        public int GetRewardWeekDayCost()
        {
            return _rewardWeekDayCost;
        }

        public int GetRewardWeekendDayCost()
        {
            return _rewardWeekendkDayCost;
        }

    }
}