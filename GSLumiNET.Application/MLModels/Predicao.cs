using Microsoft.ML;

namespace GSLumiNET.Application.MLModels
{
    public class Predicao
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<DadosEntrada, DadosSaida> _predicaoEngine;

        public Predicao()
        {
            _mlContext = new MLContext();

            var modelo = _mlContext.Model.Load("./GSLumiNET.ML/modelo.zip", out var modelInputSchema);

            _predicaoEngine = _mlContext.Model.CreatePredictionEngine<DadosEntrada, DadosSaida>(modelo);
        }

        public float FazerPredicao(DadosEntrada entrada)
        {
            var resultado = _predicaoEngine.Predict(entrada);
            return resultado.ILampada;
        }
    }
}

