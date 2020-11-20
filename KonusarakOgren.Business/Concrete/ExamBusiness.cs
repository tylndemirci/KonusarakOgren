using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.Business.Concrete
{
    public class ExamBusiness : IExamBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericDal<Exam> _examDal;
        private readonly IGenericDal<ExamQuestion> _examQuestionDal;

        public ExamBusiness(IUnitOfWork unitOfWork, IGenericDal<Exam> examDal, IGenericDal<ExamQuestion> examQuestionDal)
        {
            _unitOfWork = unitOfWork;
            _examDal = examDal;
            _examQuestionDal = examQuestionDal;
        }

        public void CreateExam(Exam exam)
        {
            
            
            var createExam = new Exam
            {
                Title = exam.Title,
                Content = exam.Content,
                ExamQuestions = exam.ExamQuestions,
                DateTime = exam.DateTime
            };

            _examDal.Create(createExam);
            _unitOfWork.SaveChanges();

            foreach (var questionModel in exam.ExamQuestions.ToList())
            {
                var question = new ExamQuestion();
                question.Exam = createExam;
                question.Question = questionModel.Question;
                question.OptionA = questionModel.OptionA;
                question.OptionB = questionModel.OptionB;
                question.OptionC = questionModel.OptionC;
                question.OptionD = questionModel.OptionD;
                question.Answer = questionModel.Answer;
                _examQuestionDal.Create(question);
            }

            _unitOfWork.SaveChanges();
        }

        public void DeleteExam(int examId)
        {
            var exam = _examDal.GetBy(x => x.Id == examId).FirstOrDefault();
            if (exam != null) exam.IsDeleted = true;
            _unitOfWork.SaveChanges();
        }

        public async Task<ScrapeWiredComResponseModel> ScrapeWiredCom()
        {
            const string url = "https://www.wired.com";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Anasayfadan linkleri toplanıyor.

            var firstComponent = htmlDocument.DocumentNode
                .Descendants("div").FirstOrDefault(x => x.GetAttributeValue("class", "")
                    .Equals("cards-component"));


            var articles = firstComponent?.Descendants("div")
                .Where(x => x.GetAttributeValue("class", "")
                    .Contains("card-component")).ToList();
            var links = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                var link = articles?[i].Descendants("a").FirstOrDefault()?.GetAttributeValue("href", "");
                var insert = link?.Insert(0, "https://www.wired.com");
                links.Add(insert);
            }

            // Makale linkleri toplandı.
            var titleList = new List<string>();
            var contentList = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var htmlFor = await httpClient.GetStringAsync(links[i]);

                htmlDocument.LoadHtml(htmlFor);


                htmlDocument.DocumentNode.SelectNodes("//style|//script").ToList().ForEach(n => n.Remove());

                var title = htmlDocument.DocumentNode
                    .SelectSingleNode(".//h1[@class='content-header__row content-header__hed']")
                    .InnerText;
                titleList.Add(title);
                var content = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .InnerText;
                content += " " + htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .NextSibling
                    .InnerText;
                content += " " + htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .NextSibling
                    .NextSibling
                    .InnerText;
                string decodedString = System.Web.HttpUtility.HtmlDecode(content);

                //Reklam değeri olan içerikler için:

                if (string.IsNullOrEmpty(content))
                {
                    content = htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("gallery__text-block"))?
                        .InnerText;
                    content += " " + htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("grid--item body body__container article__body grid-layout__content"))?
                        .FirstChild
                        .NextSibling
                        .InnerText;
                    content += " " + htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("grid--item body body__container article__body grid-layout__content"))?
                        .FirstChild
                        .NextSibling
                        .NextSibling
                        .InnerText;
                    decodedString = System.Web.HttpUtility.HtmlDecode(content);
                }

                contentList.Add(decodedString);
            }

            return new ScrapeWiredComResponseModel() {TitleList = titleList, ContentList = contentList};
        }
    }
}