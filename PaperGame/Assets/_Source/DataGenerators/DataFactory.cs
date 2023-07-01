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
        HeaderFactory _headerFactory;

        public DataFactory(DocumentTemplate documentTemplate, MarkFactory markFactory,
            QualityFactory qualityFactory, DateFactory dateFactory, HeaderFactory headerFactory)
        {
            _documentTemplate = documentTemplate;
            _markFactory = markFactory;
            _qualityFactory = qualityFactory;
            _dateFactory = dateFactory;
            _headerFactory = headerFactory;
        }

        public void CreateData(bool isError)
        {
            _markFactory.CreateMark(_documentTemplate.Mark);
            _dateFactory.CreateDate(_documentTemplate.Date);
            _qualityFactory.CreateScratches(_documentTemplate.Scratches);
            _headerFactory.CreateHeader(_documentTemplate.Header);
            while (isError)
            {
                switch (Random.Range(0, 4))
                {
                    case 0:
                        isError = _markFactory.CreateMark(_documentTemplate.Mark, isError);
                        break;
                    case 1:
                        isError = _dateFactory.CreateDate(_documentTemplate.Date, isError);
                        break;
                    case 2:
                        isError = _qualityFactory.CreateScratches(_documentTemplate.Scratches, isError);
                        break;
                    case 3:
                        isError = _headerFactory.CreateHeader(_documentTemplate.Header, isError);
                        break;
                }
            }
        }
    }
}