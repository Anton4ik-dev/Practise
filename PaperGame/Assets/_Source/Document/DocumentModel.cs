using DataFactories;
using Random = UnityEngine.Random;

namespace Document
{
    public class DocumentModel
    {
        private DataFactory _dataFactory;
        private ScoreChanger _scoreChanger;
        private RageChanger _rageChanger;
        private int _repeatingRight = 0;
        private int _repeatingFake = 0;
        private bool _isFake;

        public DocumentModel(DataFactory dataFactory, ScoreChanger scoreChanger, RageChanger rageChanger)
        {
            _dataFactory = dataFactory;
            _scoreChanger = scoreChanger;
            _rageChanger = rageChanger;
        }

        public void CreateData()
        {
            if (Random.Range(0, 2) == 0)
                CreateRight();
            else
                CreateFake();
        }

        public void CheckExit(bool playerResult)
        {
            _scoreChanger.ChangeScore(playerResult == _isFake);
            _rageChanger.AddRage();
        }

        private void CreateRight()
        {
            if (_repeatingRight < 2)
            {
                _repeatingRight++;
                _isFake = false;
                _dataFactory.CreateData(_isFake);
                _repeatingFake = 0;
            }
            else
                CreateFake();
        }

        private void CreateFake()
        {
            if (_repeatingFake < 2)
            {
                _repeatingFake++;
                _isFake = true;
                _dataFactory.CreateData(_isFake);
                _repeatingRight = 0;
            }
            else
                CreateRight();
        }
    }
}