using Document;
using UnityEngine;

namespace DataFactories
{
    public class DataFactory
    {
        private DocumentTemplate _documentTemplate;
        private MarkFactory _markFactory;
        private QualityFactory _qualityFactory;
        private DateFactory _dateFactory;

        public DataFactory(DocumentTemplate documentTemplate, MarkFactory markFactory,
            QualityFactory qualityFactory, DateFactory dateFactory)
        {
            _documentTemplate = documentTemplate;
            _markFactory = markFactory;
            _qualityFactory = qualityFactory;
            _dateFactory = dateFactory;
        }

        public void CreateData(bool isError)
        {
            _markFactory.CreateMark(_documentTemplate.Mark);
            _dateFactory.CreateDate(_documentTemplate.Date);
            _qualityFactory.CreateScratches(_documentTemplate.Scratches);
            if (isError)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        _markFactory.CreateMark(_documentTemplate.Mark, isError);
                        break;
                    case 1:
                        _dateFactory.CreateDate(_documentTemplate.Date, isError);
                        break;
                    case 2:
                        _qualityFactory.CreateScratches(_documentTemplate.Scratches, isError);
                        break;
                }
            }
        }
    }
}