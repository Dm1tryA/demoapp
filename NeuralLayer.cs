using System;
using System.Collections.Generic;

namespace demoapp
{
    public class NeuralLayer
    {
        public List<Neuron> Neurons { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public NeuralLayer(int count, double initialWeight, string name = "")
        {
            Neurons = new List<Neuron>();
            Console.WriteLine("Create List Neyrons");
            for (int i = 0; i < count; i++)
            {
                Neurons.Add(new Neuron());
            }
            Console.WriteLine("Add with 'for' count{0} neurons", count);
            Weight = initialWeight;

            Name = name;
        }
        public void Optimize(double learningRate, double delta)
        {
            Weight += learningRate * delta;
            foreach (var neuron in Neurons)
            {
                neuron.UpdateWeights(Weight);
            }
        }
        public void Log()
        {
            Console.WriteLine("{0}, Weight: {1}", Name, Weight);
        }
    }
}
