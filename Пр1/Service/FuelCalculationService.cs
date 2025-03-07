using Пр1.Models;

namespace Пр1.Service
{
    public class FuelCalculationService
    {
        private FuelCalculationModel fuelCalculationModel = new FuelCalculationModel();
        private OilFuelCalculationModel oilFuelCalculationModel = new OilFuelCalculationModel();

        public FuelCalculationModel Calculate(FuelModel model)
        {
            fuelCalculationModel.KPC = 100 / (100 - model.WP);
            fuelCalculationModel.KPT = 100 / (100 - model.WP - model.AP);

            fuelCalculationModel.HC = model.HP * fuelCalculationModel.KPC;
            fuelCalculationModel.CC = model.CP * fuelCalculationModel.KPC;
            fuelCalculationModel.SC = model.SP * fuelCalculationModel.KPC;
            fuelCalculationModel.NC = model.NP * fuelCalculationModel.KPC;
            fuelCalculationModel.OC = model.OP * fuelCalculationModel.KPC;
            fuelCalculationModel.AC = model.AP * fuelCalculationModel.KPC;

            fuelCalculationModel.HT = model.HP * fuelCalculationModel.KPT;
            fuelCalculationModel.CT = model.CP * fuelCalculationModel.KPT;
            fuelCalculationModel.ST = model.SP * fuelCalculationModel.KPT;
            fuelCalculationModel.NT = model.NP * fuelCalculationModel.KPT;
            fuelCalculationModel.OT = model.OP * fuelCalculationModel.KPT;

            fuelCalculationModel.QPH = 339 * model.CP + 1030 * model.HP - 108.8 * (model.OP - model.SP) - 25 * model.WP;
            fuelCalculationModel.QCH = (fuelCalculationModel.QPH + 0.025 * model.WP) * 100 / (100 - model.WP);
            fuelCalculationModel.QGH = (fuelCalculationModel.QPH + 0.025 * model.WP) * 100 / (100 - model.WP - model.AP);

            return fuelCalculationModel;
        }

        public OilFuelCalculationModel CalculateOil(OilFuelModel model)
        {
            oilFuelCalculationModel.C = (model.C * (100 - model.W - model.A) / 100);
            oilFuelCalculationModel.H = (model.H * (100 - model.W - model.A) / 100);
            oilFuelCalculationModel.O = (model.O * (100 - model.W - model.A) / 100);
            oilFuelCalculationModel.S = (model.S * (100 - model.W - model.A) / 100);
            oilFuelCalculationModel.V = (model.V * (100 - model.W - model.A) / 100);
            oilFuelCalculationModel.A = (model.A * (100 - model.W) / 100);

            oilFuelCalculationModel.Qr = model.Qdaf * ((100 - model.W - model.A) / 100) - 0.025 * model.W;

            return oilFuelCalculationModel;
        }
    }
}