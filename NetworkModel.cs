﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConsoleTableExt;

namespace demoapp
{
    public class NetworkModel
    {
        public List<NeuralLayer> Layers { get; set; }

        public NetworkModel()
        {
            Layers = new List<NeuralLayer>();
        }

        public void AddLayer(NeuralLayer layer)
        {
            int dendriteCount = 1;

            if (Layers.Count > 0)
            {
                dendriteCount = Layers.Last().Neurons.Count;
            }

            foreach (var element in layer.Neurons)
            {
                for (int i = 0; i < dendriteCount; i++)
                {
                    element.Dendrites.Add(new Dendrite());
                }
            }
        }

        public void Build()
        {
            int i = 0;
            foreach (var layer in Layers)
            {
                if (i >= Layers.Count - 1)
                {
                    break;
                }

                var nextLayer = Layers[i + 1];
                CreateNetwork(layer, nextLayer);

                i++;
            }
        }

        public void Train()//NeuralData X, NeuralData Y, int iterations, double learningRate = 0.1)
        {
            //Implement Training Method
        }

        public void Print()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Neurons");
            dt.Columns.Add("Weight");

            foreach (var element in Layers)
            {
                DataRow row = dt.NewRow();
                row[0] = element.Name;
                row[1] = element.Neurons.Count;
                row[2] = element.Weight;

                dt.Rows.Add(row);
            }

            ConsoleTableBuilder builder = ConsoleTableBuilder.From(dt);
            builder.ExportAndWrite();
        }

        private void CreateNetwork(NeuralLayer connectingFrom, NeuralLayer connectingTo)
        {
            foreach (var to in connectingTo.Neurons)
            {
                foreach (var from in connectingFrom.Neurons)
                {
                    to.Dendrites.Add(new Dendrite() { InputPulse = from.OutputPulse, SynapticWeight = connectingTo.Weight });
                }
            }
        }
    }
}
