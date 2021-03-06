﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_dinahyi_
{
    public class NN
    {
        public  N[] Neurons { get; set; }

        const string Path = "mem.json";

        public NN(int neuronsCount, int pictureW, int pictureH)
        {
            if (!File.Exists(Path))
            {
                //  File.Create(Path);
                //FileRW.Serialize(Path, Neurons);?
                Neurons = new N[neuronsCount];
                for (var i = 0; i < Neurons.Length; i++)
                {

                    Neurons[i] = new N
                    {
                        Weight = new double[pictureW, pictureH]
                    };
                    Neurons[i].Fill(Neurons[i].Weight);
                }

            }
            else
                Neurons = FileRW.Deserialize<N[]>(Path);
            
        }

        ~NN()
        {
            FileRW.Serialize(Path, Neurons);
        }

        public  int Answer(double[,] input)//==getInf (NeuronNet)
        {
            var answers = new double[Neurons.Length];
            for (var i = 0; i < Neurons.Length; i++)
            {
                answers[i] = Neurons[i].GetPower(input);
            }
            var correct = 0;
            for (var i = 0; i < answers.Length; i++)
            {
                if (answers[i] > answers[correct])
                    correct = i;
            }
            return correct;
            ///хуйняяяя
            ///возвращает индексы, знач придется вводить словарь (индекс->значение)
        }

        //public  double[,] BackPropagation(double learningRate, double[,] inp, int temp)
        //{
        //    //var temp = Neurons[0].GetPower(inp);
        //    //for (var i = 0; i < Neurons.Length; i++)
        //    //{
        //    //    if (Neurons[i].GetPower(inp) > temp)
        //    //        temp = Neurons[i].GetPower(inp);
        //    //}

           
        //    var weightDelta = 1 / (1 + Math.Exp(-temp)) * (1 - 1 / (1 + Math.Exp(-temp)));

        //    for (var i = 0; i < N.Weight.GetLength(0); i++)
        //    {
        //        for (var j = 0; j < N.Weight.GetLength(1); j++)
        //        {
        //            N.Weight[i, j] = N.Weight[i, j] - Neurons[j].GetPower(inp) * weightDelta * learningRate;
        //        }
        //    }
        //    return N.Weight;
        //}
        public void Study (double [,]inp, int answer, int memPower)
        {
            Neurons[answer].MemoryWhitPower(inp, memPower);
        }

        //public  void Check (int answer, double[,] inp, int memPower )
        //{
        //    Console.WriteLine(answer + " is my answer, what is correct?");
        //    if (answer==Int32.Parse(Console.ReadLine()))
        //        Console.WriteLine("oh my");
        //    else
        //    {
        //        Console.WriteLine("your machine learning sucks");
        //        //for (var i = 0; i < Neurons.Length; i++)
        //        //{
        //        //    //Neurons[i].Backpropagation(0.1, inp, answer);

        //        //}
        //        Neurons.Study(inp, answer, memPower);


        //    }
        //}


        //add Study?



    }
}
