﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BitHeat
{
    class Calculations
    {
        private  (double totalEnergy, double heatEnergy, double mineEnergy) energy;

        private  double cost, THS, area;

        public void UpdateCost(double value)
        {
            cost = value;
            THS = value / 3000 * 13.5;
            energy.totalEnergy = cost / 3000 * 1500;
            energy.heatEnergy = energy.totalEnergy * 0.85;
            energy.mineEnergy = energy.totalEnergy * 0.15;
            GetArea();
        }

        private void GetArea()
        {
            area = energy.heatEnergy * 365 * 24 / 1000;
            area /= 1000;
            area = area * 1500 / 444.39;
        }

        public void UpdatePower(double value)
        {
            energy.totalEnergy = value;
            energy.heatEnergy = energy.totalEnergy * 0.85;
            energy.mineEnergy = energy.totalEnergy * 0.15;
            GetArea();
        }

        public void UpdateTHS(double value)
        {
            THS = value;
            energy.totalEnergy = THS / 13.5 * 1500;
            energy.heatEnergy = energy.totalEnergy * 0.85;
            energy.mineEnergy = energy.totalEnergy * 0.15;
            GetArea();
        }

        public ObservableCollection<KeyValuePair<string, double>> GetList()
        {
            ObservableCollection<KeyValuePair<string, double>> list = new ObservableCollection<KeyValuePair<string, double>>
            {
                new KeyValuePair<string, double>("Total energy", energy.totalEnergy),
                new KeyValuePair<string, double>("Heat enegry", energy.heatEnergy),
                new KeyValuePair<string, double>("Mine energy", energy.mineEnergy)
            };
            return list;
        }

        public double Area  => area; 
    }
}
