namespace Пр1
{
    public class FuelData
    {
        private double HP = 3.2;
        private double CP = 54.4;
        private double SP = 2.3;
        private double NP = 1;
        private double OP = 3.1;
        private double WP = 20;
        private double AP = 16;

        public double KPC => 100 / (100 - WP);
        public double KPT => 100 / (100 - WP - AP);

        public double QC => (QPH() + 0.025 * WP) * 100 / (100 - WP);
        public double QT => (QPH() + 0.025 * WP) * 100 / (100 - WP - AP);

        public double QPH()
        {
            return 339 * CP + 1030 * HP - 108.8 * (OP - SP) - 25 * WP;
        }

        public double HC => HP * KPC;
        public double CC => CP * KPC;
        public double SC => SP * KPC;
        public double NC => NP * KPC;
        public double OC => OP * KPC;
        public double AC => AP * KPC;

        public double HT => HP * KPT;
        public double CT => CP * KPT;
        public double ST => SP * KPT;
        public double NT => NP * KPT;
        public double OT => OP * KPT;
    }
}
