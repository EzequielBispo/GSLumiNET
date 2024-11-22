namespace GSLumiNET.ML;
using Microsoft.ML;
using GSLumiNET.Application.MLModels;
using System;
using System.Collections.Generic;
using System.Linq;

public class ModeloMachineLearning
{
    private static string _dadosTreinamento = @"dados.csv"; 
    public static void TreinarModelo()
    {
        var mlContext = new MLContext();

        var dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosEntrada>(_dadosTreinamento, separatorChar: ',', hasHeader: true);

        var pipeline = mlContext.Regression.Trainers.Sdca(labelColumnName: "ILampada", maximumNumberOfIterations: 100);

        var modelo = pipeline.Fit(dadosTreinamento);

        mlContext.Model.Save(modelo, dadosTreinamento.Schema, "modelo.zip");
        Console.WriteLine("Modelo treinado e salvo.");
    }

    public static void RealizarPredicao()
    {
        var mlContext = new MLContext();
        var modelo = mlContext.Model.Load("modelo.zip", out var modelInputSchema);

        var dadosParaPredicao = new DadosEntrada()
        {
            IExterna = 2.5f,
            IInterna = 3.0f
        };

        var predicaoFunc = mlContext.Model.CreatePredictionEngine<DadosEntrada, DadosSaida>(modelo);

        var resultado = predicaoFunc.Predict(dadosParaPredicao);
        Console.WriteLine($"Predição para ILampada: {resultado.ILampada}");
    }
}
