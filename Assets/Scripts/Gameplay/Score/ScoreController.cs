using System;
using Modules;
using Zenject;

namespace Gameplay
{
    public class ScoreController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly ICoinController _coinController;

        public ScoreController(IScore score, ICoinController coinController)
        {
            _score = score;
            _coinController = coinController;
        }

        void IInitializable.Initialize()
        {
            _coinController.OnEat += CoinEatHandler;
        }

        void IDisposable.Dispose()
        {
            _coinController.OnEat -= CoinEatHandler;
        }

        private void CoinEatHandler(Coin coin)
        {
            _score.Add(coin.Score);
        }
    }
}